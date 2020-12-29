using Common.Domain.Interfaces;
using Common.Orm;
using Common.Validation;
using Microsoft.Extensions.DependencyInjection;
using Project.Core.Services;
using Project.Core.Data.Context;
using Project.Core.Data.Repository;

namespace Project.Core.Api.Config
{
    public static partial class ConfigContainerCore
    {
        public static void Config(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork<DbContextCore>>();

            services.AddScoped<ValidationContract>();

            services.AddScoped<AccountRepository>();
            services.AddScoped<AccountService>();
            services.AddScoped<UsuarioRepository>();
            services.AddScoped<UsuarioService>();
            services.AddScoped<OdsRepository>();
            services.AddScoped<OdsService>();
            services.AddScoped<ProjetoRepository>();
            services.AddScoped<ProjetoService>();
            services.AddScoped<AtividadeRepository>();
            services.AddScoped<AtividadeService>();
            services.AddScoped<ProjetoAtividadeRepository>();
            services.AddScoped<ProjetoAtividadeService>();
            services.AddScoped<UsuarioProjetoAtividadeRepository>();
            services.AddScoped<UsuarioProjetoAtividadeService>();
            services.AddScoped<EnderecoRepository>();
            services.AddScoped<EnderecoService>();
            services.AddScoped<MatchRepository>();
            services.AddScoped<MatchService>();
            services.AddScoped<NotificacaoRepository>();
            services.AddScoped<NotificacaoService>();
            services.AddScoped<HabilidadeRepository>();
            services.AddScoped<HabilidadeService>();
            services.AddScoped<UsuarioHabilidadeRepository>();
            services.AddScoped<UsuarioHabilidadeService>();

            
            RegisterOtherComponents(services);
        }
    }
}
