using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repository.Contracts
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        #region [ Get ]
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");
        #endregion [ Get ]

        #region [ Add ]
        Task AddAsync(TEntity entity);
        #endregion [ Add ]

        #region [ FirstOrDefault ]
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");
        #endregion [ FirstOrDefault ]
    }
}
