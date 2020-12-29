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
    public class ProjetoController : ProjetoControllerBase
    {
        public ProjetoController(ProjetoService service, ProjetoRepository rep, ILoggerFactory logger, EnviromentInfo env)
            : base(service, rep, logger, env)
        { }


        [Authorize]
        [HttpGet("GetUserProject")]
        public async Task<IActionResult> GetUserProject([FromQuery]ProjetoFilter filters)
        {
            var result = new HttpResult<dynamic>(this._logger, this._service);
            try
            {
                var searchResult = await this._rep.GetDataListCustom(filters);
                return result.ReturnCustomResponse(searchResult);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "Projeto", filters);
            }
        }

        [Authorize]
        [HttpGet("GetOdsDetalhes")]
        public async Task<IActionResult> GetOdsDetalhes([FromQuery]ProjetoFilter filters)
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
        [HttpPost("NovoProjeto")]
        public async Task<IActionResult> NovoProjeto([FromBody]ProjetoDtoSave dto)
        {
            var result = new HttpResult<ProjetoDto>(this._logger, this._service);
            try
            {
                if (dto.Nome != null)
                {
                    dto.DataInicio = Convert.ToDateTime(dto.Data);
                    

                    var returnModel = await this._service.Save(dto);
                    return result.ReturnCustomResponse(returnModel);

                }
                else
                {
                    dto.DataInicio = Convert.ToDateTime("aa");
                    return result.ReturnCustomResponse(dto);
                }
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "Projeto", dto);
            }

            
        }
    }
}
