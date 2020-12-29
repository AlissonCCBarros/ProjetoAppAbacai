using Common.Domain.Interfaces;
using Common.Validation;
using System.Threading.Tasks;
using System.Collections.Generic;
using Project.Core.Dto;
using Project.Core.Data.Repository;
using Project.Core.Data.Model;
using Common.Domain.Model;
using System.Linq;
using Common.Domain.Enums;

namespace Project.Core.Services
{
    public class AccountService : AccountServiceBase
    {
        private ICripto _cripto;
        private UsuarioRepository _repUsuario;
        public AccountService(AccountRepository rep, ValidationContract validation, CurrentUser user, IUnitOfWork uow, ICripto cripto, UsuarioRepository repUsuario)
            : base(rep, validation, user, uow)
        {
            this._repUsuario = repUsuario;
            this._cripto = cripto;
        }

        protected override async Task<IEnumerable<TDS>> MapperDomainToDto<TDS>(IEnumerable<Account> models)
        {
            return await base.MapperDomainToDto<AccountDtoResult>(models) as IEnumerable<TDS>;
        }

        public override Account Save(Account model)
        {
            if (model.AttributeBehavior == "AlterandoAccount")
            {
                model.Password = this._cripto.Encrypt(model.Password, TypeCripto.Hash128);

                var account = this._rep.GetAll()
                     .Where(_ => _.AccountId == model.AccountId).FirstOrDefault();


                if (account.IsNotNull())
                {
                    account.Password = model.Password;
                    this._rep.Update(account);
                }
                else
                    this._validation.AddNotification("Account_Existe_Email", "Já existe uma conta registrada para esse e-mail.");

                return model;
            }
            else
            {
                var alvo = new Account();

                var _accountsEmail = this._rep.GetAll()
                     .Where(_ => _.Email == model.Email).Any();

                if (_accountsEmail)
                {
                    this._validation.AddNotification("Account_Existe_Email", "Já existe uma conta registrada para esse e-mail.");
                    return model;
                }

                var _accountsCpfCnpj = this._rep.GetAll()
                     .Where(_ => _.Usuario.CPF_CNPJ == model.CpfCnpj).Any();

                if (_accountsCpfCnpj)
                {
                    this._validation.AddNotification("Account_Existe_Cpf_Cnpj", "Já existe uma conta registrada para esse CPF/CNPJ.");
                    return model;
                }

                model.Password = this._cripto.Encrypt(model.Password, TypeCripto.Hash128);
                model.Admin = false;

                this._rep.Add(model);
                this._rep.Commit();

                var usuario = new Usuario()
                {
                    UsuarioId = model.AccountId,
                    CPF_CNPJ = model.CpfCnpj,
                    Email = model.Email,
                    Nome = model.Name,
                    Celular = model.Celular,
                    EhInstituicao = model.AttributeBehavior == "Instituicao" ? true : false
                };

                this._repUsuario.Add(usuario);
                this._repUsuario.Commit();

                return alvo;
            }

        }
    }
}
