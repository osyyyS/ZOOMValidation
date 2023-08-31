namespace ZOOMValidation.Rules
{
    public class NotNullOrEmptyRule<T> : IValidationRule<T>
    {
        public NotNullOrEmptyRule(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
        public string ErrorMessage { get; }

        public bool Check(T value)
        {
            return !string.IsNullOrEmpty($"{value}");
        }
    }
}
