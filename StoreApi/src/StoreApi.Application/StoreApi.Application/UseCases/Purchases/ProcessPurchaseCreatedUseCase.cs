using Contracts.Events;
using Microsoft.Extensions.Logging;
using StoreApi.Application.UseCases.Purchases.StoreApi.Application.UseCases.Purchases.ProcessCreated;

namespace StoreApi.Application.UseCases.Purchases
{
    public class ProcessPurchaseCreatedUseCase : IProcessPurchaseCreatedUseCase
    {
        private readonly ILogger<ProcessPurchaseCreatedUseCase> _logger;

        public ProcessPurchaseCreatedUseCase(ILogger<ProcessPurchaseCreatedUseCase> logger)
            => _logger = logger;

        public Task Execute(PurchaseCreatedEvent evt)
        {
            ArgumentNullException.ThrowIfNull(evt);

            // regra de negócio entra aqui depois
            _logger.LogInformation("UseCase processando a compra {Id}", evt.PurchaseId);

            return Task.CompletedTask;
        }
    }
}
