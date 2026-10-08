namespace StoreApi.Domain.Entities
{
    public class Item
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public long CategoryId { get; set; }
        public long StoreId { get; set; }
    }
}
