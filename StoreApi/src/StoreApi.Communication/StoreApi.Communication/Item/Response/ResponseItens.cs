namespace StoreApi.Communication.Item.Response
{
    public class ResponseItens
    {
        public List<ResponseItemJson> Itens { get; set; } = [];
        public int Page { get; set; }
        public int PageSize { get; set; }
        public long TotalItens { get; set; }
        public int TotalPages { get; set; }
    }
}
