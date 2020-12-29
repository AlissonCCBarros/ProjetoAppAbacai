using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Core.Data.Model;

namespace Project.Core.Data.Maps
{
    public class UsuarioProjetoMap : UsuarioProjetoMapBase
    {
        public UsuarioProjetoMap(EntityTypeBuilder<UsuarioProjeto> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<UsuarioProjeto> type)
        {

        }
    }
}
