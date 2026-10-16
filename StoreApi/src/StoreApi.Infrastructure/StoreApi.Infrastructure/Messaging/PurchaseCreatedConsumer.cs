using MassTransit;
using Microsoft.Extensions.Logging;
using StoreApi.Domain.Events;

namespace StoreApi.Infrastructure.Messaging
{
    public class PurchaseCreatedConsumer : IConsumer<PurchaseCreatedEvent>
    {
        private readonly ILogger<PurchaseCreatedConsumer> _logger;

        public PurchaseCreatedConsumer(ILogger<PurchaseCreatedConsumer> logger)
            => _logger = logger;

        public Task Consume(ConsumeContext<PurchaseCreatedEvent> context)
        {
            var evt = context.Message;

            if (evt is null || evt.PurchaseId == Guid.Empty)
            {
                _logger.LogWarning("Evento de compra inválido recebido.");
                return Task.CompletedTask;
            }

            _logger.LogInformation("Compra {Id} recebida, total {Total}", evt.PurchaseId, evt.Total);

            // aqui você chama um UseCase da Application
            return Task.CompletedTask;
        }
    }
}
