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
    public class UsuarioProjetoAtividadeService : UsuarioProjetoAtividadeServiceBase
    {
        private MatchRepository _matchRepository;
        private NotificacaoRepository _notificacaoRepository;
        private UsuarioRepository _usuarioRepository;
        private ProjetoAtividadeRepository _projetoAtividadeRepository;
        public UsuarioProjetoAtividadeService(UsuarioProjetoAtividadeRepository rep, ProjetoAtividadeRepository projetoAtividadeRepository, UsuarioRepository usuarioRepository, MatchRepository matchRepository, NotificacaoRepository notificacaoRepository, ValidationContract validation, CurrentUser user, IUnitOfWork uow)
            : base(rep, validation, user, uow)
        {
            this._matchRepository = matchRepository;
            this._notificacaoRepository = notificacaoRepository;
            this._usuarioRepository = usuarioRepository;
            this._projetoAtividadeRepository = projetoAtividadeRepository;
        }

        protected override async Task<IEnumerable<TDS>> MapperDomainToDto<TDS>(IEnumerable<UsuarioProjetoAtividade> models)
        {
            return await base.MapperDomainToDto<UsuarioProjetoAtividadeDtoResult>(models) as IEnumerable<TDS>;
        }

        public override UsuarioProjetoAtividade Save(UsuarioProjetoAtividade model)
        {
            if (model.AttributeBehavior == "SalvarUsuarioAprovado")
            {
                var usuario = this._usuarioRepository.GetAll().Where(_ => _.UsuarioId == model.UsuarioId).SingleOrDefault();
                var projetoNome = this._projetoAtividadeRepository.GetAll(_=> _.Projeto).Where(_ => _.ProjetoAtividadeId == model.ProjetoAtividadeId).Select(_ => _.Projeto.Nome).FirstOrDefault();

                if (usuario.IsNotNull() && projetoNome.IsNotNull())
                {
                    var notificao = new Notificacao();
                    notificao.UsuarioId = model.UsuarioId;
                    notificao.Titulo = "Aceito";
                    notificao.Descricao = $"Olá {usuario.Nome}, sua solicitação para o projeto {projetoNome} foi aceito.";
                    notificao.EhAceito = true;
                    notificao.EhNotificado = false;
                    this._notificacaoRepository.Add(notificao);
                }

                var match = this._matchRepository.GetAll().Where(_ => _.ProjetoAtividadeId == model.ProjetoAtividadeId).Where(_=> _.UsuarioId == model.UsuarioId).SingleOrDefault();
                match.Aceito = true;
                match.EhNotificado = true;
                match.DataAceito = DateTime.Now;
                this._matchRepository.Update(match);
            }

            return base.Save(model);
        }
        
    }
}
