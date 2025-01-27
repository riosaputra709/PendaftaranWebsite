namespace APIRegistration.Models.Response
{
    public class ResponseAPI<T>
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }

    public class ResponseAPI
    {
        public string Status { get; set; }
        public string Message { get; set; }
    }

}
