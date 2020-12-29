using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Core.Data.Model;

namespace Project.Core.Data.Maps
{
    public abstract class MatchMapBase
    {
        protected abstract void CustomConfig(EntityTypeBuilder<Match> type);

        public MatchMapBase(EntityTypeBuilder<Match> type)
        {
            type.ToTable("Match");

            type.Property(t => t.MatchId).HasColumnName("Id");


            type.Property(t => t.UsuarioId).HasColumnName("UsuarioId");
            type.Property(t => t.ProjetoAtividadeId).HasColumnName("ProjetoAtividadeId");
            type.Property(t => t.Aceito).HasColumnName("Aceito");
            type.Property(t => t.Ativo).HasColumnName("Ativo");
            type.Property(t => t.DataMatch).HasColumnName("DataMatch");
            type.Property(t => t.DataAceito).HasColumnName("DataAceito");
            type.Property(t => t.EhNotificado).HasColumnName("EhNotificado");


            type.HasKey(d => new { d.MatchId, }); 

			CustomConfig(type);

        }
    }
}
