using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Core.Data.Model;

namespace Project.Core.Data.Maps
{
    public abstract class HabilidadeMapBase
    {
        protected abstract void CustomConfig(EntityTypeBuilder<Habilidade> type);

        public HabilidadeMapBase(EntityTypeBuilder<Habilidade> type)
        {
            type.ToTable("Habilidade");

            type.Property(t => t.HabilidadeId).HasColumnName("Id");


            type.Property(t => t.Nome).HasColumnName("Nome").HasColumnType("varchar(255)");
            type.Property(t => t.Descricao).HasColumnName("Descricao").HasColumnType("varchar(255)");


            type.HasKey(d => new { d.HabilidadeId, }); 

			CustomConfig(type);

        }
    }
}
