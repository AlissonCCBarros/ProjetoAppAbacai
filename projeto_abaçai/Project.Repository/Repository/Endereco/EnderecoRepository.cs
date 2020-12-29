using Common.Orm;
using Project.Core.Filters;
using Project.Core.Data.Context;
using Project.Core.Data.Model;
using System.Linq;

namespace Project.Core.Data.Repository
{
    public class EnderecoRepository : EnderecoRepositoryBase
    {
        public EnderecoRepository(DbContextCore ctx) : base(ctx)
        {

        }

        public IQueryable<Endereco> GetByFilters(EnderecoFilter filters)
        {
            var querybase = this.GetAll();

            var queryFilter = this.SimpleFilters(filters, querybase);

            return queryFilter;
        }

        public Endereco GetById(EnderecoFilter filters)
        {
            var querybase = this.GetByFilters(filters);
            return querybase.SingleOrDefault();
        }

		public Endereco GetByModel(Endereco model)
        {
            return this.GetAll().Where(_ => _.EnderecoId == model.EnderecoId).SingleOrDefault();
        }

    }
}
