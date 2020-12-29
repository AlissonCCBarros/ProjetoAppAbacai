using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Core.Data.Model;

namespace Project.Core.Data.Maps
{
    public class EnderecoMap : EnderecoMapBase
    {
        public EnderecoMap(EntityTypeBuilder<Endereco> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<Endereco> type)
        {

        }
    }
}
