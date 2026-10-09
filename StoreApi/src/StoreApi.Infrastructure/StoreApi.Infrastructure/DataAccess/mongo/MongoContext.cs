using MongoDB.Driver;
using StoreApi.Domain.Entities;

namespace StoreApi.Infrastructure.DataAccess.mongo
{
    internal class MongoContext
    {
        private readonly IMongoDatabase _database;

        public MongoContext(IMongoClient client, string databaseName)
        {
            _database = client.GetDatabase(databaseName);
            CreateIndexes();
        }

        public IMongoCollection<Item> Items => _database.GetCollection<Item>("items");

        // Sem índice, filtrar por StoreId/CategoryId varre a coleção inteira
        private void CreateIndexes()
        {
            var keys = Builders<Item>.IndexKeys
                .Ascending(i => i.StoreId)
                .Ascending(i => i.CategoryId);

            Items.Indexes.CreateOne(new CreateIndexModel<Item>(keys));
        }
    }
}
