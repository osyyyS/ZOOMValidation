using System.Threading.Tasks;

namespace ZOOMValidation.Pair;

public interface IAsyncPairValidationRule<T>
{
  string ErrorMessage { get; }
  Task<bool> CheckAsync(T value, T value2);
}
