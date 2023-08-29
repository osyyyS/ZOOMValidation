using System.Threading.Tasks;

namespace ZOOMValidation
{
    public interface IAsyncValidationRule<T>
    {
        string ErrorMessage { get; set; }
        Task<bool> CheckAsync(T value);
    }
}
