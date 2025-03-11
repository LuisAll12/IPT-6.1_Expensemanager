using System;
using System.Security.Cryptography;
using System.Text;

namespace Expensesmanager.Core
{
    // Hash and DeHash the Password
  public class PasswordHasher
  {
    // Variables

    // Functions
    // Hash a new Password
    public static string HashPassword(string password)
    {
      using (var rng = new RNGCryptoServiceProvider())
      {
        byte[] salt = new byte[16];  
        rng.GetBytes(salt);  

        using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 200, HashAlgorithmName.SHA256))
        {
          byte[] hashedPassword = pbkdf2.GetBytes(32);  

          byte[] saltedHashedPassword = new byte[salt.Length + hashedPassword.Length];
          Buffer.BlockCopy(salt, 0, saltedHashedPassword, 0, salt.Length);
          Buffer.BlockCopy(hashedPassword, 0, saltedHashedPassword, salt.Length, hashedPassword.Length);

          return Convert.ToBase64String(saltedHashedPassword);
        }
      }
    }

    // DeHash a Password
    public static bool VerifyPassword(string enteredPassword, string storedHash)
    {
      byte[] saltedHashedPassword = Convert.FromBase64String(storedHash);

      byte[] salt = new byte[16];
      byte[] hash = new byte[saltedHashedPassword.Length - salt.Length];
      Buffer.BlockCopy(saltedHashedPassword, 0, salt, 0, salt.Length);
      Buffer.BlockCopy(saltedHashedPassword, salt.Length, hash, 0, hash.Length);

      using (var pbkdf2 = new Rfc2898DeriveBytes(enteredPassword, salt, 200, HashAlgorithmName.SHA256))
      {
        byte[] enteredHash = pbkdf2.GetBytes(32);

        for (int i = 0; i < hash.Length; i++)
        {
          if (enteredHash[i] != hash[i])
          {
            return false;
          }
        }
      }

      return true;
    }
  }
}
