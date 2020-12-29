using Common.Orm;
using Project.Core.Filters;
using Project.Core.Data.Context;
using Project.Core.Data.Model;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Common.Domain.Model;
using Org.BouncyCastle.Crypto.Digests;
using System;
using System.Linq.Dynamic.Core;

namespace Project.Core.Data.Repository
{
    public class ProjetoRepository : ProjetoRepositoryBase
    {
        CurrentUser _user;
        public ProjetoRepository(DbContextCore ctx, CurrentUser user) : base(ctx)
        {
            this._user = user;
        }

        public IQueryable<Projeto> GetByFilters(ProjetoFilter filters)
        {
            var querybase = this.GetAll();

            var queryFilter = this.SimpleFilters(filters, querybase);

            return queryFilter;
        }

        public Projeto GetById(ProjetoFilter filters)
        {
            var querybase = this.GetByFilters(filters);
            return querybase.SingleOrDefault();
        }

        public Projeto GetByModel(Projeto model)
        {
            return this.GetAll().Where(_ => _.ProjetoId == model.ProjetoId).SingleOrDefault();
        }
        public override async Task<IEnumerable<dynamic>> GetDataListCustom(ProjetoFilter filters)
        {
            if (filters.AttributeBehavior == "UsuariosProjetoEspecifico")
            {
                var _projetoAtividades = this.ctx.Set<ProjetoAtividade>().Where(_ => _.ProjetoId == filters.ProjetoId).Select(_ => _.ProjetoAtividadeId);

                var _usuarioProjetoAtividade = this.ctx.Set<UsuarioProjetoAtividade>().Where(_ => _projetoAtividades.Contains(_.ProjetoAtividadeId)).Select(_ => _.Usuario);

                return _usuarioProjetoAtividade.Select(_ => new
                {
                    _.Nome,
                    _.Foto
                });

            }

            if (filters.AttributeBehavior == "ListarProjetosUsuario")
            {
                var userId = this._user.GetUserId<int>();

                var ehInstituição = this.ctx.Set<Usuario>().Where(_ => _.UsuarioId == userId).Where(_ => _.EhInstituicao == true).Any();

                if (ehInstituição == true)

                {

                    var projetos = this.GetAll()
                    .Where(_ => _.UsuarioId == userId)
                    .Select(_ => new
                    {
                        idProjeto = _.ProjetoId,
                        nomeProjeto = _.Nome,
                        enderecoId = _.EnderecoId,
                        descricaoProjeto = _.Descricao,
                        dataInicioProjeto = _.DataInicio.ToString().ToDate(),
                        dataFimProjeto = _.DataFim.ToString().ToDate(),
                        podeEncerrarProjeto = _.DataFim != null && _.DataFim <= DateTime.Now ? false : true,
                        foto = _.Foto,
                        atividades = _.CollectionProjetoAtividade.Select(__ => new
                        {
                            idAtividade = __.Atividade.AtividadeId,
                            nomeAtividade = __.Atividade.Nome,
                            descricaoAtividade = __.Atividade.Descricao
                        })
                    });

                    return projetos;
                }

                if (ehInstituição == false)
                {
                    var _usuarioProjetoAtividade = this.ctx.Set<UsuarioProjetoAtividade>().Where(_ => _.UsuarioId == userId);

                    return _usuarioProjetoAtividade.Select(_ => new
                    {

                        idProjeto = _.ProjetoAtividade.Projeto.ProjetoId,
                        nomeProjeto = _.ProjetoAtividade.Projeto.Nome,
                        descricaoProjeto = _.ProjetoAtividade.Projeto.Descricao,
                        dataInicioProjeto = _.ProjetoAtividade.Projeto.DataInicio.ToString().ToDate(),
                        dataFimProjeto = _.ProjetoAtividade.Projeto.DataFim.ToString().ToDate(),
                        foto = _.ProjetoAtividade.Projeto.Foto,
                        enderecoId = _.ProjetoAtividade.Projeto.EnderecoId,


                        idAtividate = _.ProjetoAtividade.Atividade.AtividadeId,
                        nomeAtividade = _.ProjetoAtividade.Atividade.Nome,
                        descricaoAtividate = _.ProjetoAtividade.Atividade.Descricao,

                    });

                }

            }

            if (filters.AttributeBehavior == "DetalhesOds")
            {
                var userId = this._user.GetUserId<int>();
                var projetos = this.GetAll().Where(_ => _.UsuarioId == userId).Select(_ => _.ProjetoId);
                var projetoAtividade = this.ctx.Set<ProjetoAtividade>()
                    .Where(_ => projetos.Contains(_.ProjetoId))
                    .Where(_ => _.Atividade.OdsId == filters.OdsId)
                    .Select(_ => new
                    {
                        atividade = _.Atividade.Nome,
                        projeto = _.Projeto.Nome,
                    });
                return projetoAtividade;
            }

            var querybase = await this.ToListAsync(this.GetAll().Select(_ => new
            {
                Id = _.ProjetoId,
                Name = _.Nome
            }));

            return querybase;
        }
    }
}
