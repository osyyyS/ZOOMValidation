using System;

namespace ZOOMValidation
{
    public class ValidationRule<T> : IValidationRule<T>
    {
        public ValidationRule(string errorMessage, Func<T, bool> check)
        {
            ErrorMessage = errorMessage;
            this.check = check;
        }
        public string ErrorMessage { get; set; }

        private readonly Func<T, bool> check;
        public bool Check(T value)
        {
            return check(value);
        }
    }
}
