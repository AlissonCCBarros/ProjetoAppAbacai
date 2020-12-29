using Common.Orm;
using Project.Core.Filters;
using Project.Core.Data.Context;
using Project.Core.Data.Model;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Core.Data.Repository
{
    public class AccountRepositoryBase : Repository<Account>
    {
        public AccountRepositoryBase(DbContextCore ctx) : base(ctx)
        {

        }
				
		public virtual IEnumerable<dynamic> GetDataItems(AccountFilter filters)
        {
            var querybase = this.GetAll();
            return this.GetAll().Select(_ => new { Id = _.AccountId, Name = _.Name });
        }
		
        public virtual async Task<IEnumerable<dynamic>> GetDataListCustom(AccountFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetAll().Select(_ => new
            {
                Id = _.AccountId,
				Name = _.Name
            }));

            return querybase;
        }

        protected IQueryable<Account> SimpleFilters(AccountFilter filters, IQueryable<Account> queryBase)
        {
			var queryFilter = queryBase;
            
            if (filters.AccountId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.AccountId == filters.AccountId);
			}
            if (filters.Name.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Name.Contains(filters.Name));
			}
            if (filters.Email.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Email.Contains(filters.Email));
			}
            if (filters.Password.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Password.Contains(filters.Password));
			}
            if (filters.Admin.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Admin == filters.Admin);
			}


            return queryFilter;
        }
        
    }
}
