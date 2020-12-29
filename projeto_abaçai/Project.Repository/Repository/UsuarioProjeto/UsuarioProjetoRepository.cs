using Common.Orm;
using Project.Core.Filters;
using Project.Core.Data.Context;
using Project.Core.Data.Model;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Project.Core.Data.Repository
{
    public class UsuarioProjetoRepository : UsuarioProjetoRepositoryBase
    {
        public UsuarioProjetoRepository(DbContextCore ctx) : base(ctx)
        {

        }

        public IQueryable<UsuarioProjeto> GetByFilters(UsuarioProjetoFilter filters)
        {
            var querybase = this.GetAll();

            var queryFilter = this.SimpleFilters(filters, querybase);

            return queryFilter;
        }

        public UsuarioProjeto GetById(UsuarioProjetoFilter filters)
        {
            var querybase = this.GetByFilters(filters);
            return querybase.SingleOrDefault();
        }

		public UsuarioProjeto GetByModel(UsuarioProjeto model)
        {
            return this.GetAll().Where(_ => _.UsuarioProjetoId == model.UsuarioProjetoId).SingleOrDefault();
        }

        public override async Task<IEnumerable<dynamic>> GetDataListCustom(UsuarioProjetoFilter filters)
        {
            return await base.GetDataListCustom(filters);
        }

    }
}
