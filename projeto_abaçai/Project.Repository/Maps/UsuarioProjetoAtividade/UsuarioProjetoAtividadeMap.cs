using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Core.Data.Model;

namespace Project.Core.Data.Maps
{
    public class UsuarioProjetoAtividadeMap : UsuarioProjetoAtividadeMapBase
    {
        public UsuarioProjetoAtividadeMap(EntityTypeBuilder<UsuarioProjetoAtividade> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<UsuarioProjetoAtividade> type)
        {

        }
    }
}
