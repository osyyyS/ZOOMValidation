using System;

namespace ZOOMValidation.Pair;

public class PairValidationRule<T>(string errorMessage, Func<T, T, bool> check) : IPairValidationRule<T>
{
  public string ErrorMessage { get; set; } = errorMessage;

  public bool Check(T value, T value2)
  {
    return check(value, value2);
  }
}
