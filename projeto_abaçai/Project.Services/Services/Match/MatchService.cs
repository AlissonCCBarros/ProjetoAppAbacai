using Common.Domain.Interfaces;
using Common.Validation;
using System.Threading.Tasks;
using System.Collections.Generic;
using Project.Core.Dto;
using Project.Core.Data.Repository;
using Project.Core.Data.Model;
using Common.Domain.Model;
using System.Linq.Dynamic.Core;
using System.Linq;
using System;

namespace Project.Core.Services
{
    public class MatchService : MatchServiceBase
    {
        private NotificacaoRepository _notificacaoRepository;
        private UsuarioRepository _usuarioRepository;
        private ProjetoAtividadeRepository _projetoAtividadeRepository;
        public MatchService(MatchRepository rep, ProjetoAtividadeRepository projetoAtividadeRepository, UsuarioRepository usuarioRepository, NotificacaoRepository notificacaoRepository, ValidationContract validation, CurrentUser user, IUnitOfWork uow)
            : base(rep, validation, user, uow)
        {
            this._notificacaoRepository = notificacaoRepository;
            this._usuarioRepository = usuarioRepository;
            this._projetoAtividadeRepository = projetoAtividadeRepository;
            this._user = user;
        }

        protected override async Task<IEnumerable<TDS>> MapperDomainToDto<TDS>(IEnumerable<Match> models)
        {
            return await base.MapperDomainToDto<MatchDtoResult>(models) as IEnumerable<TDS>;
        }
        public override Task<int> Remove(MatchDto entity)
        {
            if (entity.AttributeBehavior == "DeletarUsuarioRecusado")
            {
                var usuario = this._usuarioRepository.GetAll().Where(_ => _.UsuarioId == entity.UsuarioId).SingleOrDefault();
                var projetoNome = this._projetoAtividadeRepository.GetAll(_ => _.Projeto).Where(_ => _.ProjetoAtividadeId == entity.ProjetoAtividadeId).Select(_ => _.Projeto.Nome).FirstOrDefault();

                if (usuario.IsNotNull() && projetoNome.IsNotNull())
                {
                    var notificao = new Notificacao();
                    notificao.UsuarioId = entity.UsuarioId;
                    notificao.Titulo = "Recusado";
                    notificao.Descricao = $"Olá {usuario.Nome}, sua solicitação para o projeto {projetoNome} foi recusado.";
                    notificao.EhAceito = false;
                    notificao.EhNotificado = false;
                    this._notificacaoRepository.Add(notificao);
                }

            }
            return base.Remove(entity);
        }

        public override Match Save(Match model)
        {
            var match = new Match();

            if (model.AttributeBehavior == "SalvarMatch")
            {
                var userId = this._user.GetUserId<int>();
                
                match.UsuarioId = userId;
                match.ProjetoAtividadeId = model.ProjetoAtividadeId;
                match.Ativo = true;
                match.Aceito = false;
                match.EhNotificado = false;
                match.DataMatch = DateTime.Now;
                this._rep.Add(match);
            }

            return base.Save(match);
        }
    }
}
