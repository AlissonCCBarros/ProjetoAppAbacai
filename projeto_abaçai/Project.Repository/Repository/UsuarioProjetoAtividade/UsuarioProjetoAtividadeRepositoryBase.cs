using Common.Orm;
using Project.Core.Filters;
using Project.Core.Data.Context;
using Project.Core.Data.Model;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Core.Data.Repository
{
    public class UsuarioProjetoAtividadeRepositoryBase : Repository<UsuarioProjetoAtividade>
    {
        public UsuarioProjetoAtividadeRepositoryBase(DbContextCore ctx) : base(ctx)
        {

        }
				
		public virtual IEnumerable<dynamic> GetDataItems(UsuarioProjetoAtividadeFilter filters)
        {
            var querybase = this.GetAll();
            return this.GetAll().Select(_ => new { Id = _.UsuarioProjetoAtividadeId, Name = _.Avaliacao });
        }
		
        public virtual async Task<IEnumerable<dynamic>> GetDataListCustom(UsuarioProjetoAtividadeFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetAll().Select(_ => new
            {
                Id = _.UsuarioProjetoAtividadeId,
				Name = _.Avaliacao
            }));

            return querybase;
        }

        protected IQueryable<UsuarioProjetoAtividade> SimpleFilters(UsuarioProjetoAtividadeFilter filters, IQueryable<UsuarioProjetoAtividade> queryBase)
        {
			var queryFilter = queryBase;
            
            if (filters.UsuarioProjetoAtividadeId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.UsuarioProjetoAtividadeId == filters.UsuarioProjetoAtividadeId);
			}
            if (filters.UsuarioId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.UsuarioId == filters.UsuarioId);
			}
            if (filters.ProjetoAtividadeId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.ProjetoAtividadeId == filters.ProjetoAtividadeId);
			}
            if (filters.Avaliacao.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Avaliacao != null && _.Avaliacao.Value == filters.Avaliacao);
			}


            return queryFilter;
        }
        
    }
}
