namespace ZOOMValidation
{
    public interface IValidationRule<T>
    {
        string ErrorMessage { get; set; }
        bool Check(T value);
    }
}
