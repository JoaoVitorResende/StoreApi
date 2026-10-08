namespace StoreApi.Domain.Entities
{
    public class Store
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
}
