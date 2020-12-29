using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Core.Data.Model;

namespace Project.Core.Data.Maps
{
    public abstract class EnderecoMapBase
    {
        protected abstract void CustomConfig(EntityTypeBuilder<Endereco> type);

        public EnderecoMapBase(EntityTypeBuilder<Endereco> type)
        {
            type.ToTable("Endereco");

            type.Property(t => t.EnderecoId).HasColumnName("Id");


            type.Property(t => t.CEP).HasColumnName("CEP").HasColumnType("varchar(9)");
            type.Property(t => t.Rua).HasColumnName("Rua").HasColumnType("varchar(255)");
            type.Property(t => t.Numero).HasColumnName("Numero");
            type.Property(t => t.Bairro).HasColumnName("Bairro").HasColumnType("varchar(255)");
            type.Property(t => t.Cidade).HasColumnName("Cidade").HasColumnType("varchar(255)");
            type.Property(t => t.Estado).HasColumnName("Estado").HasColumnType("varchar(2)");


            type.HasKey(d => new { d.EnderecoId, }); 

			CustomConfig(type);

        }
    }
}
