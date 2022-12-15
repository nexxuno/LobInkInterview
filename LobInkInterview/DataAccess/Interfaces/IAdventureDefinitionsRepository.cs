using LobInkInterview.DataAccess.Models;
using MongoDB.Driver;

namespace LobInkInterview.DataAccess.Interfaces
{
    public interface IAdventureDefinitionsRepository
    {
        Task<IEnumerable<AdventureDefinitionDAL>> GetAllAsync();

        Task<AdventureDefinitionDAL> GetAsync(Guid id);

        Task CreateAsync(AdventureDefinitionDAL adventureDefinition);

        Task<bool> UpdateAsync(AdventureDefinitionDAL adventureDefinition);

        Task<bool> DeleteAsync(Guid id);
    }
}
