using System;
using System.Security.Cryptography;
using System.Text;

namespace ECommerce.Helper_Classes
{
  public static class PasswordHash
  {
    public static string GenerateHash(string password)
    {
      var saltBytes = new byte[64];

      var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, saltBytes, 10000);
      var hashPassword = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));

      return hashPassword;

    }
  }
}