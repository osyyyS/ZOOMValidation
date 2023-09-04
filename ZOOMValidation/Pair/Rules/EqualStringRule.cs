namespace ZOOMValidation.Pair.Rules
{
    public class EqualStringRule : IPairValidationRule<string>
    {
        public EqualStringRule(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
        public string ErrorMessage { get; }

        public bool Check(string value, string value2)
        {
            return value == value2;
        }
    }
}
