using System;
using System.Threading.Tasks;

namespace ZOOMValidation.Pair
{
    public class AsyncPairValidationRule<T> : IAsyncPairValidationRule<T>
    {
        public AsyncPairValidationRule(string errorMessage, Func<T, T, Task<bool>> check)
        {
            ErrorMessage = errorMessage;
            this.check = check;
        }
        public string ErrorMessage { get; set; }

        private readonly Func<T, T, Task<bool>> check;
        public async Task<bool> CheckAsync(T value, T value2)
        {
            return await check(value, value2);
        }
    }
}
