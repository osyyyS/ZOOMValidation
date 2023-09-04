using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ZOOMValidation.Services;

namespace ZOOMValidation.Rules.Password
{
    public class PwnedPasswordRule : IAsyncValidationRule<string>
    {
        private readonly IPasswordService passwordService;

        public PwnedPasswordRule(string pwnedPasswordMessage)
        {
            passwordService = new HaveIBeenPwnedService();
            ErrorMessage = pwnedPasswordMessage;
        }

        public string ErrorMessage { get; }

        public async Task<bool> CheckAsync(string value)
        {
            return await passwordService.IsSecure(value);
        }
    }
}
