using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Core.Data.Model;

namespace Project.Core.Data.Maps
{
    public class NotificacaoMap : NotificacaoMapBase
    {
        public NotificacaoMap(EntityTypeBuilder<Notificacao> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<Notificacao> type)
        {

        }
    }
}
