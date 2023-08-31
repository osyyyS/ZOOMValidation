using System;
using System.IO;
using System.Linq;

namespace ZOOMValidation.Rules.Password
{
    public class UniquePasswordRule<T> : IValidationRule<T>
    {
        private const string PASSWORD_LIST_PATH = "10-million-password-list-top-1000000.txt";
        public UniquePasswordRule(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public string ErrorMessage { get; }

        public bool Check(T value)
        {
            if (value is string password)
            {
                return !File.ReadLines(PASSWORD_LIST_PATH).Contains(password);
            }
            throw new ArgumentException($"Expected string, got {typeof(T).FullName}.");
        }
    }
}
