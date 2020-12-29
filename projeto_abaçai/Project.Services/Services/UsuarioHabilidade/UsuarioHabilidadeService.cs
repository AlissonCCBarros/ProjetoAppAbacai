using Common.Domain.Interfaces;
using Common.Validation;
using System.Threading.Tasks;
using System.Collections.Generic;
using Project.Core.Dto;
using Project.Core.Data.Repository;
using Project.Core.Data.Model;
using Common.Domain.Model;
using System.Linq;

namespace Project.Core.Services
{
    public class UsuarioHabilidadeService : UsuarioHabilidadeServiceBase
    {
        protected CurrentUser _user;
        public UsuarioHabilidadeService(UsuarioHabilidadeRepository rep, ValidationContract validation, CurrentUser user, IUnitOfWork uow)
            : base(rep, validation, user, uow)
        {
            this._user = user;
        }

		protected override async Task<IEnumerable<TDS>> MapperDomainToDto<TDS>(IEnumerable<UsuarioHabilidade> models)
        {
            return await base.MapperDomainToDto<UsuarioHabilidadeDtoResult>(models) as IEnumerable<TDS>;
        }

        public override UsuarioHabilidade Save(UsuarioHabilidade model)
        {
            var objUsuarioHabilidade = this._rep.GetAll().Where(_ => _.UsuarioId == model.UsuarioId).Select(_ => _.HabilidadeId);

            if (!objUsuarioHabilidade.Contains(model.HabilidadeId))
            {
                this._rep.Add(model);
            }
            
    

            return model;
        }

    }
}
