using Common.Orm;
using Project.Core.Filters;
using Project.Core.Data.Context;
using Project.Core.Data.Model;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Core.Data.Repository
{
    public class EnderecoRepositoryBase : Repository<Endereco>
    {
        public EnderecoRepositoryBase(DbContextCore ctx) : base(ctx)
        {

        }
				
		public virtual IEnumerable<dynamic> GetDataItems(EnderecoFilter filters)
        {
            var querybase = this.GetAll();
            return this.GetAll().Select(_ => new { Id = _.EnderecoId, Name = _.CEP });
        }
		
        public virtual async Task<IEnumerable<dynamic>> GetDataListCustom(EnderecoFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetAll().Select(_ => new
            {
                Id = _.EnderecoId,
				Name = _.CEP
            }));

            return querybase;
        }

        protected IQueryable<Endereco> SimpleFilters(EnderecoFilter filters, IQueryable<Endereco> queryBase)
        {
			var queryFilter = queryBase;
            
            if (filters.EnderecoId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.EnderecoId == filters.EnderecoId);
			}
            if (filters.CEP.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.CEP.Contains(filters.CEP));
			}
            if (filters.Rua.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Rua.Contains(filters.Rua));
			}
            if (filters.Numero.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Numero == filters.Numero);
			}
            if (filters.Bairro.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Bairro.Contains(filters.Bairro));
			}
            if (filters.Cidade.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Cidade.Contains(filters.Cidade));
			}
            if (filters.Estado.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Estado.Contains(filters.Estado));
			}


            return queryFilter;
        }
        
    }
}
