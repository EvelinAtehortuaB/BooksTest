using DataAccess.DTOs.Request;
using DataAccess.DTOs.Response;
using System.Threading.Tasks;

namespace Logic.Contracts
{
    public interface IEditorialLogic
    {
        Task<EditorialRS> AddAsync(EditorialRQ source);

        Task<int> GetMaximumAllowedAsync(int id);
    }
}
