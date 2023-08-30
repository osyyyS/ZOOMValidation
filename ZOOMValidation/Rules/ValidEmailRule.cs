using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ZOOMValidation.Rules
{
    public class ValidEmailRule<T> : IValidationRule<T>
    {
        private bool removeWhiteSpaces;
        public ValidEmailRule(string errorMessage, bool removeWhiteSpaces = true)
        {
            ErrorMessage = errorMessage;
            this.removeWhiteSpaces = removeWhiteSpaces;
        }

        public string ErrorMessage { get; }

        public bool Check(T value)
        {
            if (value is string password)
            {
                password = removeWhiteSpaces ? password.Replace(" ", "") : password;
                
                try
                {
                    var addr = new System.Net.Mail.MailAddress(password);
                    return addr.Address == $"{addr}";
                }
                catch(FormatException)
                { 
                    return false;
                }
            }
            throw new ArgumentException($"Expected string, got {typeof(T).FullName}.");
        }
    }
}
