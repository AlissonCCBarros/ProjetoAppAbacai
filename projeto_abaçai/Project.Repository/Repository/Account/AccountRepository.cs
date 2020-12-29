using Common.Orm;
using Project.Core.Filters;
using Project.Core.Data.Context;
using Project.Core.Data.Model;
using System.Linq;

namespace Project.Core.Data.Repository
{
	public class AccountRepository : AccountRepositoryBase
	{
		public AccountRepository(DbContextCore ctx) : base(ctx)
		{

		}

		public IQueryable<Account> GetByFilters(AccountFilter filters)
		{
			var querybase = this.GetAll();

			var queryFilter = this.SimpleFilters(filters, querybase);

			return queryFilter;
		}

		public Account GetById(AccountFilter filters)
		{
			var querybase = this.GetByFilters(filters);
			return querybase.SingleOrDefault();
		}

		public Account GetByModel(Account model)
		{
			return this.GetAll().Where(_ => _.AccountId == model.AccountId).SingleOrDefault();
		}

	}
}
