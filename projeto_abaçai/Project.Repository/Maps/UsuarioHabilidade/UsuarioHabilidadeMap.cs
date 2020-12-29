using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Core.Data.Model;

namespace Project.Core.Data.Maps
{
    public class UsuarioHabilidadeMap : UsuarioHabilidadeMapBase
    {
        public UsuarioHabilidadeMap(EntityTypeBuilder<UsuarioHabilidade> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<UsuarioHabilidade> type)
        {

        }
    }
}
