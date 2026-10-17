using StoreApi.Domain.Enum;

namespace StoreApi.Domain.Repositories.Stocks
{
    public interface IItemStockRepository
    {
        Task<StockResult> DecreaseStockAsync(string itemId, decimal quantity, Guid purchaseId, CancellationToken ct = default);
    }
}
