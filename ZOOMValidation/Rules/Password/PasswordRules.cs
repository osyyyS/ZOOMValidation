using System.Linq;

namespace ZOOMValidation.Rules.Password;

public class PasswordLengthRule(string errorMessage, int minLength = 1, int maxLength = int.MaxValue) : PasswordRule(charArray => charArray.Length, errorMessage, minLength, maxLength)
{
}

public class PasswordNumberRule(string errorMessage, int minNumbers = 1, int maxNumbers = int.MaxValue) : PasswordRule(charArray => charArray.Count(c => char.IsNumber(c)), errorMessage, minNumbers, maxNumbers)
{
}

public class PasswordUppercaseRule(string errorMessage, int minUppercase = 1, int maxUppercase = int.MaxValue) : PasswordRule(charArray => charArray.Count(c => char.IsUpper(c)), errorMessage, minUppercase, maxUppercase)
{
}

public class PasswordLowercaseRule(string errorMessage, int minLowercase = 1, int maxLowercase = int.MaxValue) : PasswordRule(charArray => charArray.Count(c => char.IsLower(c)), errorMessage, minLowercase, maxLowercase)
{
}

public class PasswordSpecialCharacterRule(string errorMessage, int minSpecialCharacters = 1, int maxSpecialCharacters = int.MaxValue) : PasswordRule(charArray => charArray.Count(c => !char.IsLetter(c) && !char.IsDigit(c)), errorMessage, minSpecialCharacters, maxSpecialCharacters)
{
}
