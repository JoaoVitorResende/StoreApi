namespace StoreApi.Domain.Events
{
    public record PurchaseCreatedEvent(Guid PurchaseId, decimal Total, DateTime CreatedAt);
}
