using System;

namespace ZOOMValidation.Pair.Rules
{
    public class EqualStringRule<T> : IPairValidationRule<T>
    {
        public EqualStringRule(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
        public string ErrorMessage { get; }

        public bool Check(T value, T value2)
        {
            if (value is string string1 && value2 is string string2)
            {
                return string1 == string2;
            }
            throw new ArgumentException($"Expected string, got {typeof(T).FullName}.");
        }
    }
}
