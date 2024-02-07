namespace ZOOMValidation.Rules;

public class NotNullOrEmptyRule<T>(string errorMessage) : IValidationRule<T>
{
  public string ErrorMessage { get; } = errorMessage;

  public bool Check(T value)
  {
    return !string.IsNullOrEmpty($"{value}");
  }
}
