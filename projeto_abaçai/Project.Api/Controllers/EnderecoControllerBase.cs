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
    public class EnderecoControllerBase : Controller
    {
        protected readonly EnderecoService _service;
        protected readonly EnderecoRepository _rep;
        protected readonly ILogger _logger;
        private readonly EnviromentInfo _env;

        public EnderecoControllerBase(EnderecoService service, EnderecoRepository rep, ILoggerFactory logger, EnviromentInfo env)
        {
            this._service = service;
            this._rep = rep;
            this._logger = logger.CreateLogger<EnderecoController>();
            this._env = env;
        }

        #region Principals
		
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]EnderecoFilter filters)
        {
            var result = new HttpResult<EnderecoDto>(this._logger, this._service);
            try
            {
                var searchResult = await this._service.GetByFiltersPaging(filters);
                return result.ReturnCustomResponse(searchResult);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "Endereco", filters);
            }
        }


        [Authorize]
		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id, [FromQuery]EnderecoFilter filters)
		{
			var result = new HttpResult<EnderecoDto>(this._logger, this._service);
			try
			{
				filters.EnderecoId = id;
				var returnModel = await this._service.GetById(filters);
				return result.ReturnCustomResponse(returnModel);
			}
			catch (Exception ex)
			{
				return result.ReturnCustomException(ex, "Endereco", id);
			}
		}

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]EnderecoDtoSave dto)
        {
            var result = new HttpResult<EnderecoDto>(this._logger, this._service);
            try
            {
                var returnModel = await this._service.Save(dto);
                return result.ReturnCustomResponse(returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "Endereco", dto);
            }
        }
		
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]EnderecoDtoSave dto)
        {
            var result = new HttpResult<EnderecoDto>(this._logger, this._service);
            try
            {
                var returnModel = await this._service.SavePartial(dto);
                return result.ReturnCustomResponse(returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "Endereco", dto);
            }
        }
		
        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> Delete(EnderecoDto dto)
        {
            var result = new HttpResult<EnderecoDto>(this._logger, this._service);
            try
            {
                await this._service.Remove(dto);
                return result.ReturnCustomResponse(dto);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "Endereco", dto);
            }
        }

        #endregion

		#region Others

		
        [Authorize]
        [HttpGet("DataItems")]
        public async Task<IActionResult> DataItems([FromQuery]EnderecoFilter filters)
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
