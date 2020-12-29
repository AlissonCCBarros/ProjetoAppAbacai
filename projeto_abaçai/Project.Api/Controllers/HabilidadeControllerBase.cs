using Common.API;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project.Core.Services;
using Project.Core.Dto;
using Project.Core.Filters;
using Project.Core.Data.Repository;
using System;
using System.Threading.Tasks;
using Common.Domain.Base;
using Microsoft.AspNetCore.Authorization;

namespace Project.Core.Api.Controllers
{
    public class HabilidadeControllerBase : Controller
    {
        protected readonly HabilidadeService _service;
        protected readonly HabilidadeRepository _rep;
        protected readonly ILogger _logger;
        private readonly EnviromentInfo _env;

        public HabilidadeControllerBase(HabilidadeService service, HabilidadeRepository rep, ILoggerFactory logger, EnviromentInfo env)
        {
            this._service = service;
            this._rep = rep;
            this._logger = logger.CreateLogger<HabilidadeController>();
            this._env = env;
        }

        #region Principals
		
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]HabilidadeFilter filters)
        {
            var result = new HttpResult<HabilidadeDto>(this._logger, this._service);
            try
            {
                var searchResult = await this._service.GetByFiltersPaging(filters);
                return result.ReturnCustomResponse(searchResult);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "Habilidade", filters);
            }
        }


        [Authorize]
		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id, [FromQuery]HabilidadeFilter filters)
		{
			var result = new HttpResult<HabilidadeDto>(this._logger, this._service);
			try
			{
				filters.HabilidadeId = id;
				var returnModel = await this._service.GetById(filters);
				return result.ReturnCustomResponse(returnModel);
			}
			catch (Exception ex)
			{
				return result.ReturnCustomException(ex, "Habilidade", id);
			}
		}

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]HabilidadeDtoSave dto)
        {
            var result = new HttpResult<HabilidadeDto>(this._logger, this._service);
            try
            {
                var returnModel = await this._service.Save(dto);
                return result.ReturnCustomResponse(returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "Habilidade", dto);
            }
        }
		
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]HabilidadeDtoSave dto)
        {
            var result = new HttpResult<HabilidadeDto>(this._logger, this._service);
            try
            {
                var returnModel = await this._service.SavePartial(dto);
                return result.ReturnCustomResponse(returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "Habilidade", dto);
            }
        }
		
        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> Delete(HabilidadeDto dto)
        {
            var result = new HttpResult<HabilidadeDto>(this._logger, this._service);
            try
            {
                await this._service.Remove(dto);
                return result.ReturnCustomResponse(dto);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "Habilidade", dto);
            }
        }

        #endregion

		#region Others

		
        [Authorize]
        [HttpGet("DataItems")]
        public async Task<IActionResult> DataItems([FromQuery]HabilidadeFilter filters)
        {
            var result = new HttpResult<dynamic>(this._logger, this._service);
            try
            {
                var items = await this._service.GetDataItems(filters);
                return result.ReturnCustomResponse(items);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "Assinatura", filters);
            }
        }

        #endregion

    }
}
