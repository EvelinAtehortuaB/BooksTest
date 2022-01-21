using DataAccess.Implementation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Repository.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        #region [ Properties ]
        DbContext Context { get; }
        #endregion [ Properties ]

        #region [ Methods ]
        int Save();
        Task<int> SaveAsync();
        void Rollback();
        void Commit();
        Task CommitAsync();
        #endregion [ Methods ]

        #region [ Repositories ]
        IGenericRepository<Author> Author { get; }
        IGenericRepository<Book> Book { get; }
        IGenericRepository<Editorial> Editorial { get; }
        #endregion [ Repositories ]

    }
}
