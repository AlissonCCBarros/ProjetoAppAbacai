using Project.Services.Helper;
using Common.API.Extensions;
using Common.Domain.Base;
using Common.Domain.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Project.Core.Api.Config;
using Project.Core.Data.Context;
using Project.Core.Data.Model;
using Project.Core.Services.Config;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace Project.Api
{
    public class Startup
    {
        private readonly IHostingEnvironment _env;

        public IConfigurationRoot Configuration { get; }
        public User user { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
            _env = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DbContextCore>(options =>
                     options.UseSqlServer(Configuration.GetSection("EFCoreConnStrings:Core").Value));

            var signingConfigurations = new SigningConfigurations();
            services.AddSingleton(signingConfigurations);

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAnyOrigin",
                    builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod());
            });

            services.Configure<ConfigEmailBase>(Configuration.GetSection("ConfigEmail"));
            services.Configure<ConfigConnectionBase>(Configuration.GetSection("EFCoreConnStrings"));
            services.Configure<ConfigSettingsBase>(Configuration.GetSection("ConfigSettings"));

            services.AddSingleton<IConfiguration>(Configuration);
            services.AddSingleton(new EnviromentInfo
            {
                RootPath = this._env.ContentRootPath
            });

            ConfigContainerCore.Config(services);

            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions =>
            {
                var paramsValidation = bearerOptions.TokenValidationParameters;
                paramsValidation.IssuerSigningKey = signingConfigurations.Key;

                // Valida a assinatura de um token recebido
                paramsValidation.ValidateIssuerSigningKey = false;

                // Verifica se um token recebido ainda é válido
                paramsValidation.ValidateAudience = false;
                paramsValidation.ValidateIssuer = false;
                paramsValidation.ValidateLifetime = true;

                // Tempo de tolerância para a expiração de um token (utilizado
                // caso haja problemas de sincronismo de horário entre diferentes
                // computadores envolvidos no processo de comunicação)
                paramsValidation.ClockSkew = TimeSpan.Zero;
            });

            // Ativa o uso do token como forma de autorizar o acesso
            // a recursos deste projeto
            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
                    .RequireAuthenticatedUser().Build());
            });



            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IServiceProvider serviceProvider)
        {
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(new CultureInfo("pt-BR")),
                SupportedCultures = new List<CultureInfo>
                {
                    new CultureInfo("pt-BR")
                },
                SupportedUICultures = new List<CultureInfo>
                {
                    new CultureInfo("pt")
                }
            });

            app.UseAuthentication();

            app.AddTokenMiddleware();

            app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            app.UseCors("AllowAnyOrigin");

            app.UseMvc();

            AutoMapperConfigCore.RegisterMappings();
        }
    }
}


public class DecimalBinderProvider : IModelBinderProvider
{
    public IModelBinder GetBinder(ModelBinderProviderContext context)
    {
        if (context == null)
        {
            throw new ArgumentNullException(nameof(context));
        }

        if (context.Metadata.ModelType == typeof(decimal))
        {
            return new BinderTypeModelBinder(typeof(DecimalBinder));
        }
        if (context.Metadata.ModelType == typeof(decimal?))
        {
            return new BinderTypeModelBinder(typeof(DecimalBinder));
        }

        return null;
    }
}

public class DecimalBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        if (bindingContext == null)
        {
            throw new ArgumentNullException(nameof(bindingContext));

        }
        var valueResult = bindingContext.ValueProvider
             .GetValue(bindingContext.ModelName);

        if (valueResult == ValueProviderResult.None)
        {
            return Task.CompletedTask;
        }

        object actualValue = null;
        var culture = CultureInfo.CurrentCulture;

        if (valueResult.FirstValue != string.Empty)
        {
            try
            {
                // Try with your local culture
                actualValue = Convert.ToDecimal(valueResult.FirstValue, culture);
            }
            catch (FormatException)
            {
                try
                {
                    // Try with your invariant culture
                    actualValue = Convert.ToDecimal(valueResult.FirstValue, CultureInfo.InvariantCulture);
                }
                catch (FormatException)
                {
                    bindingContext.ModelState.TryAddModelError(
                                bindingContext.ModelName,
                                "You should provide a valid decimal value");

                    return Task.CompletedTask;
                }
            }
        }

        bindingContext.Result = ModelBindingResult.Success(actualValue);

        return Task.CompletedTask;
    }
}