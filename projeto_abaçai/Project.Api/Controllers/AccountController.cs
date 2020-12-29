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
    public class AccountController : AccountControllerBase
    {
        public AccountController(AccountService service, AccountRepository rep, ILoggerFactory logger, EnviromentInfo env)
            : base(service, rep, logger, env)
        { }


        [AllowAnonymous]
        [HttpPost("NewAccount")]
        public async Task<IActionResult> NewAccount([FromBody]AccountDtoSave dto)
        {
            var result = new HttpResult<AccountDto>(this._logger, this._service);
            try
            {
                var returnModel = await this._service.Save(dto);
                return result.ReturnCustomResponse(returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "Account", dto);
            }
        }
    }
}
