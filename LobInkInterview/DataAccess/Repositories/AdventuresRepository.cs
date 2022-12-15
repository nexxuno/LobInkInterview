using LobInkInterview.DataAccess.Interfaces;
using LobInkInterview.DataAccess.Models;
using MongoDB.Driver;

namespace LobInkInterview.DataAccess.Repositories
{
    public class AdventuresRepository : IAdventuresRepository
    {
        private readonly IDBContext dbContext;

        public AdventuresRepository(IDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<AdventureDAL>> GetAllAsync()
        {
            //will implement pagination here and in controller in future versions..

            return await dbContext
                .Adventures
                .Find(_ => true)
                .ToListAsync();
        }

        public async Task<AdventureDAL> GetAsync(Guid id)
        {
            FilterDefinition<AdventureDAL> filter = Builders<AdventureDAL>.Filter.Eq(m => m.Id, id);
            return await dbContext
                    .Adventures
                    .Find(filter)
                    .FirstOrDefaultAsync();
        }

        public async Task CreateAsync(AdventureDAL adventure)
        {
            await dbContext.Adventures.InsertOneAsync(adventure);
        }

        public async Task<bool> UpdateAsync(AdventureDAL adventure)
        {
            ReplaceOneResult updateResult =
                await dbContext
                        .Adventures
                        .ReplaceOneAsync(
                            filter: g => g.Id == adventure.Id,
                            replacement: adventure);
            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            FilterDefinition<AdventureDAL> filter = Builders<AdventureDAL>.Filter.Eq(m => m.Id, id);
            DeleteResult deleteResult = await dbContext
                                                .Adventures
                                              .DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }
    }
}
