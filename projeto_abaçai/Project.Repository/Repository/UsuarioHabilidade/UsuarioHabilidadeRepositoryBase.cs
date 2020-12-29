using Common.Orm;
using Project.Core.Filters;
using Project.Core.Data.Context;
using Project.Core.Data.Model;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Core.Data.Repository
{
    public class UsuarioHabilidadeRepositoryBase : Repository<UsuarioHabilidade>
    {
        public UsuarioHabilidadeRepositoryBase(DbContextCore ctx) : base(ctx)
        {

        }
				
		public virtual IEnumerable<dynamic> GetDataItems(UsuarioHabilidadeFilter filters)
        {
            var querybase = this.GetAll();
            return this.GetAll().Select(_ => new { Id = _.UsuarioHabilidadeId, Name = _.UsuarioHabilidadeId });
        }
		
        public virtual async Task<IEnumerable<dynamic>> GetDataListCustom(UsuarioHabilidadeFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetAll().Select(_ => new
            {
                Id = _.UsuarioHabilidadeId,
				Name = _.UsuarioHabilidadeId
            }));

            return querybase;
        }

        protected IQueryable<UsuarioHabilidade> SimpleFilters(UsuarioHabilidadeFilter filters, IQueryable<UsuarioHabilidade> queryBase)
        {
			var queryFilter = queryBase;
            
            if (filters.UsuarioHabilidadeId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.UsuarioHabilidadeId == filters.UsuarioHabilidadeId);
			}
            if (filters.UsuarioId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.UsuarioId == filters.UsuarioId);
			}
            if (filters.HabilidadeId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.HabilidadeId == filters.HabilidadeId);
			}


            return queryFilter;
        }
        
    }
}
