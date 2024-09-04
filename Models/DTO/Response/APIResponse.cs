namespace NetCrud2.Models.DTO.Response
{
    public class APIResponse<T>
    {
        public int Code {  get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public APIResponse()
        {
        }

        public APIResponse(int code, string message)
        {
            Code = code;
            Message = message;
        }

        public APIResponse(int code, string message, T data)
        {
            Code = code;
            Message = message;
            Data = data;
        }
    }
}
