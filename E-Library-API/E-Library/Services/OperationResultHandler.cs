using E_Library.Application;
using Microsoft.Extensions.Logging;

namespace E_Library.Services
{
    public class OperationResultHandler : IOperationResultHandler
    {
        private readonly ILogger _logger;

        public OperationResultHandler(ILogger<OperationResultHandler> logger)
        {
            _logger = logger;
        }
        public int HandleOperationResult(OperationResult result, out object value)
        {
            value = result.Message ?? "";

            if (!result.Result)
                _logger.LogError(result.Error);

            return (int)result.ResultType;
        }
    }
}
