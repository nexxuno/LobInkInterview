using LobInkInterview.DataAccess.Interfaces;
using LobInkInterview.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace LobInkInterview.DataAccess.Repositories
{
    public class AdventureDefinitionsRepository : IAdventureDefinitionsRepository
    {
        private readonly IDBContext dbContext;

        public AdventureDefinitionsRepository(IDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<AdventureDefinitionDAL>> GetAllAsync()
        {
            //will implement pagination here and in controller in future versions..

            return await dbContext
                .AdventureDefinitions
                .Find(_ => true)
                .ToListAsync();
        }

        public async Task<AdventureDefinitionDAL> GetAsync(Guid id)
        {
            FilterDefinition<AdventureDefinitionDAL> filter = Builders<AdventureDefinitionDAL>.Filter.Eq(m => m.Id, id);
            return await dbContext
                    .AdventureDefinitions
                    .Find(filter)
                    .FirstOrDefaultAsync();
        }

        public async Task CreateAsync(AdventureDefinitionDAL adventureDefinition)
        {
            await dbContext.AdventureDefinitions.InsertOneAsync(adventureDefinition);
        }

        public async Task<bool> UpdateAsync(AdventureDefinitionDAL adventureDefinition)
        {
            ReplaceOneResult updateResult =
                await dbContext
                        .AdventureDefinitions
                        .ReplaceOneAsync(
                            filter: g => g.Id == adventureDefinition.Id,
                            replacement: adventureDefinition);
            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            FilterDefinition<AdventureDefinitionDAL> filter = Builders<AdventureDefinitionDAL>.Filter.Eq(m => m.Id, id);
            DeleteResult deleteResult = await dbContext
                                                .AdventureDefinitions
                                              .DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }
    }
}
