using LobInkInterview.DataAccess.Models;
using MongoDB.Driver;

namespace LobInkInterview.DataAccess.Interfaces
{
    public interface IAdventuresRepository
    {
        Task<IEnumerable<AdventureDAL>> GetAllAsync();

        Task<AdventureDAL> GetAsync(Guid id);

        Task CreateAsync(AdventureDAL adventure);

        Task<bool> UpdateAsync(AdventureDAL adventure);

        Task<bool> DeleteAsync(Guid id);
    }
}
