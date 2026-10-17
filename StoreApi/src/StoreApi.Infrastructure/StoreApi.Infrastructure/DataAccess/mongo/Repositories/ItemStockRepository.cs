using MongoDB.Bson;
using MongoDB.Driver;
using StoreApi.Domain.Entities;
using StoreApi.Domain.Enum;
using StoreApi.Domain.Repositories.Stocks;

namespace StoreApi.Infrastructure.DataAccess.mongo.Repositories
{
    internal class ItemStockRepository : IItemStockRepository
    {
        private readonly IMongoCollection<Item> _items;

        public ItemStockRepository(MongoContext context)
        {
            _items = context.Items;
        }

        public async Task<StockResult> DecreaseStockAsync(string itemId, decimal quantity, Guid purchaseId, CancellationToken ct = default)
        {
            if (!ObjectId.TryParse(itemId, out var objectId))
                return StockResult.ItemNotFound;

            var purchaseKey = purchaseId.ToString();

            var filter = Builders<Item>.Filter.And(
                Builders<Item>.Filter.Eq("_id", objectId),
                Builders<Item>.Filter.Gte(i => i.Quantity, quantity),
                Builders<Item>.Filter.AnyNe(i => i.ProcessedPurchases, purchaseKey));

            var update = Builders<Item>.Update
                .Inc(i => i.Quantity, -quantity)
                .Push(i => i.ProcessedPurchases, purchaseKey);

            var result = await _items.UpdateOneAsync(filter, update, cancellationToken: ct);
            if (result.ModifiedCount == 1)
                return StockResult.Decreased;

            var item = await _items.Find(Builders<Item>.Filter.Eq("_id", objectId)).FirstOrDefaultAsync(ct);
            if (item is null) return StockResult.ItemNotFound;
            if (item.ProcessedPurchases?.Contains(purchaseKey) == true) return StockResult.AlreadyProcessed;
            return StockResult.InsufficientStock;
        }
    }
}
