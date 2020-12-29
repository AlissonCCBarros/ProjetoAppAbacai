using Common.Orm;
using Project.Core.Filters;
using Project.Core.Data.Context;
using Project.Core.Data.Model;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Project.Core.Data.Repository
{
    public class MatchRepository : MatchRepositoryBase
    {
        CurrentUser _user;
        public MatchRepository(DbContextCore ctx, CurrentUser user) : base(ctx)
        {
            this._user = user;
        }

        public IQueryable<Match> GetByFilters(MatchFilter filters)
        {
            var querybase = this.GetAll();

            var queryFilter = this.SimpleFilters(filters, querybase);

            return queryFilter;
        }

        public Match GetById(MatchFilter filters)
        {
            var querybase = this.GetByFilters(filters);
            return querybase.SingleOrDefault();
        }

        public Match GetByModel(Match model)
        {
            return this.GetAll().Where(_ => _.MatchId == model.MatchId).SingleOrDefault();
        }

        public override async Task<IEnumerable<dynamic>> GetDataListCustom(MatchFilter filters)
        {
            if (filters.AttributeBehavior == "GetProjetosInstituicao")
            {
                var usuarioId = this._user.GetUserId<int>();
                var projetoId = this.ctx.Set<Projeto>().Where(_ => _.UsuarioId == usuarioId).Select(_ => _.ProjetoId);

                var result = this.ctx.Set<ProjetoAtividade>()
                    .Include(_ => _.Projeto)
                    .Include(_ => _.Atividade)
                    .Where(_ => projetoId.Contains(_.ProjetoId)).Select(_ => new
                    {
                        projetoAtividadeId = _.ProjetoAtividadeId,
                        Atividade = _.Atividade.Nome,
                        Nome = _.Projeto.Nome,
                        Descricao = _.Projeto.Descricao,
                        temNotificaco = _.CollectionMatch.Where(__ => __.ProjetoAtividadeId == _.ProjetoAtividadeId).Where(__ => !__.EhNotificado).Where(__ => !__.Aceito).Any()
                    });

                return result;
            }

            if (filters.AttributeBehavior == "GetMatchUsuariosDoProjeto")
            {
                return this.GetAll().Where(_ => _.ProjetoAtividadeId == filters.ProjetoAtividadeId).Where(_ => !_.Aceito).Select(_ => new
                {
                    MatchId = _.MatchId,
                    UsuarioId = _.Usuario.UsuarioId,
                    Foto = _.Usuario.Foto,
                    Nome = _.Usuario.Nome,
                    Email = _.Usuario.Email,
                    Telefone = _.Usuario.Celular,
                    Avaliacao = _.Usuario.CollectionUsuarioProjetoAtividade.Sum(__ => __.Avaliacao)
                });
            }

            return await base.GetDataListCustom(filters);
        }

    }
}
