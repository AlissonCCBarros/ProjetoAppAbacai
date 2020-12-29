using Common.Orm;
using Project.Core.Filters;
using Project.Core.Data.Context;
using Project.Core.Data.Model;
using System.Linq;
using Common.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;

namespace Project.Core.Data.Repository
{
    public class OdsRepository : OdsRepositoryBase
    {
        CurrentUser _user;
        public OdsRepository(DbContextCore ctx, CurrentUser user) : base(ctx)
        {
            this._user = user;
        }

        public IQueryable<Ods> GetByFilters(OdsFilter filters)
        {
            var querybase = this.GetAll();

            var queryFilter = this.SimpleFilters(filters, querybase);



            return queryFilter;
        }

        public Ods GetById(OdsFilter filters)
        {
            var querybase = this.GetByFilters(filters);
            return querybase.SingleOrDefault();
        }

        public Ods GetByModel(Ods model)
        {
            return this.GetAll().Where(_ => _.OdsId == model.OdsId).SingleOrDefault();
        }
        public override async Task<IEnumerable<dynamic>> GetDataListCustom(OdsFilter filters)
        {
            if (filters.AttributeBehavior == "PegarTodosOsOdsDoUsuarioLogado")
            {
                var userId = this._user.GetUserId<int>();
                var usuario = this.ctx.Set<Usuario>().Where(_ => _.UsuarioId == userId).SingleOrDefault();

                if (usuario.EhInstituicao)
                {
                    var instituicaoProjetos = this.ctx.Set<Projeto>().Where(_ => _.UsuarioId == usuario.UsuarioId).Select(_ => _.ProjetoId);
                    var projetoAtividade = this.ctx.Set<ProjetoAtividade>().Where(_ => instituicaoProjetos.Contains(_.ProjetoId)).Select(_ => _.AtividadeId);
                    var result = this.GetAll().Select(_ => new
                    {
                        _.OdsId,
                        _.Nome,
                        _.Descricao,
                        _.ImageName,
                        temOds = _.CollectionAtividade.Where(__ => projetoAtividade.Contains(__.AtividadeId)).Where(__ => __.OdsId == _.OdsId).Any(),
                        ehInstituicao = true,
                    });
                    return result;

                }
                else
                {
                    var usuarioProjeto = this.ctx.Set<UsuarioProjetoAtividade>().Where(_ => _.UsuarioId == userId).Select(_ => _.ProjetoAtividade.AtividadeId);
                    var result = this.GetAll().Select(_ => new
                    {
                        _.OdsId,
                        _.Nome,
                        _.Descricao,
                        _.ImageName,
                        temOds = _.CollectionAtividade.Where(__ => usuarioProjeto.Contains(__.AtividadeId)).Where(__ => __.OdsId == _.OdsId).Any(),
                        ehInstituicao = false,
                    });

                    return result;
                }

            }

            return await base.GetDataListCustom(filters);
        }

    }
}
