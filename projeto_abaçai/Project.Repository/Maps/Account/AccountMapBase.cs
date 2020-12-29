using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Core.Data.Model;

namespace Project.Core.Data.Maps
{
    public abstract class AccountMapBase
    {
        protected abstract void CustomConfig(EntityTypeBuilder<Account> type);

        public AccountMapBase(EntityTypeBuilder<Account> type)
        {
            type.ToTable("Account");

            type.Property(t => t.AccountId).HasColumnName("Id");


            type.Property(t => t.Name).HasColumnName("Name").HasColumnType("varchar(255)");
            type.Property(t => t.Email).HasColumnName("Email").HasColumnType("varchar(255)");
            type.Property(t => t.Password).HasColumnName("Password").HasColumnType("varchar(255)");
            type.Property(t => t.Admin).HasColumnName("Admin");


            type.HasKey(d => new { d.AccountId, }); 

			CustomConfig(type);

        }
    }
}
