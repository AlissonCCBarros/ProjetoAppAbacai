using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Core.Data.Model;

namespace Project.Core.Data.Maps
{
    public abstract class ProjetoAtividadeMapBase
    {
        protected abstract void CustomConfig(EntityTypeBuilder<ProjetoAtividade> type);

        public ProjetoAtividadeMapBase(EntityTypeBuilder<ProjetoAtividade> type)
        {
            type.ToTable("ProjetoAtividade");

            type.Property(t => t.ProjetoAtividadeId).HasColumnName("Id");


            type.Property(t => t.ProjetoId).HasColumnName("ProjetoId");
            type.Property(t => t.AtividadeId).HasColumnName("AtividadeId");


            type.HasKey(d => new { d.ProjetoAtividadeId, }); 

			CustomConfig(type);

        }
    }
}
