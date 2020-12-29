using Common.Orm;
using Project.Core.Filters;
using Project.Core.Data.Context;
using Project.Core.Data.Model;
using System.Linq;

namespace Project.Core.Data.Repository
{
    public class UsuarioHabilidadeRepository : UsuarioHabilidadeRepositoryBase
    {
        public UsuarioHabilidadeRepository(DbContextCore ctx) : base(ctx)
        {

        }

        public IQueryable<UsuarioHabilidade> GetByFilters(UsuarioHabilidadeFilter filters)
        {
            var querybase = this.GetAll();

            var queryFilter = this.SimpleFilters(filters, querybase);

            return queryFilter;
        }

        public UsuarioHabilidade GetById(UsuarioHabilidadeFilter filters)
        {
            var querybase = this.GetByFilters(filters);
            return querybase.SingleOrDefault();
        }

		public UsuarioHabilidade GetByModel(UsuarioHabilidade model)
        {
            return this.GetAll().Where(_ => _.UsuarioHabilidadeId == model.UsuarioHabilidadeId).SingleOrDefault();
        }

    }
}
