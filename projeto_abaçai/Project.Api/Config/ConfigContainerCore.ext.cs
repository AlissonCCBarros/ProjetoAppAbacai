using Project.Core.Services;
using Common.Cripto;
using Common.Domain.Interfaces;
using Common.Domain.Model;
using Microsoft.Extensions.DependencyInjection;
using Common.Mail;

namespace Project.Core.Api.Config
{
    public static partial class ConfigContainerCore
    {
        public static void RegisterOtherComponents(IServiceCollection services)
        {
            services.AddScoped<IEmail, Email>();

            services.AddScoped<CurrentUser>();

            services.AddScoped<ICripto, Cripto>();

            services.AddScoped<UserService>();
        }
    }
}
