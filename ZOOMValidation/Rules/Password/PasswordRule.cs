using System;

namespace ZOOMValidation.Rules.Password
{
    public abstract class PasswordRule : IValidationRule<string>
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

        public bool Check(string value)
        {
            int count = counter(value.ToCharArray());
            return maxAmount >= count && count >= minAmount;
        }
    }
}
