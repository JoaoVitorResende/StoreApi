namespace StoreApi.Domain.Entities
{
    public class PagedResult<T>
    {
        public List<T> Items { get; set; } = [];
        public long Total { get; set; }
    }
}
