using System;

namespace ZOOMValidation.Rules;

public class ValidEmailRule(string errorMessage, bool removeWhiteSpaces = true) : IValidationRule<string>
{
  public string ErrorMessage { get; } = errorMessage;

  public bool Check(string value)
  {
    value = removeWhiteSpaces ? value.Replace(" ", "") : value;

    try
    {
      var addr = new System.Net.Mail.MailAddress(value);
      return addr.Address == $"{addr}";
    }
    catch (FormatException)
    {
      return false;
    }
  }
}
