using System.Threading.Tasks;
using ZOOMValidation.Services;

namespace ZOOMValidation.Rules.Password;

public class PwnedPasswordRule(string pwnedPasswordMessage) : IAsyncValidationRule<string>
{
  private readonly HaveIBeenPwnedService passwordService = new();

  public string ErrorMessage { get; } = pwnedPasswordMessage;

  public async Task<bool> CheckAsync(string value)
  {
    return await passwordService.IsSecure(value);
  }
}
