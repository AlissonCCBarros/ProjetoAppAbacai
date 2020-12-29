using Common.Orm;
using Project.Core.Filters;
using Project.Core.Data.Context;
using Project.Core.Data.Model;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Core.Data.Repository
{
    public class NotificacaoRepositoryBase : Repository<Notificacao>
    {
        public NotificacaoRepositoryBase(DbContextCore ctx) : base(ctx)
        {

        }
				
		public virtual IEnumerable<dynamic> GetDataItems(NotificacaoFilter filters)
        {
            var querybase = this.GetAll();
            return this.GetAll().Select(_ => new { Id = _.NotificacaoId, Name = _.Titulo });
        }
		
        public virtual async Task<IEnumerable<dynamic>> GetDataListCustom(NotificacaoFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetAll().Select(_ => new
            {
                Id = _.NotificacaoId,
				Name = _.Titulo
            }));

            return querybase;
        }

        protected IQueryable<Notificacao> SimpleFilters(NotificacaoFilter filters, IQueryable<Notificacao> queryBase)
        {
			var queryFilter = queryBase;
            
            if (filters.NotificacaoId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.NotificacaoId == filters.NotificacaoId);
			}
            if (filters.Titulo.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Titulo.Contains(filters.Titulo));
			}
            if (filters.Descricao.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Descricao.Contains(filters.Descricao));
			}
            if (filters.UsuarioId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.UsuarioId != null && _.UsuarioId.Value == filters.UsuarioId);
			}
            if (filters.EhAceito.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.EhAceito == filters.EhAceito);
			}
            if (filters.EhNotificado.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.EhNotificado == filters.EhNotificado);
			}


            return queryFilter;
        }
        
    }
}
