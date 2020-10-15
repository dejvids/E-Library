using E_Library.Application;

namespace E_Library.Services
{
    public interface IOperationResultHandler
    {
        int HandleOperationResult(OperationResult result, out object value);
    }
}
