using Common.Orm;
using Project.Core.Filters;
using Project.Core.Data.Context;
using Project.Core.Data.Model;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Core.Data.Repository
{
    public class HabilidadeRepositoryBase : Repository<Habilidade>
    {
        public HabilidadeRepositoryBase(DbContextCore ctx) : base(ctx)
        {

        }
				
		public virtual IEnumerable<dynamic> GetDataItems(HabilidadeFilter filters)
        {
            var querybase = this.GetAll();
            return this.GetAll().Select(_ => new { Id = _.HabilidadeId, Name = _.Nome });
        }
		
        public virtual async Task<IEnumerable<dynamic>> GetDataListCustom(HabilidadeFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetAll().Select(_ => new
            {
                Id = _.HabilidadeId,
				Name = _.Nome
            }));

            return querybase;
        }

        protected IQueryable<Habilidade> SimpleFilters(HabilidadeFilter filters, IQueryable<Habilidade> queryBase)
        {
			var queryFilter = queryBase;
            
            if (filters.HabilidadeId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.HabilidadeId == filters.HabilidadeId);
			}
            if (filters.Nome.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Nome.Contains(filters.Nome));
			}
            if (filters.Descricao.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Descricao.Contains(filters.Descricao));
			}


            return queryFilter;
        }
        
    }
}
