namespace ZOOMValidation.Pair.Rules;

public class EqualStringRule(string errorMessage) : IPairValidationRule<string>
{
  public string ErrorMessage { get; } = errorMessage;

  public bool Check(string value, string value2)
  {
    return value == value2;
  }
}
