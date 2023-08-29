namespace ZOOMValidation
{
    public interface IValidationRule<T>
    {
        string ErrorMessage { get; }
        bool Check(T value);
    }
}
