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
using Project.Core.Data.Model;

namespace Project.Core.Api.Controllers
{
    [Route("api/[controller]")]
    public class AtividadeController : AtividadeControllerBase
    {
        public AtividadeController(AtividadeService service, AtividadeRepository rep, ILoggerFactory logger, EnviromentInfo env)
            : base(service, rep, logger, env)
        {}


        [Authorize]
        [HttpPost("InserirAtividade")]
        public async Task<IActionResult> InserirAtividade([FromBody]AtividadeDtoSave dto)
        {
            var result = new HttpResult<AtividadeDto>(this._logger, this._service);
            try
            {
                var returnModel = await this._service.Save(dto);
                return result.ReturnCustomResponse(returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "Atividade", dto);
            }
        }



        /*[Authorize]
        [HttpPost("InserirAtividade")]
        public async Task<string> InserirAtividade([FromBody]AtividadeDtoSave dto)
        {
            var result = new HttpResult<AtividadeDto>(this._logger, this._service);
            try
            {
                IActionResult xx;
                //var returnModel = await this._service.Save(dto);
                if (dto.IsNotNull())
                {
                    Atividade objAtividade = new Atividade();
                    objAtividade.HabilidadeId = dto.HabilidadeId;
                    objAtividade.Descricao = dto.Descricao;
                    objAtividade.OdsId = dto.OdsId;
                    objAtividade.Nome = dto.Nome;
                    this._rep.Add(objAtividade);
                    this._rep.Commit();

                    if(model.AttributeBehavior == "")
            {
                
                

                return alvo;
            }

                }

                return "";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }*/
    }
}
