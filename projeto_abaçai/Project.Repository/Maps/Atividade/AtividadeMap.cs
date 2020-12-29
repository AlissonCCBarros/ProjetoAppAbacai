using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Core.Data.Model;

namespace Project.Core.Data.Maps
{
    public class AtividadeMap : AtividadeMapBase
    {
        public AtividadeMap(EntityTypeBuilder<Atividade> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<Atividade> type)
        {

        }
    }
}
