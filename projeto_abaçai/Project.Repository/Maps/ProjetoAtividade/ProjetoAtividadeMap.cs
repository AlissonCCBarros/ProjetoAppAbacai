using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Core.Data.Model;

namespace Project.Core.Data.Maps
{
    public class ProjetoAtividadeMap : ProjetoAtividadeMapBase
    {
        public ProjetoAtividadeMap(EntityTypeBuilder<ProjetoAtividade> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<ProjetoAtividade> type)
        {

        }
    }
}
