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
    public class MatchControllerBase : Controller
    {
        protected readonly MatchService _service;
        protected readonly MatchRepository _rep;
        protected readonly ILogger _logger;
        private readonly EnviromentInfo _env;

        public MatchControllerBase(MatchService service, MatchRepository rep, ILoggerFactory logger, EnviromentInfo env)
        {
            this._service = service;
            this._rep = rep;
            this._logger = logger.CreateLogger<MatchController>();
            this._env = env;
        }

        #region Principals
		
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]MatchFilter filters)
        {
            var result = new HttpResult<MatchDto>(this._logger, this._service);
            try
            {
                var searchResult = await this._service.GetByFiltersPaging(filters);
                return result.ReturnCustomResponse(searchResult);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "Match", filters);
            }
        }


        [Authorize]
		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id, [FromQuery]MatchFilter filters)
		{
			var result = new HttpResult<MatchDto>(this._logger, this._service);
			try
			{
				filters.MatchId = id;
				var returnModel = await this._service.GetById(filters);
				return result.ReturnCustomResponse(returnModel);
			}
			catch (Exception ex)
			{
				return result.ReturnCustomException(ex, "Match", id);
			}
		}

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]MatchDtoSave dto)
        {
            var result = new HttpResult<MatchDto>(this._logger, this._service);
            try
            {
                var returnModel = await this._service.Save(dto);
                return result.ReturnCustomResponse(returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "Match", dto);
            }
        }
		
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]MatchDtoSave dto)
        {
            var result = new HttpResult<MatchDto>(this._logger, this._service);
            try
            {
                var returnModel = await this._service.SavePartial(dto);
                return result.ReturnCustomResponse(returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "Match", dto);
            }
        }
		
        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> Delete(MatchDto dto)
        {
            var result = new HttpResult<MatchDto>(this._logger, this._service);
            try
            {
                await this._service.Remove(dto);
                return result.ReturnCustomResponse(dto);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "Match", dto);
            }
        }

        #endregion

		#region Others

		
        [Authorize]
        [HttpGet("DataItems")]
        public async Task<IActionResult> DataItems([FromQuery]MatchFilter filters)
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
