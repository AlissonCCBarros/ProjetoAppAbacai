using Project.Dto.Custom;
using Project.Services.Helper;
using Common.Domain.Enums;
using Common.Domain.Interfaces;
using Common.Domain.Model;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Project.Core.Data.Repository;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Project.Core.Services
{

    public class UserService
    {
        public IEmail email { get; set; }
        private ICripto _cripto;
        private AccountRepository _repAccountRepository;
        public IOptions<ConfigEmailBase> _configEmailBase { get; set; }
        public UserService(
            AccountRepository repAccountRepository,
            IEmail _email,
            IOptions<ConfigEmailBase> configEmailBase,
            ICripto cripto)
        {
            this.email = _email;
            this.email.Config(configEmailBase.Value);
            this._configEmailBase = configEmailBase;
            this._repAccountRepository = repAccountRepository;
            this._cripto = cripto;
        }

        private string GenerateToken(UserDto user, SigningConfigurations signingConfigurations)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim("sub", user.AccountId.ToString()),
                    new Claim("name", user.Name.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = signingConfigurations.SigningCredentials
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public UserDto GetUser(UserDto dto, SigningConfigurations signingConfigurations)
        {
            var password = this._cripto.Encrypt(dto.Password, TypeCripto.Hash128);

            var result = new UserDto();

            if (dto.AttributeBehavior == "WebSystem")
            {
                result = this._repAccountRepository.GetAll()
                                    .Include(_ => _.Usuario)
                                    .Where(_ => _.Email == dto.Email)
                                    .Where(_ => _.Password == password)
                                    .Where(_ => _.Admin == true)
                                    .Select(_ => new UserDto
                                    {
                                        AccountId = _.AccountId,
                                        Email = _.Email,
                                        Name = _.Name,
                                        EhInstituicao = _.Usuario.EhInstituicao
                                    }).SingleOrDefault();
            }
            else
            {
                result = this._repAccountRepository.GetAll()
                    .Include(_ => _.Usuario)
                    .Where(_ => _.Email == dto.Email)
                    .Where(_ => _.Password == password)
                    .Where(_ => _.Admin == false)
                    .Select(_ => new UserDto
                    {
                        AccountId = _.AccountId,
                        Email = _.Email,
                        Name = _.Name,
                        EhInstituicao = _.Usuario.EhInstituicao
                    }).SingleOrDefault();
            }

            if (result.IsNotNull())
                result.Token = GenerateToken(result, signingConfigurations);

            return result;
        }

        public dynamic ForgottenPassword(UserDto dto)
        {
            try
            {
                var result = this._repAccountRepository.GetAll()
                    .Where(_ => _.Email == dto.Email).SingleOrDefault();

                if (result.IsNotNull())
                {
                    dto.Password = GeraSenha();
                    dto.Name = result.Name;

                    var password = this._cripto.Encrypt(dto.Password, TypeCripto.Hash128);

                    result.Password = password;
                    _repAccountRepository.Update(result);
                    _repAccountRepository.Commit();

                    this.MandarEmailParaUsuario(dto);

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                return false;
                //return this._validation.AddNotification("Account_Existe", "Já existe uma conta registrada para esse e-mail.");
            }
        }
        private string GeraSenha()
        {
            string guid = Guid.NewGuid().ToString().Replace("-", "");

            Random clsRan = new Random();
            Int32 tamanhoSenha = clsRan.Next(6, 10);

            string senha = "";
            for (Int32 i = 0; i <= tamanhoSenha; i++)
            {
                senha += guid.Substring(clsRan.Next(1, guid.Length), 1);
            }

            return senha;
        }

        private void MandarEmailParaUsuario(UserDto dto)
        {
            var html = TemplateEmail(dto);

            email.AddAddressFrom("Aplicativo Abraçaí", "abracaiapp2020@gmail.com");
            email.AddAddressTo(dto.Name, dto.Email);
            email.Send("Nova Senha", html.ToString());

        }

        private object TemplateEmail(UserDto dto)
        {
            return $@"<html>
<title>App Abraçaí</title>
<head>
    <meta http-equiv='Content-Type' content='text/html; charset=utf-8'>
</head>

<body>
    <div class='es-wrapper-color'>
        <table class='es-wrapper' width='100%' cellspacing='0' cellpadding='0'>
            <tbody>
                <tr>
                    <td class='esd-email-paddings' valign='top'>
                        <table cellpadding='0' cellspacing='0' class='es-header' align='center'>
                            <tbody>
                                <tr>
                                    <td class='es-adaptive esd-stripe' align='center' esd-custom-block-id='88593'>
                                        <table class='es-header-body' style='background-color: #199559; height: 100px;'
                                         width='600' cellspacing='0' cellpadding='0' bgcolor='#199559' align='center'>
                                            <tbody>
                                                <tr>
                                                    <td class='esd-structure es-p20t es-p20b es-p20r es-p20l' align='center'>
                                                        <table class='es-center' cellspacing='0' cellpadding='0' align='center'>
                                                            <tbody>
                                                                <tr>
                                                                    <td class='es-m-p20b esd-container-frame' width='270' align='center'>
                                                                        <table width='100%' cellspacing='0' cellpadding='0'>
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td class='esd-block-image es-m-p0l es-m-txt-c' align='center' style='color: #FFF;font-size: 20px; font-family: sans-serif; padding-top: 30px'>
                                                                                        <h2>App Abraçaí</h2>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <table class='es-content' cellspacing='0' cellpadding='0' align='center'>
                            <tbody>
                                <tr>
                                    <td class='esd-stripe' esd-custom-block-id='13498' align='center'>
                                        <table class='es-content-body' style='background-color: #FFF;' width='600' cellspacing='0' cellpadding='0' bgcolor='#fafafa' align='center'>
                                            <tbody>
                                                <tr>
                                                    <td class='esd-structure' style='background-repeat: no-repeat;' align='left'>
                                                        <table width='100%' cellspacing='0' cellpadding='0'>
                                                            <tbody>
                                                                <tr>
                                                                    <td class='esd-container-frame' width='600' valign='top' align='center'>
                                                                        <table style='background-color: #fdfdfd' width='100%' cellspacing='0' cellpadding='0'>
                                                                            <tbody>
                                                                                <tr style='height: 360px'>
                                                                                    <td class='esd-block-banner' style='position: relative;font-size: 19px; font-family: sans-serif;' align='center' esdev-config='h2'>
                                                                                        <p>Olá, segue abaixo a sua nova senha:</h2>
                                                                                            <div style='
                                                                                            background-color: #199559;
                                                                                             height: 25px; width: 150px;
                                                                                              border-radius: 20px; padding-top: 8px; color: #FFF'>
                                                                                            <span>{dto.Password}</span>
                                                                                            </div>
                                                                                            <p>Obrigado por fazer a diferença!</p>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    
                        <table class='esd-footer-popover es-content' cellspacing='0' cellpadding='0' align='center'>
                            <tbody>
                                <tr>
                                    <td class='esd-stripe' align='center'>
                                        <table class='es-content-body' style='background-color: transparent;' width='600' cellspacing='0' cellpadding='0' bgcolor='#ffffff' align='center'>
                                            <tbody>
                                                <tr>
                                                    <td class='esd-structure es-p30t es-p30b es-p20r es-p20l' align='left'>
                                                        <table width='100%' cellspacing='0' cellpadding='0'>
                                                            <tbody>
                                                                <tr>
                                                                    <td class='esd-container-frame' width='560' valign='top' align='center'>
                                                                        <table width='100%' cellspacing='0' cellpadding='0'>
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td class='esd-block-image es-infoblock made_with' align='center' style='font-size:0; background-color: #199559; height: 100px'>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</body>

</html>";
        }

    }
}
