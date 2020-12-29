using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Core.Data.Model;

namespace Project.Core.Data.Maps
{
    public class UsuarioMap : UsuarioMapBase
    {
        public UsuarioMap(EntityTypeBuilder<Usuario> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<Usuario> type)
        {
            type.HasOne(_ => _.Account).WithOne(_ => _.Usuario).HasPrincipalKey<Account>(_ => _.AccountId).IsRequired();
        }
    }
}
