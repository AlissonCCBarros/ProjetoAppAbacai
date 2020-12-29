using Common.Orm;
using Project.Core.Filters;
using Project.Core.Data.Context;
using Project.Core.Data.Model;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Core.Data.Repository
{
    public class AtividadeRepositoryBase : Repository<Atividade>
    {
        public AtividadeRepositoryBase(DbContextCore ctx) : base(ctx)
        {

        }
				
		public virtual IEnumerable<dynamic> GetDataItems(AtividadeFilter filters)
        {
            var querybase = this.GetAll();
            return this.GetAll().Select(_ => new { Id = _.AtividadeId, Name = _.Nome });
        }
		
        public virtual async Task<IEnumerable<dynamic>> GetDataListCustom(AtividadeFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetAll().Select(_ => new
            {
                Id = _.AtividadeId,
				Name = _.Nome
            }));

            return querybase;
        }

        protected IQueryable<Atividade> SimpleFilters(AtividadeFilter filters, IQueryable<Atividade> queryBase)
        {
			var queryFilter = queryBase;
            
            if (filters.AtividadeId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.AtividadeId == filters.AtividadeId);
			}
            if (filters.Nome.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Nome.Contains(filters.Nome));
			}
            if (filters.Descricao.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Descricao.Contains(filters.Descricao));
			}
            if (filters.OdsId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.OdsId == filters.OdsId);
			}
            if (filters.HabilidadeId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.HabilidadeId == filters.HabilidadeId);
			}


            return queryFilter;
        }
        
    }
}
