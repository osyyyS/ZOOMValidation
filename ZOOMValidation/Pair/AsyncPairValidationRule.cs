using System;
using System.Threading.Tasks;

namespace ZOOMValidation.Pair;

public class AsyncPairValidationRule<T>(string errorMessage, Func<T, T, Task<bool>> check) : IAsyncPairValidationRule<T>
{
  public string ErrorMessage { get; set; } = errorMessage;

  public async Task<bool> CheckAsync(T value, T value2)
  {
    return await check(value, value2);
  }
}
