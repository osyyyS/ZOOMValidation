using System;
using System.Security.Cryptography;
using System.Text;

namespace ZOOMValidation.Extensions;

internal static class StringExtensions
{
  internal static string ToSha1Hash(this string input)
  {
    byte[] inputBytes = Encoding.UTF8.GetBytes(input);
    byte[] hashBytes = SHA1.HashData(inputBytes);
    return BitConverter.ToString(hashBytes).Replace("-", "").ToUpper();
  }
}
