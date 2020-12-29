using Common.Orm;
using Project.Core.Filters;
using Project.Core.Data.Context;
using Project.Core.Data.Model;
using System.Linq;

namespace Project.Core.Data.Repository
{
	public class AtividadeRepository : AtividadeRepositoryBase
	{
		public AtividadeRepository(DbContextCore ctx) : base(ctx)
		{

		}

		public IQueryable<Atividade> GetByFilters(AtividadeFilter filters)
		{
			var querybase = this.GetAll();

			var queryFilter = this.SimpleFilters(filters, querybase);

			return queryFilter;
		}

		public Atividade GetById(AtividadeFilter filters)
		{
			var querybase = this.GetByFilters(filters);
			return querybase.SingleOrDefault();
		}

		public Atividade GetByModel(Atividade model)
		{
			return this.GetAll().Where(_ => _.AtividadeId == model.AtividadeId).SingleOrDefault();
		}

	}
}
