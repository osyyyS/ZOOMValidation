using System.Threading.Tasks;

namespace ZOOMValidation.Services;

internal interface IPasswordService
{
  Task<bool> IsSecure(string password);
}
