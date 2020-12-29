using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Core.Data.Model;

namespace Project.Core.Data.Maps
{
    public class ProjetoMap : ProjetoMapBase
    {
        public ProjetoMap(EntityTypeBuilder<Projeto> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<Projeto> type)
        {

        }
    }
}
