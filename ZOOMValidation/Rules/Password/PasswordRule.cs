using System;

namespace ZOOMValidation.Rules.Password;

public abstract class PasswordRule(Func<char[], int> counter, string errorMessage, int minAmount = 1, int maxAmount = int.MaxValue) : IValidationRule<string>
{
  public string ErrorMessage { get; } = errorMessage;

  public bool Check(string value)
  {
    int count = counter(value.ToCharArray());
    return maxAmount >= count && count >= minAmount;
  }
}
