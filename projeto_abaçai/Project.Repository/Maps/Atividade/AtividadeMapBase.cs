using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Core.Data.Model;

namespace Project.Core.Data.Maps
{
    public abstract class AtividadeMapBase
    {
        protected abstract void CustomConfig(EntityTypeBuilder<Atividade> type);

        public AtividadeMapBase(EntityTypeBuilder<Atividade> type)
        {
            type.ToTable("Atividade");

            type.Property(t => t.AtividadeId).HasColumnName("Id");


            type.Property(t => t.Nome).HasColumnName("Nome").HasColumnType("varchar(255)");
            type.Property(t => t.Descricao).HasColumnName("Descricao").HasColumnType("varchar(255)");
            type.Property(t => t.OdsId).HasColumnName("OdsId");
            type.Property(t => t.HabilidadeId).HasColumnName("HabilidadeId");


            type.HasKey(d => new { d.AtividadeId, }); 

			CustomConfig(type);

        }
    }
}
