using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZOOMValidation.Rules.Password
{
    public class PasswordLengthRule<T> : PasswordRule<T>
    {
        public PasswordLengthRule(string errorMessage, int minimumNumbers = 1, int maximumNumbers = int.MaxValue)
            : base(charArray => charArray.Length, errorMessage, minimumNumbers, maximumNumbers) { }
    }

    public class PasswordNumberRule<T> : PasswordRule<T>
    {
        public PasswordNumberRule(string errorMessage, int minimumNumbers = 1, int maximumNumbers = int.MaxValue)
            : base(charArray => charArray.Count(c => char.IsNumber(c)), errorMessage, minimumNumbers, maximumNumbers) { }
    }

    public class PasswordUppercaseRule<T> : PasswordRule<T>
    {
        public PasswordUppercaseRule(string errorMessage, int minimumNumbers = 1, int maximumNumbers = int.MaxValue)
            : base(charArray => charArray.Count(c => char.IsUpper(c)), errorMessage, minimumNumbers, maximumNumbers) { }
    }

    public class PasswordLowercaseRule<T> : PasswordRule<T>
    {
        public PasswordLowercaseRule(string errorMessage, int minimumNumbers = 1, int maximumNumbers = int.MaxValue)
            : base(charArray => charArray.Count(c => char.IsLower(c)), errorMessage, minimumNumbers, maximumNumbers) { }
    }

    public class PasswordSpecialCharacterRule<T> : PasswordRule<T>
    {
        public PasswordSpecialCharacterRule(string errorMessage, int minimumNumbers = 1, int maximumNumbers = int.MaxValue)
            : base(charArray => charArray.Count(c => !char.IsLetter(c) && !char.IsDigit(c)), errorMessage, minimumNumbers, maximumNumbers) { }
    }
}
