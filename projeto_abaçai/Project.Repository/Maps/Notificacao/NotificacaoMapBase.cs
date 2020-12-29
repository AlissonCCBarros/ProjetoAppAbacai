using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Core.Data.Model;

namespace Project.Core.Data.Maps
{
    public abstract class NotificacaoMapBase
    {
        protected abstract void CustomConfig(EntityTypeBuilder<Notificacao> type);

        public NotificacaoMapBase(EntityTypeBuilder<Notificacao> type)
        {
            type.ToTable("Notificacao");

            type.Property(t => t.NotificacaoId).HasColumnName("Id");


            type.Property(t => t.Titulo).HasColumnName("Titulo").HasColumnType("varchar(255)");
            type.Property(t => t.Descricao).HasColumnName("Descricao").HasColumnType("varchar(255)");
            type.Property(t => t.UsuarioId).HasColumnName("UsuarioId");
            type.Property(t => t.EhAceito).HasColumnName("EhAceito");
            type.Property(t => t.EhNotificado).HasColumnName("EhNotificado");


            type.HasKey(d => new { d.NotificacaoId, }); 

			CustomConfig(type);

        }
    }
}
