namespace LobInkInterview.DataAccess.Interfaces
{
    using LobInkInterview.DataAccess.Models;
    using MongoDB.Driver;
    public interface IDBContext
    {
        IMongoCollection<AdventureDefinitionDAL> AdventureDefinitions { get; }
        IMongoCollection<AdventureDAL> Adventures { get; }
    }
}
