namespace TestQuala.Domain.Entities.Common
{
    public class ResponseModel<T>
    {

        public ResponseModel(T data, string message = null)
        {
            Succeeded = true;
            Message = message;
            Data = data;
        }

        public ResponseModel(bool Success, string message = null)
        {
            Succeeded = Success;
            Message = message;
        }


        public ResponseModel(object data, string message = null)
        {
            Succeeded = true;
            Message = message;
            Data = (T)data;
        }


        public ResponseModel(string message)
        {
            Succeeded = false;
            Message = message;
        }

        public ResponseModel(string message, int errorType)
        {
            Succeeded = false;
            Message = message;
            ErrorType = errorType;
        }

        public bool Succeeded { get; set; }
        public string Message { get; set; } = string.Empty;
        public T Data { get; set; }

        public int ErrorType { get; set; }

    }

}
