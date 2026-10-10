namespace StoreApi.Exception.ExceptionBase
{
    public abstract class StoreApiException : SystemException
    {
        protected StoreApiException(string message) : base(message)
        {
            
        }
        public abstract int StatusCode { get; }
        public abstract List<string> GetErros();
    }
}
