using Common.Domain.Base;
using Common.Domain.Interfaces;
using Common.Domain.Model;
using Common.Validation;
using Project.Core.Dto;
using Project.Core.Filters;
using Project.Core.Data.Model;
using Project.Core.Data.Repository;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Project.Core.Services
{
    public class HabilidadeServiceBase : ServiceBase<Habilidade, HabilidadeDto, HabilidadeDtoSave, HabilidadeFilter>, IService
    {
        protected HabilidadeRepository _rep;
        protected CurrentUser _user;

        public HabilidadeServiceBase(HabilidadeRepository rep, ValidationContract validation, CurrentUser user, IUnitOfWork uow)
            : base(rep, uow, validation)
        {
            this._rep = rep;
            this._user = user;
        }

		public virtual async Task<IEnumerable<dynamic>> GetDataItems(HabilidadeFilter filters)
        {
            return await Task.Run(() =>
            {
                return this._rep.GetDataItems(filters);
            });
        }

        public virtual async Task<SearchResult<HabilidadeDto>> GetByFiltersPaging(HabilidadeFilter filters)
        {
            var queryBase = this._rep.GetByFilters(filters);
            var paginated = await this._rep.PagingAndOrdering(filters, queryBase);
            return await this.SearchResult(filters, paginated, queryBase);
        }

        public virtual async Task<HabilidadeDto> GetById(HabilidadeFilter filters)
        {
            var alvo = this._rep.GetById(filters);
            var result = await MapperDomainToDto<HabilidadeDtoDetail>(alvo);
            return result;
        }
		
        public virtual Habilidade GetByModel(Habilidade model)
        {
            var alvo = this._rep.GetByModel(model);
            return alvo;
        }

        public override Habilidade Save(Habilidade model)
        {
            var alvo = this.GetByModel(model);

            

            this.MakeValidations(model, alvo);

            if (!this.IsValid())
                return model;

            if (alvo.IsNull())
                alvo = this._rep.Add(model);
            else
                alvo = this._rep.Update(model);

            return alvo;
        }



        public virtual void MakeValidations(Habilidade model, Habilidade modelOld)
        {
            if (model.IsNull())
                this._validation.AddNotification("ITEM_ENVIADO", "Item enviado não contém propriedades");
        }

    }
}
