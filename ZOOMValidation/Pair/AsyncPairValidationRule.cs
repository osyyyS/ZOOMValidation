using System;
using System.Threading.Tasks;

namespace ZOOMValidation.Pair;

public class AsyncPairValidationRule<T>(string errorMessage, Func<T, T, Task<bool>> check) : IAsyncPairValidationRule<T>
{
  public string ErrorMessage { get; set; } = errorMessage;

  public Task<bool> CheckAsync(T value, T value2)
  {
    return check(value, value2);
  }
}
