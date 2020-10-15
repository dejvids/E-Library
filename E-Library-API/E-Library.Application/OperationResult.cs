namespace E_Library.Application
{
    public enum ResultType
    {
        Ok = 200,
        BadRequest = 400,
        NotFound = 404
    }
    public class OperationResult
    {
        public bool Result { get; }
        public string Error { get; }
        public ResultType ResultType { get; }
        public string Message { get; }

        public OperationResult()
        {
            Result = true;
            Error = string.Empty;
            ResultType = ResultType.Ok;
        }

        public OperationResult(string error, ResultType resultType, string message = null)
        {
            Result = false;
            Error = error;
            ResultType = resultType;
            Message = message;
        }
    }
}
