using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Core.Data.Model;

namespace Project.Core.Data.Maps
{
    public abstract class OdsMapBase
    {
        protected abstract void CustomConfig(EntityTypeBuilder<Ods> type);

        public OdsMapBase(EntityTypeBuilder<Ods> type)
        {
            type.ToTable("Ods");

            type.Property(t => t.OdsId).HasColumnName("Id");


            type.Property(t => t.Nome).HasColumnName("Nome").HasColumnType("varchar(255)");
            type.Property(t => t.Descricao).HasColumnName("Descricao").HasColumnType("varchar(255)");
            type.Property(t => t.ImageName).HasColumnName("ImageName").HasColumnType("varchar(250)");


            type.HasKey(d => new { d.OdsId, }); 

			CustomConfig(type);

        }
    }
}
