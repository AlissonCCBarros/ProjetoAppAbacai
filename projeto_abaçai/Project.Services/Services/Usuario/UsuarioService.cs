using Common.Domain.Interfaces;
using Common.Validation;
using System.Threading.Tasks;
using System.Collections.Generic;
using Project.Core.Dto;
using Project.Core.Data.Repository;
using Project.Core.Data.Model;
using Common.Domain.Model;
using System.Linq;
using Common.Domain.Enums;
using System;

namespace Project.Core.Services
{
    public class UsuarioService : UsuarioServiceBase
    {
        private EnderecoRepository _repEndereco;
        private AccountRepository _repAccount;
        private ICripto _cripto;
        public UsuarioService(UsuarioRepository rep, ValidationContract validation, CurrentUser user, IUnitOfWork uow, ICripto cripto,
            EnderecoRepository repEndereco,
            AccountRepository repAccount)
            : base(rep, validation, user, uow)
        {
            this._repEndereco = repEndereco;
            this._repAccount = repAccount;
            this._cripto = cripto;
        }

        protected override async Task<IEnumerable<TDS>> MapperDomainToDto<TDS>(IEnumerable<Usuario> models)
        {
            return await base.MapperDomainToDto<UsuarioDtoResult>(models) as IEnumerable<TDS>;
        }

        public override Usuario Save(Usuario model)
        {

            if (model.AttributeBehavior == "EditarUsuario")
            {
                var alvo = this._rep.GetAll().Where(_ => _.UsuarioId == model.UsuarioId).SingleOrDefault();

                if (model.Nome != alvo.Nome ||
                    model.Account.IsNotNull() && model.Account.Password.IsSent())
                {
                    var account = this._repAccount.GetAll().Where(_ => _.AccountId == model.UsuarioId).SingleOrDefault();

                    if (model.Account.IsNotNull() && model.Account.Password.IsSent())
                    {
                        var senha = this._cripto.Encrypt(model.Account.Password, TypeCripto.Hash128);
                        account.Password = senha;
                    }

                    if (model.Nome != alvo.Nome)
                        account.Name = model.Nome;

                    this._repAccount.Update(account);
                }


                if (model.Endereco.IsNotNull())
                {
                    var endereco = model.EnderecoId != null ? this._repEndereco.GetAll().Where(_ => _.EnderecoId == model.EnderecoId).SingleOrDefault() : null;
                    //int id = Convert.ToInt32(model.EnderecoId);
                    //var endereco = this._repEndereco.GetAll().Where(_ => _.EnderecoId == id).FirstOrDefault();

                    if (endereco.IsNotNull())
                        this._repEndereco.Update(model.Endereco);
                    else
                    {
                        model.EnderecoId = this._repEndereco.Add(model.Endereco).EnderecoId;
                        this._repEndereco.Commit();

                    }
                }

                model.EhInstituicao = alvo.EhInstituicao;
                model.Account = null;
                this._rep.Update(model);

                return model;
            }


            return base.Save(model);

        }

    }
}
