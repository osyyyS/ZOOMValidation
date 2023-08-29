using System;
using System.Threading.Tasks;

namespace ZOOMValidation
{
    public class AsyncValidationRule<T> : IAsyncValidationRule<T>
    {
        public AsyncValidationRule(string errorMessage, Func<T, Task<bool>> check)
        {
            ErrorMessage = errorMessage;
            this.check = check;
        }
        public string ErrorMessage { get; set; }

        private readonly Func<T, Task<bool>> check;
        public async Task<bool> CheckAsync(T value)
        {
            return await check(value);
        }
    }
}
