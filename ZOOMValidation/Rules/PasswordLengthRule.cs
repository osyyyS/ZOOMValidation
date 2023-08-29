using System;

namespace ZOOMValidation.Rules
{
    public class PasswordLengthRule<T> : IValidationRule<T>
    {
        private readonly int minimumLength, maximumLength;

        public PasswordLengthRule(int minimumLength, int maximumLength, string errorMessage)
        {
            ErrorMessage = errorMessage;
            this.minimumLength = minimumLength;
            this.maximumLength = maximumLength;
        }

        public string ErrorMessage { get; }

        public bool Check(T value)
        {
            if (value is string password)
            {
                return maximumLength <= password.Length && password.Length >= minimumLength;
            }
            throw new ArgumentException($"Expected string, got {typeof(T).FullName}.");
        }
    }
}
