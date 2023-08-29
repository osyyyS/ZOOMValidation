using System.Threading.Tasks;

namespace ZOOMValidation
{
    public interface IAsyncValidationRule<T>
    {
        string ErrorMessage { get; }
        Task<bool> CheckAsync(T value);
    }
}
