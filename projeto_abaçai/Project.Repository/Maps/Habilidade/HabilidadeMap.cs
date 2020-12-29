using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Core.Data.Model;

namespace Project.Core.Data.Maps
{
    public class HabilidadeMap : HabilidadeMapBase
    {
        public HabilidadeMap(EntityTypeBuilder<Habilidade> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<Habilidade> type)
        {

        }
    }
}
