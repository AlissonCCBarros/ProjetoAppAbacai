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
using Common.Domain.Interfaces;

namespace Project.Core.Api.Controllers
{
    [Route("api/[controller]")]
    public class UsuarioController : UsuarioControllerBase
    {
        public UsuarioController(UsuarioService service, UsuarioRepository rep, ILoggerFactory logger, EnviromentInfo env)
            : base(service, rep, logger, env)
        { }

        [Authorize]
        [HttpGet("GetInfoUsuarioEndereco")]
        public async Task<IActionResult> GetInfoUsuarioEndereco([FromQuery]UsuarioFilter filters)
        {
            var result = new HttpResult<dynamic>(this._logger, this._service);
            try
            {
                var searchResult = await this._rep.GetDataListCustom(filters);
                return result.ReturnCustomResponse(searchResult);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "Usuario", filters);
            }
        }

        [Authorize]
        [HttpPut("SalvarEdicao")]
        public async Task<IActionResult> SalvarEdicao([FromBody]UsuarioDtoSave dto)
        {
            var result = new HttpResult<UsuarioDto>(this._logger, this._service);
            try
            {
                var returnModel = await this._service.SavePartial(dto);
                return result.ReturnCustomResponse(returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "Usuario", dto);
            }
        }
    }
}
