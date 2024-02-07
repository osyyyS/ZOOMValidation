using System;
using System.Threading.Tasks;

namespace ZOOMValidation;

public class AsyncValidationRule<T>(string errorMessage, Func<T, Task<bool>> check) : IAsyncValidationRule<T>
{
  public string ErrorMessage { get; set; } = errorMessage;

  public Task<bool> CheckAsync(T value)
  {
    return check(value);
  }
}
