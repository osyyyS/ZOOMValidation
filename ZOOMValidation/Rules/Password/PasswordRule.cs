using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZOOMValidation.Rules.Password
{
    public abstract class PasswordRule<T> : IValidationRule<T>
    {
        private readonly int minAmount, maxAmount;
        private readonly Func<char[], int> counter;
        public PasswordRule(Func<char[], int> counter, string errorMessage, int minAmount = 1, int maxAmount = int.MaxValue)
        {
            ErrorMessage = errorMessage;
            this.counter = counter;
            this.minAmount = minAmount;
            this.maxAmount = maxAmount;
        }

        public string ErrorMessage { get; }

        public bool Check(T value)
        {
            if (value is string password)
            {
                int count = counter(password.ToCharArray());
                return maxAmount >= count && count >= minAmount;
            }
            throw new ArgumentException($"Expected string, got {typeof(T).FullName}.");
        }
    }
}
