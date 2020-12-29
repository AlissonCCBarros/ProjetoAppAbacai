using Common.Orm;
using Project.Core.Filters;
using Project.Core.Data.Context;
using Project.Core.Data.Model;
using System.Linq;
using Common.Domain.Model;

namespace Project.Core.Data.Repository
{
    public class UsuarioRepository : UsuarioRepositoryBase
    {
        private CurrentUser _user;
        public UsuarioRepository(DbContextCore ctx, CurrentUser user) : base(ctx)
        {
            this._user = user;
        }

        public IQueryable<Usuario> GetByFilters(UsuarioFilter filters)
        {
            var querybase = this.GetAll();
            if(filters.AttributeBehavior == "GetInfoUsuarioPerfil")
            {
                var userId = this._user.GetUserId<int>();
                filters.UsuarioId = userId;
            }
            var queryFilter = this.SimpleFilters(filters, querybase);

            return queryFilter;
        }

        public Usuario GetById(UsuarioFilter filters)
        {
            var querybase = this.GetByFilters(filters);
            return querybase.SingleOrDefault();
        }

		public Usuario GetByModel(Usuario model)
        {
            return this.GetAll().Where(_ => _.UsuarioId == model.UsuarioId).SingleOrDefault();
        }

    }
}
