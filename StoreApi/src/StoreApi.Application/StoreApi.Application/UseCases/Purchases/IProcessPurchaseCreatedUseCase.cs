using Contracts.Events;

namespace StoreApi.Application.UseCases.Purchases
{
    namespace StoreApi.Application.UseCases.Purchases.ProcessCreated
    {
        public interface IProcessPurchaseCreatedUseCase
        {
            Task Execute(PurchaseCreatedEvent evt);
        }
    }
}
