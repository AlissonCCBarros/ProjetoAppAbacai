using Common.Orm;
using Project.Core.Filters;
using Project.Core.Data.Context;
using Project.Core.Data.Model;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Core.Data.Repository
{
    public class MatchRepositoryBase : Repository<Match>
    {
        public MatchRepositoryBase(DbContextCore ctx) : base(ctx)
        {

        }
				
		public virtual IEnumerable<dynamic> GetDataItems(MatchFilter filters)
        {
            var querybase = this.GetAll();
            return this.GetAll().Select(_ => new { Id = _.MatchId, Name = _.Aceito });
        }
		
        public virtual async Task<IEnumerable<dynamic>> GetDataListCustom(MatchFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetAll().Select(_ => new
            {
                Id = _.MatchId,
				Name = _.Aceito
            }));

            return querybase;
        }

        protected IQueryable<Match> SimpleFilters(MatchFilter filters, IQueryable<Match> queryBase)
        {
			var queryFilter = queryBase;
            
            if (filters.MatchId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.MatchId == filters.MatchId);
			}
            if (filters.UsuarioId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.UsuarioId == filters.UsuarioId);
			}
            if (filters.ProjetoAtividadeId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.ProjetoAtividadeId == filters.ProjetoAtividadeId);
			}
            if (filters.Aceito.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Aceito == filters.Aceito);
			}
            if (filters.Ativo.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Ativo == filters.Ativo);
			}
            if (filters.DataMatchStart.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.DataMatch >= filters.DataMatchStart );
			}
            if (filters.DataMatchEnd.IsSent()) 
			{ 
				filters.DataMatchEnd = filters.DataMatchEnd.AddDays(1).AddMilliseconds(-1);
				queryFilter = queryFilter.Where(_ => _.DataMatch <= filters.DataMatchEnd);
			}

            if (filters.DataAceitoStart.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.DataAceito != null && _.DataAceito.Value >= filters.DataAceitoStart.Value);
			}
            if (filters.DataAceitoEnd.IsSent()) 
			{ 
				filters.DataAceitoEnd = filters.DataAceitoEnd.Value.AddDays(1).AddMilliseconds(-1);
				queryFilter = queryFilter.Where(_ => _.DataAceito != null &&  _.DataAceito.Value <= filters.DataAceitoEnd);
			}

            if (filters.EhNotificado.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.EhNotificado == filters.EhNotificado);
			}


            return queryFilter;
        }
        
    }
}
