using Common.API;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using Project.Core.Services;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Common.Domain.Base;
using Project.Dto.Custom;
using Project.Services.Helper;

namespace Project.Core.Api.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {

        private readonly UserService _userService;
        private readonly ILogger _logger;

        public UserController(UserService userService, ILoggerFactory logger)
        {
            this._userService = userService;
            this._logger = logger.CreateLogger<UserController>();
            this._logger.LogInformation("AccountController init success");
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Post([FromBody]UserDto dto, [FromServices]SigningConfigurations signingConfigurations)
        {
            var result = new HttpResult<UserDto>(this._logger);
            try
            {
                var user = this._userService.GetUser(dto, signingConfigurations);
                return result.ReturnCustomResponse(user);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "Seed - CurrentUser");
            }

        }

        [AllowAnonymous]
        [HttpPost("ForgottenPassword")]
        public IActionResult ForgottenPassword([FromBody]UserDto dto)
        {
            var result = new HttpResult<dynamic>(this._logger);
            try
            {
                var user = this._userService.ForgottenPassword(dto);
                return result.ReturnCustomResponse(user);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "Seed - CurrentUser");
            }

        }

    }
}
