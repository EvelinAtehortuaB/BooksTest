using DataAccess.Contracts;
using DataAccess.Implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementation
{
    public class UnitOfWork: IUnitOfWork
    {
        #region [ Statements ]
        private bool disposed = false;
        public IDbContext _dbContext { get; set; }
        private readonly IDbContextTransaction _transaction;
        #endregion [ Statements ]

        #region [ Properties ]
        DbContext IUnitOfWork.Context => _dbContext as DbContext;
        #endregion [ Properties ]

        #region [ Privates ]
        private IGenericRepository<Author> _author;
        private IGenericRepository<Book> _book;
        private IGenericRepository<Editorial> _editorial;
        #endregion [ Privates ]

        #region [ Repositories ]
        public IGenericRepository<Author> Author => _author = _author ?? new GenericRepository<Author>(this);
        public IGenericRepository<Book> Book => _book = _book ?? new GenericRepository<Book>(this);
        public IGenericRepository<Editorial> Editorial => _editorial = _editorial ?? new GenericRepository<Editorial>(this);
        #endregion [ Repositories ]

        #region [ Constructor ]
        public UnitOfWork(IDbContext dbContext)
        {
            _dbContext = dbContext;
            var _dataBase = (_dbContext as DbContext);

            if (_dataBase.Database.GetDbConnection().State != ConnectionState.Open)
            {
                _dataBase.Database.OpenConnection();
            }
            this._transaction = _dataBase.Database.BeginTransaction();
        }
        #endregion [ Constructor ]

        #region [ Commit ]
        public async Task CommitAsync()
        {
            try
            {
                await (_dbContext as DbContext).SaveChangesAsync();
                _transaction.Commit();
            }
            catch (Exception)
            {
                Rollback();
                throw;
            }
        }

        public void Commit()
        {
            try
            {
                (_dbContext as DbContext).SaveChanges();
                _transaction.Commit();
            }
            catch (Exception)
            {
                Rollback();
                throw;
            }
        }
        #endregion [ Commit ]

        #region [ Save ]
        public async Task<int> SaveAsync()
        {
            try
            {
                return await (_dbContext as DbContext).SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Save()
        {
            try
            {
                return (_dbContext as DbContext).SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion [ Save ]

        #region [ Rollback ]
        public void Rollback()
        {
            _transaction.Rollback();
            var _context = _dbContext as DbContext;
            foreach (var entry in _context.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.State = EntityState.Unchanged;
                        break;

                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;

                    case EntityState.Deleted:
                        entry.State = EntityState.Unchanged;
                        break;
                }
            }
        }
        #endregion [ Rollback ]

        #region [ Dispose ]
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    var _dataBase = _dbContext as DbContext;
                    if (_dataBase.Database.GetDbConnection().State == ConnectionState.Open)
                    {
                        _dataBase.Database.CloseConnection();
                        _dbContext.Dispose();
                    }
                }
            }
            this.disposed = true;
        }
        #endregion [ Dispose ]
    }
}
