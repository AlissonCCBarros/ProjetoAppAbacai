using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Core.Data.Model;

namespace Project.Core.Data.Maps
{
    public abstract class UsuarioMapBase
    {
        protected abstract void CustomConfig(EntityTypeBuilder<Usuario> type);

        public UsuarioMapBase(EntityTypeBuilder<Usuario> type)
        {
            type.ToTable("Usuario");

            type.Property(t => t.UsuarioId).HasColumnName("Id");


            type.Property(t => t.Nome).HasColumnName("Nome").HasColumnType("varchar(255)");
            type.Property(t => t.Apelido).HasColumnName("Apelido").HasColumnType("varchar(255)");
            type.Property(t => t.CPF_CNPJ).HasColumnName("CPF_CNPJ").HasColumnType("varchar(14)");
            type.Property(t => t.IE_RG).HasColumnName("IE_RG").HasColumnType("varchar(60)");
            type.Property(t => t.Telefone).HasColumnName("Telefone").HasColumnType("varchar(20)");
            type.Property(t => t.Celular).HasColumnName("Celular").HasColumnType("varchar(20)");
            type.Property(t => t.Email).HasColumnName("Email").HasColumnType("varchar(255)");
            type.Property(t => t.UserCreateDate).HasColumnName("UserCreateDate");
            type.Property(t => t.UserAlterDate).HasColumnName("UserAlterDate");
            type.Property(t => t.EnderecoId).HasColumnName("EnderecoId");
            type.Property(t => t.EhInstituicao).HasColumnName("EhInstituicao");
            type.Property(t => t.Foto).HasColumnName("Foto").HasColumnType("varchar(max)");


            type.HasKey(d => new { d.UsuarioId, }); 

			CustomConfig(type);

        }
    }
}
