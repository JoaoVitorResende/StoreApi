using Contracts.Events;
using Microsoft.Extensions.Logging;
using StoreApi.Application.UseCases.Purchases.StoreApi.Application.UseCases.Purchases.ProcessCreated;
using StoreApi.Domain.Enum;
using StoreApi.Domain.Repositories.Stocks;

namespace StoreApi.Application.UseCases.Purchases
{
    public class ProcessPurchaseCreatedUseCase : IProcessPurchaseCreatedUseCase
    {
        private readonly IItemStockRepository _stockRepository;
        private readonly ILogger<ProcessPurchaseCreatedUseCase> _logger;

        public ProcessPurchaseCreatedUseCase(
            IItemStockRepository stockRepository,
            ILogger<ProcessPurchaseCreatedUseCase> logger)
        {
            _stockRepository = stockRepository;
            _logger = logger;
        }

        public async Task<StockProcessedEvent> Execute(PurchaseCreatedEvent evt)
        {
            ArgumentNullException.ThrowIfNull(evt);

            if (string.IsNullOrWhiteSpace(evt.ItemId) || evt.Quantity <= 0)
            {
                _logger.LogWarning("Compra {Id} com item ou quantidade inválidos.", evt.PurchaseId);
                return new StockProcessedEvent(evt.PurchaseId, false, "Item ou quantidade inválidos.");
            }

            var result = await _stockRepository.DecreaseStockAsync(evt.ItemId, evt.Quantity, evt.PurchaseId);

            switch (result)
            {
                case StockResult.Decreased:
                    _logger.LogInformation("Estoque baixado para a compra {Id}.", evt.PurchaseId);
                    return new StockProcessedEvent(evt.PurchaseId, true, null);

                case StockResult.AlreadyProcessed:
                    _logger.LogInformation("Compra {Id} já havia sido processada.", evt.PurchaseId);
                    return new StockProcessedEvent(evt.PurchaseId, true, null);

                case StockResult.InsufficientStock:
                    _logger.LogWarning("Estoque insuficiente para a compra {Id}.", evt.PurchaseId);
                    return new StockProcessedEvent(evt.PurchaseId, false, "Estoque insuficiente.");

                case StockResult.ItemNotFound:
                    _logger.LogWarning("Item da compra {Id} não encontrado.", evt.PurchaseId);
                    return new StockProcessedEvent(evt.PurchaseId, false, "Item não encontrado.");

                default:
                    _logger.LogError("Resultado inesperado {Result} na compra {Id}.", result, evt.PurchaseId);
                    return new StockProcessedEvent(evt.PurchaseId, false, "Erro ao processar o estoque.");
            }
        }
    }
}
