using Common.Orm;
using Project.Core.Filters;
using Project.Core.Data.Context;
using Project.Core.Data.Model;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Core.Data.Repository
{
    public class ProjetoRepositoryBase : Repository<Projeto>
    {
        public ProjetoRepositoryBase(DbContextCore ctx) : base(ctx)
        {

        }
				
		public virtual IEnumerable<dynamic> GetDataItems(ProjetoFilter filters)
        {
            var querybase = this.GetAll();
            return this.GetAll().Select(_ => new { Id = _.ProjetoId, Name = _.Nome });
        }
		
        public virtual async Task<IEnumerable<dynamic>> GetDataListCustom(ProjetoFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetAll().Select(_ => new
            {
                Id = _.ProjetoId,
				Name = _.Nome
            }));

            return querybase;
        }

        protected IQueryable<Projeto> SimpleFilters(ProjetoFilter filters, IQueryable<Projeto> queryBase)
        {
			var queryFilter = queryBase;
            
            if (filters.ProjetoId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.ProjetoId == filters.ProjetoId);
			}
            if (filters.Nome.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Nome.Contains(filters.Nome));
			}
            if (filters.Descricao.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Descricao.Contains(filters.Descricao));
			}
            if (filters.DataInicioStart.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.DataInicio >= filters.DataInicioStart );
			}
            if (filters.DataInicioEnd.IsSent()) 
			{ 
				filters.DataInicioEnd = filters.DataInicioEnd.AddDays(1).AddMilliseconds(-1);
				queryFilter = queryFilter.Where(_ => _.DataInicio <= filters.DataInicioEnd);
			}

            if (filters.DataFimStart.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.DataFim != null && _.DataFim.Value >= filters.DataFimStart.Value);
			}
            if (filters.DataFimEnd.IsSent()) 
			{ 
				filters.DataFimEnd = filters.DataFimEnd.Value.AddDays(1).AddMilliseconds(-1);
				queryFilter = queryFilter.Where(_ => _.DataFim != null &&  _.DataFim.Value <= filters.DataFimEnd);
			}

            if (filters.EnderecoId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.EnderecoId == filters.EnderecoId);
			}
            if (filters.UsuarioId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.UsuarioId == filters.UsuarioId);
			}
            if (filters.Foto.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Foto.Contains(filters.Foto));
			}


            return queryFilter;
        }
        
    }
}
