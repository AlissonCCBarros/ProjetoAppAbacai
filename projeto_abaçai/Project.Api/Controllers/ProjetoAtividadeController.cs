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
    public class ProjetoAtividadeController : ProjetoAtividadeControllerBase
    {
        public ProjetoAtividadeController(ProjetoAtividadeService service, ProjetoAtividadeRepository rep, ILoggerFactory logger, EnviromentInfo env)
            : base(service, rep, logger, env)
        { }

        [Authorize]
        [HttpGet("GetAtividadesProjeto")]
        public async Task<IActionResult> GetAtividadesProjeto([FromQuery]ProjetoAtividadeFilter filters)
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
        [Authorize]
        [HttpGet("GetTemNotificacao")]
        public async Task<IActionResult> GetTemNotificacao([FromQuery]ProjetoFilter filters)
        {
            var result = new HttpResult<dynamic>(this._logger, this._service);
            try
            {
                var searchResult = await this._rep.TemNotificaoProjeto(filters);
                return result.ReturnCustomResponse(searchResult);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "Projeto", filters);
            }
        }
    }
}
