using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Core.Data.Model;

namespace Project.Core.Data.Maps
{
    public abstract class UsuarioHabilidadeMapBase
    {
        protected abstract void CustomConfig(EntityTypeBuilder<UsuarioHabilidade> type);

        public UsuarioHabilidadeMapBase(EntityTypeBuilder<UsuarioHabilidade> type)
        {
            type.ToTable("UsuarioHabilidade");

            type.Property(t => t.UsuarioHabilidadeId).HasColumnName("Id");


            type.Property(t => t.UsuarioId).HasColumnName("UsuarioId");
            type.Property(t => t.HabilidadeId).HasColumnName("HabilidadeId");


            type.HasKey(d => new { d.UsuarioHabilidadeId, }); 

			CustomConfig(type);

        }
    }
}
