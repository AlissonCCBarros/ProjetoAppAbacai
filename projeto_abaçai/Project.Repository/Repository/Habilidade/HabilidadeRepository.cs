using Common.Orm;
using Project.Core.Filters;
using Project.Core.Data.Context;
using Project.Core.Data.Model;
using System.Linq;

namespace Project.Core.Data.Repository
{
    public class HabilidadeRepository : HabilidadeRepositoryBase
    {
        public HabilidadeRepository(DbContextCore ctx) : base(ctx)
        {

        }

        public IQueryable<Habilidade> GetByFilters(HabilidadeFilter filters)
        {
            var querybase = this.GetAll();

            var queryFilter = this.SimpleFilters(filters, querybase);

            return queryFilter;
        }

        public Habilidade GetById(HabilidadeFilter filters)
        {
            var querybase = this.GetByFilters(filters);
            return querybase.SingleOrDefault();
        }

		public Habilidade GetByModel(Habilidade model)
        {
            return this.GetAll().Where(_ => _.HabilidadeId == model.HabilidadeId).SingleOrDefault();
        }

    }
}
