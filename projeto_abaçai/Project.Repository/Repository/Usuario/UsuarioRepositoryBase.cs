using Common.Orm;
using Project.Core.Filters;
using Project.Core.Data.Context;
using Project.Core.Data.Model;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Core.Data.Repository
{
    public class UsuarioRepositoryBase : Repository<Usuario>
    {
        public UsuarioRepositoryBase(DbContextCore ctx) : base(ctx)
        {

        }
				
		public virtual IEnumerable<dynamic> GetDataItems(UsuarioFilter filters)
        {
            var querybase = this.GetAll();
            return this.GetAll().Select(_ => new { Id = _.UsuarioId, Name = _.Nome });
        }
		
        public virtual async Task<IEnumerable<dynamic>> GetDataListCustom(UsuarioFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetAll().Select(_ => new
            {
                Id = _.UsuarioId,
				Name = _.Nome
            }));

            return querybase;
        }

        protected IQueryable<Usuario> SimpleFilters(UsuarioFilter filters, IQueryable<Usuario> queryBase)
        {
			var queryFilter = queryBase;
            
            if (filters.UsuarioId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.UsuarioId == filters.UsuarioId);
			}
            if (filters.Nome.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Nome.Contains(filters.Nome));
			}
            if (filters.Apelido.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Apelido.Contains(filters.Apelido));
			}
            if (filters.CPF_CNPJ.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.CPF_CNPJ.Contains(filters.CPF_CNPJ));
			}
            if (filters.IE_RG.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.IE_RG.Contains(filters.IE_RG));
			}
            if (filters.Telefone.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Telefone.Contains(filters.Telefone));
			}
            if (filters.Celular.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Celular.Contains(filters.Celular));
			}
            if (filters.Email.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Email.Contains(filters.Email));
			}
            if (filters.UserCreateDateStart.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.UserCreateDate != null && _.UserCreateDate.Value >= filters.UserCreateDateStart.Value);
			}
            if (filters.UserCreateDateEnd.IsSent()) 
			{ 
				filters.UserCreateDateEnd = filters.UserCreateDateEnd.Value.AddDays(1).AddMilliseconds(-1);
				queryFilter = queryFilter.Where(_ => _.UserCreateDate != null &&  _.UserCreateDate.Value <= filters.UserCreateDateEnd);
			}

            if (filters.UserAlterDateStart.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.UserAlterDate != null && _.UserAlterDate.Value >= filters.UserAlterDateStart.Value);
			}
            if (filters.UserAlterDateEnd.IsSent()) 
			{ 
				filters.UserAlterDateEnd = filters.UserAlterDateEnd.Value.AddDays(1).AddMilliseconds(-1);
				queryFilter = queryFilter.Where(_ => _.UserAlterDate != null &&  _.UserAlterDate.Value <= filters.UserAlterDateEnd);
			}

            if (filters.EnderecoId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.EnderecoId != null && _.EnderecoId.Value == filters.EnderecoId);
			}
            if (filters.EhInstituicao.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.EhInstituicao == filters.EhInstituicao);
			}
            if (filters.Foto.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Foto.Contains(filters.Foto));
			}


            return queryFilter;
        }
        
    }
}
