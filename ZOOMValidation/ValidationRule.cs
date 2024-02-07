using System;

namespace ZOOMValidation;

public class ValidationRule<T>(string errorMessage, Func<T, bool> check) : IValidationRule<T>
{
  public string ErrorMessage { get; set; } = errorMessage;

  public bool Check(T value)
  {
    return check(value);
  }
}
