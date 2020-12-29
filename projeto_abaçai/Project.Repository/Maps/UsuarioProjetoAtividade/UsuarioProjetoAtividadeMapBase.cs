using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Core.Data.Model;

namespace Project.Core.Data.Maps
{
    public abstract class UsuarioProjetoAtividadeMapBase
    {
        protected abstract void CustomConfig(EntityTypeBuilder<UsuarioProjetoAtividade> type);

        public UsuarioProjetoAtividadeMapBase(EntityTypeBuilder<UsuarioProjetoAtividade> type)
        {
            type.ToTable("UsuarioProjetoAtividade");

            type.Property(t => t.UsuarioProjetoAtividadeId).HasColumnName("Id");


            type.Property(t => t.UsuarioId).HasColumnName("UsuarioId");
            type.Property(t => t.ProjetoAtividadeId).HasColumnName("ProjetoAtividadeId");
            type.Property(t => t.Avaliacao).HasColumnName("Avaliacao");


            type.HasKey(d => new { d.UsuarioProjetoAtividadeId, }); 

			CustomConfig(type);

        }
    }
}
