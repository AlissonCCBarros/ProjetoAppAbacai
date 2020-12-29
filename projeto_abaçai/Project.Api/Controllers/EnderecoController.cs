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
	public class EnderecoController : EnderecoControllerBase
	{
		public EnderecoController(EnderecoService service, EnderecoRepository rep, ILoggerFactory logger, EnviromentInfo env)
			: base(service, rep, logger, env)
		{ }

		[HttpGet("GetEnderecoProjeto")]
		public new async Task<IActionResult> Get([FromQuery]EnderecoFilter filters)
		{
			var result = new HttpResult<EnderecoDto>(this._logger, this._service);
			try
			{
				var returnModel = await this._service.GetById(filters);
				return result.ReturnCustomResponse(returnModel);
			}
			catch (Exception ex)
			{
				return result.ReturnCustomException(ex, "Endereco");
			}
		}

	}
}
