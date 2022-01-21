using DataAccess.DTOs.Request;
using DataAccess.DTOs.Response;
using System.Threading.Tasks;

namespace Logic.Contracts
{
    public interface IAuthorLogic
    {
        Task<AuthorRS> AddAsync(AuthorRQ source);
    }
}
