using Common.Domain.Interfaces;
using Common.Validation;
using System.Threading.Tasks;
using System.Collections.Generic;
using Project.Core.Dto;
using Project.Core.Data.Repository;
using Project.Core.Data.Model;
using Common.Domain.Model;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace Project.Core.Services
{
    public class ProjetoService : ProjetoServiceBase
    {

        public ProjetoAtividadeService _projetoAtividadeService;
        private ProjetoAtividadeRepository _repProjetoAtividade;
        public UsuarioProjetoAtividadeService _usuarioProjetoAtividadeService;
        private UsuarioProjetoAtividadeRepository _repUsuarioProjetoAtividade;
        private EnderecoRepository _repEndereco;
        public ProjetoService(ProjetoRepository rep,
            ValidationContract validation,
            CurrentUser user,
            IUnitOfWork uow,
            UsuarioProjetoAtividadeService usuarioProjetoAtividadeService,
            UsuarioProjetoAtividadeRepository repUsuarioProjetoAtividade,
            ProjetoAtividadeService projetoAtividadeService,
            EnderecoRepository repEndereco,
            ProjetoAtividadeRepository repProjetoAtividade)
            : base(rep, validation, user, uow)
        {
            this._repUsuarioProjetoAtividade = repUsuarioProjetoAtividade;
            this._usuarioProjetoAtividadeService = usuarioProjetoAtividadeService;
            this._projetoAtividadeService = projetoAtividadeService;
            this._repProjetoAtividade = repProjetoAtividade;
            this._repEndereco = repEndereco;

        }

        protected override async Task<IEnumerable<TDS>> MapperDomainToDto<TDS>(IEnumerable<Projeto> models)
        {
            return await base.MapperDomainToDto<ProjetoDtoResult>(models) as IEnumerable<TDS>;
        }

        public override Projeto Save(Projeto model)
        {
            try
            {
                if (model.AttributeBehavior == "EncerrarProjeto")
                {
                    var alvo = this._rep.GetAllAsTracking()
                        .Include(_ => _.CollectionProjetoAtividade)
                        .ThenInclude(_ => _.CollectionUsuarioProjetoAtividade)
                        .ThenInclude(_ => _.Usuario)
                    .Where(_ => _.ProjetoId == model.ProjetoId).FirstOrDefault();

                    alvo.DataFim = DateTime.Now;

                    var projetoAtividadeIds = alvo.CollectionProjetoAtividade.Select(_ => _.ProjetoAtividadeId);

                    var usuarioProjetoAtividade = this._repUsuarioProjetoAtividade.GetAllAsTracking().Where(_ => projetoAtividadeIds.Contains(_.ProjetoAtividadeId));


                    foreach (var item in usuarioProjetoAtividade)
                    {
                        item.Avaliacao = 1;
                        this._repUsuarioProjetoAtividade.Update(item);
                    }

                    this._rep.Update(alvo);

                    return model;
                }
                else if (model.AttributeBehavior == "DeletarProjeto")
                {
                    var alvo = this._rep.GetAllAsTracking()
                        .Include(_ => _.CollectionProjetoAtividade)
                        .ThenInclude(_ => _.CollectionUsuarioProjetoAtividade)
                    .Where(_ => _.ProjetoId == model.ProjetoId).FirstOrDefault();

                    if (alvo.IsNotNull())
                    {
                        if (alvo.CollectionProjetoAtividade.Where(_ => _.CollectionUsuarioProjetoAtividade.Any()).Any())
                        {
                            this._validation.AddNotification("Existe_Usuarios", "Não podemos deletar esse projeto, já existem voluntários cadastrados nele.");
                            return model;                        }
                        else
                        {
                            foreach (var item in alvo.CollectionProjetoAtividade.ToList())
                            {
                                this._repProjetoAtividade.Remove(item);
                                this._repProjetoAtividade.Commit();
                            }

                            this._rep.Remove(alvo);
                            return model;
                        }
                    }
                    else
                    {
                        this._validation.AddNotification("ProjetoNao_Encontrado", "Não conseguimos deletar seu projeto, favor reportar o erro para a ONG Abaçaí.");
                        return model;
                    }

                }
                else if (model.AttributeBehavior == "DeletarProjetoAdmin")
                {
                    var alvo = this._rep.GetAllAsTracking()
                        .Include(_ => _.CollectionProjetoAtividade)
                        .ThenInclude(_ => _.CollectionUsuarioProjetoAtividade)
                    .Where(_ => _.ProjetoId == model.ProjetoId).FirstOrDefault();

                    foreach (var item in alvo.CollectionProjetoAtividade.ToList())
                    {
                        foreach (var item2 in item.CollectionUsuarioProjetoAtividade.ToList())
                        {
                            this._repUsuarioProjetoAtividade.Remove(item2);
                            this._repUsuarioProjetoAtividade.Commit();
                        }

                        this._repProjetoAtividade.Remove(item);
                        this._repProjetoAtividade.Commit();
                    }

                    this._rep.Remove(alvo);
                    this._rep.Commit();

                    return model;
                }

                else if (model.AttributeBehavior == "NovoProjeto")
                {
                    model.UsuarioId = _user.GetUserId();

                    this._repEndereco.Add(model.Endereco);
                    this._repEndereco.Commit();

                    model.EnderecoId = model.Endereco.EnderecoId;

                    base.Save(model);
                    return model;
                }
                else
                {
                    base.Save(model);
                    return model;
                }

            }
            catch (Exception ex)
            {
                this._validation.AddNotification("Error", "Estamos com problemas para realizar a ação, tente novamente em instantes e se o erro persistir favor entrar em contato com a ONG Abaçaí.");
                return model;
            }

        }

    }
}
