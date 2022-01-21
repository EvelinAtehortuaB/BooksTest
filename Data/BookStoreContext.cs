using DataAccess.Contracts;
using DataAccess.Implementation;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class BookStoreContext: DbContext, IDbContext
    {
        #region [ Constructor ]
        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options)
        {
        }
        #endregion [ Constructor ]

        #region [ DbSets ]
        public DbSet<Author> Author { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<Editorial> Editorial { get; set; }
        #endregion [ DbSets ]

    }
}
