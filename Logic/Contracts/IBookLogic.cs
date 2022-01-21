using DataAccess.DTOs.Request;
using DataAccess.DTOs.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logic.Contracts
{
    public interface IBookLogic
    {
        Task<BookRS> AddAsync(BookRQ source);
        Task<IEnumerable<BookRS>> GetForValueAsync(string value);
    }
}
