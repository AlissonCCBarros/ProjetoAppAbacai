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

namespace Project.Core.Api.Controllers
{
    [Route("api/[controller]")]
    public class UsuarioProjetoAtividadeController : UsuarioProjetoAtividadeControllerBase
    {
        public UsuarioProjetoAtividadeController(UsuarioProjetoAtividadeService service, UsuarioProjetoAtividadeRepository rep, ILoggerFactory logger, EnviromentInfo env)
            : base(service, rep, logger, env)
        { }

        [Authorize]
        [HttpGet("GetOdsDetalhes")]
        public async Task<IActionResult> GetOdsDetalhes([FromQuery]UsuarioProjetoAtividadeFilter filters)
        {
            var result = new HttpResult<dynamic>(this._logger, this._service);
            try
            {
                var searchResult = await this._rep.GetDataListCustom(filters);
                return result.ReturnCustomResponse(searchResult);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "ProjetoAtividade", filters);
            }
        }
    }
}
