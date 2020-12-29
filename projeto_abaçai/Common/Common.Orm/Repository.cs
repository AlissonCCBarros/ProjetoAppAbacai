using Common.Domain.Base;
using Common.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Common.Orm
{
    public class Repository<T> : IRepository<T> where T : class
    {

        protected DbContext ctx;
        protected DbSet<T> dbSet;

        public Repository(DbContext ctx)
        {
            this.ctx = ctx;
            this.dbSet = this.ctx.Set<T>();
        }

        public virtual IQueryable<T> GetAll()
        {
            return this.dbSet.AsNoTracking();
        }

        public virtual T Get(params object[] keyValues)
        {
            return this.dbSet.Find(keyValues);
        }

        public virtual IQueryable<T> GetAll(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = ctx.Set<T>();
            return includes.Aggregate(query, (current, include) => current.Include(include)).AsNoTracking();
        }

        public virtual IQueryable<T> GetAllAsTracking(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = ctx.Set<T>();
            return includes.Aggregate(query, (current, include) => current.Include(include));
        }

        public virtual T Add(T entity)
        {
            var result = this.dbSet.Add(entity);
            return result.Entity;
        }

        public virtual IEnumerable<T> Add(IEnumerable<T> entitys)
        {
            var _entitys = new List<T>();
            foreach (var entity in entitys)
                _entitys.Add(this.dbSet.Add(entity).Entity);

            return _entitys;
        }

        public virtual T Update(T entity)
        {
            var entry = this.ctx.Entry(entity);
            this.dbSet.Attach(entity);
            entry.State = EntityState.Modified;
            return entity;
        }

        public virtual IEnumerable<T> Update(IEnumerable<T> entitys)
        {
            var entitysUpdated = new List<T>();
            foreach (var entity in entitys)
                entitysUpdated.Add(this.Update(entity));
            return entitysUpdated;
        }

        public virtual void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public virtual void Remove(IEnumerable<T> entitys)
        {
            dbSet.RemoveRange(entitys);
        }

        public virtual async Task<PaginateResult<T>> Paging(FilterBase filters, IQueryable<T> queryFilter)
        {
            var totalCount = await this.CountAsync(queryFilter);
            var paginateResult = await this.Paging(filters, queryFilter, totalCount).ToListAsync();

            return new PaginateResult<T>
            {
                TotalCount = totalCount,
                PageSize = filters.PageSize,
                ResultPaginatedData = paginateResult,
                Source = queryFilter
            };
        }


        public virtual async Task<PaginateResult<T>> PagingAndOrdering(FilterBase filters, IQueryable<T> queryFilter)
        {
            var orderedQuery = queryFilter.OrderByProperty(filters);
            return await this.Paging(filters, orderedQuery);
        }

        #region async

        public Task<List<T2>> ToListAsync<T2>(IQueryable<T2> source)
        {
            return source.ToListAsync();
        }

        public Task<T2> SingleOrDefaultAsync<T2>(IQueryable<T2> source)
        {
            return source.SingleOrDefaultAsync();
        }

        public Task<T2> FirstOrDefaultAsync<T2>(IQueryable<T2> source)
        {
            return source.FirstOrDefaultAsync();
        }

        public Task<int> CountAsync<T2>(IQueryable<T2> source)
        {
            return source.CountAsync();
        }

        public Task<decimal> SumAsync<T2>(IQueryable<T2> source, Expression<Func<T2, decimal>> selector)
        {
            return source.SumAsync(selector);
        }

        public Task<int> CommitAsync()
        {
            return this.ctx.SaveChangesAsync();
        }

        public int Commit()
        {
            return this.ctx.SaveChanges();
        }

        #endregion

        #region helpers

        private IQueryable<T2> Paging<T2>(FilterBase filter, IQueryable<T2> source, int totalCount)
        {
            if (filter.IsPagination)
            {
                var pageIndex = filter.PageIndex > 0 ? filter.PageIndex - 1 : 0;
                var pageSize = filter.PageSize;
                var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

                return source.Skip(filter.PageSkipped).Take(pageSize);
            }

            return source;
        }


        #endregion

    }

}
