using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Core.Data.Model;

namespace Project.Core.Data.Maps
{
    public abstract class ProjetoMapBase
    {
        protected abstract void CustomConfig(EntityTypeBuilder<Projeto> type);

        public ProjetoMapBase(EntityTypeBuilder<Projeto> type)
        {
            type.ToTable("Projeto");

            type.Property(t => t.ProjetoId).HasColumnName("Id");


            type.Property(t => t.Nome).HasColumnName("Nome").HasColumnType("varchar(255)");
            type.Property(t => t.Descricao).HasColumnName("Descricao").HasColumnType("varchar(255)");
            type.Property(t => t.DataInicio).HasColumnName("DataInicio");
            type.Property(t => t.DataFim).HasColumnName("DataFim");
            type.Property(t => t.EnderecoId).HasColumnName("EnderecoId");
            type.Property(t => t.UsuarioId).HasColumnName("UsuarioId");
            type.Property(t => t.Foto).HasColumnName("Foto").HasColumnType("varchar(250)");


            type.HasKey(d => new { d.ProjetoId, }); 

			CustomConfig(type);

        }
    }
}
