using System;

namespace ZOOMValidation.Rules
{
    public class ValidEmailRule : IValidationRule<string>
    {
        private readonly bool removeWhiteSpaces;
        public ValidEmailRule(string errorMessage, bool removeWhiteSpaces = true)
        {
            ErrorMessage = errorMessage;
            this.removeWhiteSpaces = removeWhiteSpaces;
        }

        public string ErrorMessage { get; }

        public bool Check(string value)
        {
            value = removeWhiteSpaces ? value.Replace(" ", "") : value;

            try
            {
                var addr = new System.Net.Mail.MailAddress(value);
                return addr.Address == $"{addr}";
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
