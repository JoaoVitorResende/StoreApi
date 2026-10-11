namespace StoreApi.Communication.Item.Response
{
    public class ResponseRegisterItemJson
    {
        public string Id { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public long CategoryId { get; set; }
        public long StoreId { get; set; }
    }
}
