using Common.Orm;
using Project.Core.Filters;
using Project.Core.Data.Context;
using Project.Core.Data.Model;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Core.Data.Repository
{
    public class UsuarioProjetoRepositoryBase : Repository<UsuarioProjeto>
    {
        public UsuarioProjetoRepositoryBase(DbContextCore ctx) : base(ctx)
        {

        }
				
		public virtual IEnumerable<dynamic> GetDataItems(UsuarioProjetoFilter filters)
        {
            var querybase = this.GetAll();
            return this.GetAll().Select(_ => new { Id = _.UsuarioProjetoId, Name = _.UsuarioProjetoId });
        }
		
        public virtual async Task<IEnumerable<dynamic>> GetDataListCustom(UsuarioProjetoFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetAll().Select(_ => new
            {
                Id = _.UsuarioProjetoId,
				Name = _.UsuarioProjetoId
            }));

            return querybase;
        }

        protected IQueryable<UsuarioProjeto> SimpleFilters(UsuarioProjetoFilter filters, IQueryable<UsuarioProjeto> queryBase)
        {
			var queryFilter = queryBase;
            
            if (filters.UsuarioProjetoId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.UsuarioProjetoId == filters.UsuarioProjetoId);
			}
            if (filters.UsuarioId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.UsuarioId == filters.UsuarioId);
			}
            if (filters.ProjetoId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.ProjetoId == filters.ProjetoId);
			}


            return queryFilter;
        }
        
    }
}
