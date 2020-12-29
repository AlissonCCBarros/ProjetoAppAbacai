using Common.Orm;
using Project.Core.Filters;
using Project.Core.Data.Context;
using Project.Core.Data.Model;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Core.Data.Repository
{
    public class OdsRepositoryBase : Repository<Ods>
    {
        public OdsRepositoryBase(DbContextCore ctx) : base(ctx)
        {

        }
				
		public virtual IEnumerable<dynamic> GetDataItems(OdsFilter filters)
        {
            var querybase = this.GetAll();
            return this.GetAll().Select(_ => new { Id = _.OdsId, Name = _.Nome });
        }
		
        public virtual async Task<IEnumerable<dynamic>> GetDataListCustom(OdsFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetAll().Select(_ => new
            {
                Id = _.OdsId,
				Name = _.Nome
            }));

            return querybase;
        }

        protected IQueryable<Ods> SimpleFilters(OdsFilter filters, IQueryable<Ods> queryBase)
        {
			var queryFilter = queryBase;
            
            if (filters.OdsId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.OdsId == filters.OdsId);
			}
            if (filters.Nome.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Nome.Contains(filters.Nome));
			}
            if (filters.Descricao.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Descricao.Contains(filters.Descricao));
			}
            if (filters.ImageName.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.ImageName.Contains(filters.ImageName));
			}


            return queryFilter;
        }
        
    }
}
