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
    public class AtividadeService : AtividadeServiceBase
    {
        ProjetoAtividadeRepository _repProjetoAtividade;
        public AtividadeService(AtividadeRepository rep, ValidationContract validation, ProjetoAtividadeRepository repProjetoAtividade, CurrentUser user, IUnitOfWork uow)
            : base(rep, validation, user, uow)
        {
            this._repProjetoAtividade = repProjetoAtividade;
        }

		protected override async Task<IEnumerable<TDS>> MapperDomainToDto<TDS>(IEnumerable<Atividade> models)
        {
            return await base.MapperDomainToDto<AtividadeDtoResult>(models) as IEnumerable<TDS>;
        }

        public override Atividade Save(Atividade model)
        {
            var result = base.Save(model);


            if (result.IsNotNull())
            {


                ProjetoAtividade objPA = new ProjetoAtividade();
                objPA.AtividadeId = result.AtividadeId;
                objPA.ProjetoId = result.ProjetoId;
                objPA.ProjetoAtividadeId = 0;
                this._repProjetoAtividade.Add(objPA);
            }

            return result;
        }

    }
}
