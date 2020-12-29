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
    public class ProjetoAtividadeRepository : ProjetoAtividadeRepositoryBase
    {
        CurrentUser _user;
        public ProjetoAtividadeRepository(DbContextCore ctx, CurrentUser user) : base(ctx)
        {
            this._user = user;
        }

        public IQueryable<ProjetoAtividade> GetByFilters(ProjetoAtividadeFilter filters)
        {
            var querybase = this.GetAll()
                .Include(_ => _.Projeto)
                .Include(_ => _.Projeto.Endereco)
                .Include(_ => _.Atividade)
                .Include(_ => _.Atividade.Ods);

            var queryFilter = this.SimpleFilters(filters, querybase);

            queryFilter = this.CustomFulters(filters, queryFilter);

            return queryFilter;
        }

        private IQueryable<ProjetoAtividade> CustomFulters(ProjetoAtividadeFilter filters, IQueryable<ProjetoAtividade> queryFilter)
        {
            if (filters.NomeProjeto.IsSent())
                queryFilter = queryFilter.Where(_ => _.Projeto.Nome.Contains(filters.NomeProjeto));

            if (filters.NomeAtividade.IsSent())
                queryFilter = queryFilter.Where(_ => _.Atividade.Nome.Contains(filters.NomeAtividade));

            if (filters.Cidade.IsSent())
                queryFilter = queryFilter.Where(_ => _.Projeto.Endereco.Cidade.Contains(filters.Cidade));

            if (filters.Ods.IsSent())
                queryFilter = queryFilter.Where(_ => _.Atividade.Ods.Nome.Contains(filters.Ods));

            return queryFilter;
        }

        public ProjetoAtividade GetById(ProjetoAtividadeFilter filters)
        {
            var querybase = this.GetByFilters(filters);
            return querybase.SingleOrDefault();
        }

        public ProjetoAtividade GetByModel(ProjetoAtividade model)
        {
            return this.GetAll().Where(_ => _.ProjetoAtividadeId == model.ProjetoAtividadeId).SingleOrDefault();
        }

        public async Task<bool> TemNotificaoProjeto(ProjetoFilter filters)
        {
            var userId = this._user.GetUserId<int>();
            var usuario = this.ctx.Set<Usuario>().Where(_ => _.UsuarioId == userId).SingleOrDefault();

            if (usuario.EhInstituicao)
            {
                var projetos = this.ctx.Set<Projeto>().Where(_ => _.UsuarioId == userId).Select(_ => _.ProjetoId);

                return this.GetAll().Where(_ => projetos.Contains(_.ProjetoId))
                                    .Where(_ => _.CollectionMatch.Where(__ => !__.EhNotificado).Where(__ => !__.Aceito).Any())
                                    .Any();
            }
            else
                return this.ctx.Set<Notificacao>().Where(_ => _.UsuarioId == usuario.UsuarioId).Where(_ => !_.EhNotificado).Any();
        }
        public override async Task<IEnumerable<dynamic>> GetDataListCustom(ProjetoAtividadeFilter filters)
        {
            if (filters.AttributeBehavior == "ListarAtividadesDoProjeto")
            {

                var result = this.GetAll().Where(_ => _.ProjetoId == filters.ProjetoId)
                .Select(_ => new
                {
                    idAtividade = _.AtividadeId,
                    nomeAtividade = _.Atividade.Nome,
                    descricaoAtividade = _.Atividade.Descricao,
                    habilidade = _.Atividade.Habilidade.Nome,
                    ods = _.Atividade.Ods.Nome
                });


                return result;
            }

            if (filters.AttributeBehavior == "CarregarAtividadesMatch")
            {
                var userId = this._user.GetUserId<int>();
                var usuarioHabilidade = this.ctx.Set<UsuarioHabilidade>().Where(_ => _.UsuarioId == userId).Select(_ => _.HabilidadeId);
                var usuarioProjetoAtividade = this.ctx.Set<UsuarioProjetoAtividade>().Where(_ => _.UsuarioId == userId).Select(_ => _.ProjetoAtividadeId);
                var enderecoId = this.ctx.Set<Usuario>().Where(_ => _.UsuarioId == userId).Select(_ => _.EnderecoId).SingleOrDefault();
                var endereco = this.ctx.Set<Endereco>().Where(_ => _.EnderecoId == enderecoId).Select(_ => _.Cidade).SingleOrDefault();
                var match = this.ctx.Set<Match>().Where(_ => _.UsuarioId == userId).Select(_ => _.ProjetoAtividadeId);

                var result = this.GetAll()
                .Include(_ => _.Projeto)
                .ThenInclude(_ => _.Endereco)
                .Include(_ => _.Atividade)
                .ThenInclude(_ => _.Habilidade)
                .Where(_ => _.Projeto.Endereco.Cidade.Equals(endereco))
                .Where(_ => usuarioHabilidade.Contains(_.Atividade.HabilidadeId))
                .Where(_ => !usuarioProjetoAtividade.Contains(_.ProjetoAtividadeId))
                .Where(_ => !match.Contains(_.ProjetoAtividadeId))
                .Select(_ => new
                {
                    user = userId,

                    projetoAtividadeId = _.ProjetoAtividadeId,
                    idAtividade = _.AtividadeId,
                    nomeAtividade = _.Atividade.Nome,
                    descricaoAtividade = _.Atividade.Descricao,
                    habilidade = _.Atividade.Habilidade.Nome,
                    ods = _.Atividade.Ods.Nome,

                    projetoId = _.Projeto.Nome,
                    nomeProjeto = _.Projeto.Nome,
                    descricaoProjeto = _.Projeto.Descricao,
                    imagem = _.Projeto.Foto,
                });


                return result;
            }

            if (filters.AttributeBehavior == "BuscarProjetoAtividadePesquisa")
            {
                var result = this.GetByFilters(filters);

                var userId = this._user.GetUserId<int>();
                var usuarioProjetoAtividade = this.ctx.Set<UsuarioProjetoAtividade>().Where(_ => _.UsuarioId == userId).Select(_ => _.ProjetoAtividadeId);
                var match = this.ctx.Set<Match>().Where(_ => _.UsuarioId == userId).Select(_ => _.ProjetoAtividadeId);

                var pesquisaProjetos = result
                    .Where(_ => !usuarioProjetoAtividade.Contains(_.ProjetoAtividadeId))
                    .Where(_ => !match.Contains(_.ProjetoAtividadeId))
                    .Select(_ => new
                    {
                        projetoAtividadeId = _.ProjetoAtividadeId,
                        idAtividade = _.AtividadeId,
                        nomeAtividade = _.Atividade.Nome,
                        descricaoAtividade = _.Atividade.Descricao,
                        ods = _.Atividade.Ods.Nome,
                        habilidade = _.Atividade.Habilidade.Nome,
                        endereco = _.Projeto.Endereco.Rua,
                        numero = _.Projeto.Endereco.Numero,
                        bairro = _.Projeto.Endereco.Bairro,
                        cidade = _.Projeto.Endereco.Cidade,
                        estado = _.Projeto.Endereco.Estado,
                        cep = _.Projeto.Endereco.CEP,


                        projetoId = _.ProjetoId,
                        nomeProjeto = _.Projeto.Nome,
                        descricaoProjeto = _.Projeto.Descricao
                    });

                return pesquisaProjetos;
            }

            return await base.GetDataListCustom(filters);
        }

    }
}
