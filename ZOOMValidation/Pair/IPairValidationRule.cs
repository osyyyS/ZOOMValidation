namespace ZOOMValidation.Pair;

public interface IPairValidationRule<T>
{
  string ErrorMessage { get; }
  bool Check(T value, T value2);
}
