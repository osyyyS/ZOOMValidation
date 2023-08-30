using System;

namespace ZOOMValidation.Pair
{
    public class PairValidationRule<T> : IPairValidationRule<T>
    {
        public PairValidationRule(string errorMessage, Func<T, T, bool> check)
        {
            ErrorMessage = errorMessage;
            this.check = check;
        }
        public string ErrorMessage { get; set; }

        private readonly Func<T, T, bool> check;
        public bool Check(T value, T value2)
        {
            return check(value, value2);
        }
    }
}
