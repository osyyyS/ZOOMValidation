using System;
using System.IO;
using System.Linq;

namespace ZOOMValidation.Rules.Password
{
    public class UniquePasswordRule : IValidationRule<string>
    {
        private const string PASSWORD_LIST_PATH = "10-million-password-list-top-1000000.txt";
        public UniquePasswordRule(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public string ErrorMessage { get; }

        public bool Check(string value)
        {
            return !File.ReadLines(PASSWORD_LIST_PATH).Contains(value);
        }
    }
}
