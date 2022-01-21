using DataAccess.DTOs.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logic.Contracts
{
    public interface IBookLogic
    {
        Task<IEnumerable<BookRS>> GetForValueAsync(string value);
    }
}
