using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Core.Data.Model;

namespace Project.Core.Data.Maps
{
    public abstract class UsuarioProjetoMapBase
    {
        protected abstract void CustomConfig(EntityTypeBuilder<UsuarioProjeto> type);

        public UsuarioProjetoMapBase(EntityTypeBuilder<UsuarioProjeto> type)
        {
            type.ToTable("UsuarioProjeto");

            type.Property(t => t.UsuarioProjetoId).HasColumnName("Id");


            type.Property(t => t.UsuarioId).HasColumnName("UsuarioId");
            type.Property(t => t.ProjetoId).HasColumnName("ProjetoId");


            type.HasKey(d => new { d.UsuarioProjetoId, }); 

			CustomConfig(type);

        }
    }
}
