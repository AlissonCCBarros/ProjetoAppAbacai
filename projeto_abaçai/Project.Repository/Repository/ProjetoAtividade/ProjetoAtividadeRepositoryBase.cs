using Common.Orm;
using Project.Core.Filters;
using Project.Core.Data.Context;
using Project.Core.Data.Model;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Core.Data.Repository
{
    public class ProjetoAtividadeRepositoryBase : Repository<ProjetoAtividade>
    {
        public ProjetoAtividadeRepositoryBase(DbContextCore ctx) : base(ctx)
        {

        }
				
		public virtual IEnumerable<dynamic> GetDataItems(ProjetoAtividadeFilter filters)
        {
            var querybase = this.GetAll();
            return this.GetAll().Select(_ => new { Id = _.ProjetoAtividadeId, Name = _.ProjetoAtividadeId });
        }
		
        public virtual async Task<IEnumerable<dynamic>> GetDataListCustom(ProjetoAtividadeFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetAll().Select(_ => new
            {
                Id = _.ProjetoAtividadeId,
				Name = _.ProjetoAtividadeId
            }));

            return querybase;
        }

        protected IQueryable<ProjetoAtividade> SimpleFilters(ProjetoAtividadeFilter filters, IQueryable<ProjetoAtividade> queryBase)
        {
			var queryFilter = queryBase;
            
            if (filters.ProjetoAtividadeId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.ProjetoAtividadeId == filters.ProjetoAtividadeId);
			}
            if (filters.ProjetoId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.ProjetoId == filters.ProjetoId);
			}
            if (filters.AtividadeId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.AtividadeId == filters.AtividadeId);
			}


            return queryFilter;
        }
        
    }
}
