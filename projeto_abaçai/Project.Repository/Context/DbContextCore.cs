using Microsoft.EntityFrameworkCore;
using Project.Core.Data.Maps;
using Project.Core.Data.Model;

namespace Project.Core.Data.Context
{
    public class DbContextCore: DbContext
    {

        public DbContextCore(DbContextOptions<DbContextCore> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new AccountMap(modelBuilder.Entity<Account>());
            new UsuarioMap(modelBuilder.Entity<Usuario>());
            new OdsMap(modelBuilder.Entity<Ods>());
            new ProjetoMap(modelBuilder.Entity<Projeto>());
            new AtividadeMap(modelBuilder.Entity<Atividade>());
            new ProjetoAtividadeMap(modelBuilder.Entity<ProjetoAtividade>());
            new UsuarioProjetoAtividadeMap(modelBuilder.Entity<UsuarioProjetoAtividade>());
            new EnderecoMap(modelBuilder.Entity<Endereco>());
            new MatchMap(modelBuilder.Entity<Match>());
            new NotificacaoMap(modelBuilder.Entity<Notificacao>());
            new HabilidadeMap(modelBuilder.Entity<Habilidade>());
            new UsuarioHabilidadeMap(modelBuilder.Entity<UsuarioHabilidade>());

        }

    }
}