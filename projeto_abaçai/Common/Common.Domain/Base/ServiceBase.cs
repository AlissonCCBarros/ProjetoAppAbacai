using Common.Domain.Interfaces;
using Common.Domain.Model;
using Common.Validation;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Domain.Base
{
    public abstract class ServiceBase<T, TDto, TDtoSave, TFilter>
        where TDto : class
        where TDtoSave : class
        where TFilter : class
    {
        protected readonly IUnitOfWork _uow;
        protected readonly IRepository<T> _repBase;

        protected ValidationContract _validation;

        public ServiceBase(IRepository<T> repBase, IUnitOfWork uow, ValidationContract validation)
        {
            this._uow = uow;
            this._repBase = repBase;
            this._validation = validation;
        }

        public bool IsInvalid()
        {
            return this._validation.Invalid;
        }

        public bool IsValid()
        {
            return this._validation.Valid;
        }

        public List<string> GetValidationErrors()
        {
            if (this._validation.Invalid && this._validation.Notifications.Count() > 0)
                return this._validation.Notifications.Select(_ => _.Message).ToList();

            return new List<string>();
        }

        public void BeginTransaction()
        {
            _uow.BeginTransaction();
        }

        public void RowbackTransaction()
        {
            _uow.RowbackTransaction();
        }

        public async Task<int> Commit()
        {
            return await _uow.CommitAsync();
        }

        public int CommitSync()
        {
            return _uow.Commit();
        }

        public virtual async Task<int> Remove(TDto entity)
        {
            this.BeginTransaction();

            var model = await this.MapperDtoToDomain(entity);

            this._repBase.Remove(model);

            return await this.Commit();
        }

        public virtual async Task<TDtoSave> Save(TDtoSave entity)
        {
            var model = await this.MapperDtoToDomain(entity);

            this.BeginTransaction();

            var resultDomain = this.Save(model);

            if (!this.IsValid())
            {
                this.RowbackTransaction();
                return entity;
            }

            await this.Commit();

            return await this.MapperDomainToDto<TDtoSave>(resultDomain);
        }

        public virtual async Task<TDtoSave> SavePartial(TDtoSave entity)
        {
            return await this.Save(entity);
        }

        public abstract T Save(T entity);

        protected async virtual Task<T> MapperDtoToDomain<TDS>(TDS dto) where TDS : class
        {
            return await Task.Run(() =>
            {
                var result = AutoMapper.Mapper.Map<TDS, T>(dto);
                return result;
            });
        }

        protected async virtual Task<TDS> MapperDomainToDto<TDS>(T model) where TDS : class
        {
            return await Task.Run(() =>
            {
                return AutoMapper.Mapper.Map<T, TDS>(model);
            });
        }

        protected async virtual Task<IEnumerable<TDS>> MapperDomainToDto<TDS>(IEnumerable<T> models) where TDS : class
        {
            return await Task.Run(() =>
            {
                return AutoMapper.Mapper.Map<IEnumerable<T>, IEnumerable<TDS>>(models);
            });
        }

        protected async virtual Task<SearchResult<TDto>> SearchResult(FilterBase filters, PaginateResult<T> paginated, IQueryable<T> source)
        {
            return await Task.Run(() =>
            {
                var result = this.MapperDomainToDto<TDto>(paginated.ResultPaginatedData).Result;
                return new SearchResult<TDto>
                {
                    DataList = result,
                    Summary = new Summary
                    {
                        Total = paginated.TotalCount,
                        PageSize = paginated.PageSize,
                        Data = this.MakeDataSummary(filters, paginated, source)
                    },
                };
            });
        }

        protected virtual object MakeDataSummary(FilterBase filters, PaginateResult<T> paginated, IQueryable<T> source)
        {
            return null;
        }

    }

}
