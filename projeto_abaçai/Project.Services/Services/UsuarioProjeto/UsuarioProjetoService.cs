using Common.Domain.Interfaces;
using Common.Validation;
using System.Threading.Tasks;
using System.Collections.Generic;
using Project.Core.Dto;
using Project.Core.Data.Repository;
using Project.Core.Data.Model;
using Common.Domain.Model;

namespace Project.Core.Services
{
    public class UsuarioProjetoService : UsuarioProjetoServiceBase
    {
        public UsuarioProjetoService(UsuarioProjetoRepository rep, ValidationContract validation, CurrentUser user, IUnitOfWork uow)
            : base(rep, validation, user, uow)
        { }

		protected override async Task<IEnumerable<TDS>> MapperDomainToDto<TDS>(IEnumerable<UsuarioProjeto> models)
        {
            return await base.MapperDomainToDto<UsuarioProjetoDtoResult>(models) as IEnumerable<TDS>;
        }

    }
}
