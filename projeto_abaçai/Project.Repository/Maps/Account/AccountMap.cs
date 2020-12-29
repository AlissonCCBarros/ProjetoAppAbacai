using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Core.Data.Model;

namespace Project.Core.Data.Maps
{
    public class AccountMap : AccountMapBase
    {
        public AccountMap(EntityTypeBuilder<Account> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<Account> type)
        {

        }
    }
}
