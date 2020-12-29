using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Core.Data.Model;

namespace Project.Core.Data.Maps
{
    public class OdsMap : OdsMapBase
    {
        public OdsMap(EntityTypeBuilder<Ods> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<Ods> type)
        {

        }
    }
}
