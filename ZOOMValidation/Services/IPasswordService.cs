using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ZOOMValidation.Services
{
    internal interface IPasswordService
    {
        Task<bool> IsSecure(string password);
    }
}
