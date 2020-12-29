using Common.Orm;
using Project.Core.Filters;
using Project.Core.Data.Context;
using Project.Core.Data.Model;
using System.Linq;
using Common.Domain.Model;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Project.Core.Data.Repository
{
	public class NotificacaoRepository : NotificacaoRepositoryBase
	{
		CurrentUser _user;
		public NotificacaoRepository(DbContextCore ctx, CurrentUser user) : base(ctx)
		{
			this._user = user;
		}

		public IQueryable<Notificacao> GetByFilters(NotificacaoFilter filters)
		{
			var querybase = this.GetAll();

			var queryFilter = this.SimpleFilters(filters, querybase);

			return queryFilter;
		}

		public Notificacao GetById(NotificacaoFilter filters)
		{
			var querybase = this.GetByFilters(filters);
			return querybase.SingleOrDefault();
		}

		public Notificacao GetByModel(Notificacao model)
		{
			return this.GetAll().Where(_ => _.NotificacaoId == model.NotificacaoId).SingleOrDefault();
		}

		public override async Task<IEnumerable<dynamic>> GetDataListCustom(NotificacaoFilter filters)
		{
			if(filters.AttributeBehavior == "GetNotificacaoUsuarioLogado")
			{
				var userId = this._user.GetUserId<int>();
				return this.GetAll().Where(_ => _.UsuarioId == userId);

			}
			return await base.GetDataListCustom(filters);
		}

	}
}
