using Common.Orm;
using Project.Core.Filters;
using Project.Core.Data.Context;
using Project.Core.Data.Model;
using System.Linq;
using Common.Domain.Model;
using System;

namespace Project.Core.Data.Repository
{
    public class UsuarioProjetoAtividadeRepository : UsuarioProjetoAtividadeRepositoryBase
    {
        CurrentUser _user;
        public UsuarioProjetoAtividadeRepository(DbContextCore ctx, CurrentUser user) : base(ctx)
        {
            this._user = user;

        }

        public IQueryable<UsuarioProjetoAtividade> GetByFilters(UsuarioProjetoAtividadeFilter filters)
        {
            var querybase = this.GetAll();

            var queryFilter = this.SimpleFilters(filters, querybase);

            return queryFilter;
        }

        public UsuarioProjetoAtividade GetById(UsuarioProjetoAtividadeFilter filters)
        {
            var querybase = this.GetByFilters(filters);
            return querybase.SingleOrDefault();
        }

        public UsuarioProjetoAtividade GetByModel(UsuarioProjetoAtividade model)
        {
            return this.GetAll().Where(_ => _.UsuarioProjetoAtividadeId == model.UsuarioProjetoAtividadeId).SingleOrDefault();
        }
        public override async System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<dynamic>> GetDataListCustom(UsuarioProjetoAtividadeFilter filters)
        {
            if (filters.AttributeBehavior == "DetalhesOds")
            {
                var userId = this._user.GetUserId<int>();
                var details = this.GetAll().Where(_ => _.UsuarioId == userId)
                                          .Where(_ => _.ProjetoAtividade.Atividade.OdsId == filters.OdsId);

                var avaliacao = Convert.ToDecimal(details.Sum(_ => _.Avaliacao.Value));

                var result = details.Select(_ => new
                {
                    atividade = _.ProjetoAtividade.Atividade.Nome,
                    projeto = _.ProjetoAtividade.Projeto.Nome,
                    avaliacao = avaliacao
                });

                return result;
            }
            return await base.GetDataListCustom(filters);
        }
    }
}
