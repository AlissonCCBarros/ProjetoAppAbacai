using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Core.Data.Model;

namespace Project.Core.Data.Maps
{
    public class MatchMap : MatchMapBase
    {
        public MatchMap(EntityTypeBuilder<Match> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<Match> type)
        {

        }
    }
}
