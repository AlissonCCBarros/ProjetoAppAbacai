using Common.API;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using Project.Core.Services;
using Project.Core.Dto;
using Project.Core.Filters;
using Project.Core.Data.Repository;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Common.Domain.Base;
using Common.Domain.Model;

namespace Project.Core.Api.Controllers
{
    [Route("api/[controller]")]
    public class UsuarioHabilidadeController : UsuarioHabilidadeControllerBase
    {
        CurrentUser _user;
        public UsuarioHabilidadeController(UsuarioHabilidadeService service, UsuarioHabilidadeRepository rep, CurrentUser user, ILoggerFactory logger, EnviromentInfo env)
            : base(service, rep, logger, env)
        {
            this._user = user;
        }


        [Authorize]
        [HttpPost("InserirHabilidade")]
        public async Task<IActionResult> InserirHabilidade([FromBody]UsuarioHabilidadeDtoSave dto)
        {
            var result = new HttpResult<UsuarioHabilidadeDto>(this._logger, this._service);
            UsuarioHabilidadeDtoSave obj;
            UsuarioHabilidadeDtoSave returnModel = null;
            try
            {
                foreach (var item in dto.UsuarioHabilidades)
                {
                    obj = new UsuarioHabilidadeDtoSave();
                    obj.HabilidadeId = Convert.ToInt32(item);
                    obj.UsuarioId = _user.GetUserId();
                    returnModel = await this._service.Save(obj);
                }
                //var returnModel = await this._service.Save(dto);
                return result.ReturnCustomResponse(returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "UsuarioHabilidade", dto);
            }
        }
    }
}
