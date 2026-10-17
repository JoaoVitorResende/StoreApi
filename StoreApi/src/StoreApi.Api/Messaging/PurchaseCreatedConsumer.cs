using Contracts.Events;
using MassTransit;
using StoreApi.Application.UseCases.Purchases.StoreApi.Application.UseCases.Purchases.ProcessCreated;

namespace StoreApi.Api.Messaging
{
    public class PurchaseCreatedConsumer : IConsumer<PurchaseCreatedEvent>
    {
        private readonly IProcessPurchaseCreatedUseCase _useCase;
        private readonly ILogger<PurchaseCreatedConsumer> _logger;

        public PurchaseCreatedConsumer(
            IProcessPurchaseCreatedUseCase useCase,
            ILogger<PurchaseCreatedConsumer> logger)
        {
            _useCase = useCase;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<PurchaseCreatedEvent> context)
        {
            var evt = context.Message;

            if (evt is null || evt.PurchaseId == Guid.Empty)
            {
                _logger.LogWarning("Evento de compra inválido recebido.");
                return;
            }

            _logger.LogInformation("Compra {Id} recebida, total {Total}", evt.PurchaseId, evt.Total);

            await _useCase.Execute(evt);
        }
    }
}
