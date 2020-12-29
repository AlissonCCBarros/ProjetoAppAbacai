using Common.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Threading.Tasks;

namespace Common.Orm
{
    public class UnitOfWork<T> : IUnitOfWork
    {

        private DbContext _ctx;
        private bool _disposed;
        private IDbContextTransaction _transaction;

        public UnitOfWork(T _ctx)
        {
            this._ctx = _ctx as DbContext;
        }

        public void BeginTransaction()
        {
            this._transaction = this._ctx.Database.BeginTransaction();
            _disposed = false;
        }

        public int Commit()
        {
            var result = this._ctx.SaveChanges();
            if (this._transaction.IsNotNull()) this._transaction.Commit();
            return result;
        }

        public void RowbackTransaction()
        {
            if (this._transaction.IsNotNull()) this._transaction.Rollback();
        }

        public async Task<int> CommitAsync()
        {
            var result = await this._ctx.SaveChangesAsync();
            if (this._transaction.IsNotNull()) this._transaction.Commit();
            return result;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _ctx.Dispose();
                }
            }
        }

    }
}
