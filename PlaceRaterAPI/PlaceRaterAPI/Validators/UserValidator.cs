using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PlaceRaterAPI.Validators
{
    public static class UserValidator
    {
        public static String sha256_hash(String value)
        {
            using (SHA256 hash = SHA256Managed.Create())
            {
                return String.Concat(hash
                  .ComputeHash(Encoding.UTF8.GetBytes(value))
                  .Select(item => item.ToString("x2")));
            }
        }

        public static bool isValidLogin(User user)
        {
            if (user.Login == null || user.HashPass == null ||
                user.Login.Length == 0 || user.HashPass.Length == 0)
            {
                return false;
            }

            return true;
        }

        public static bool isValidCadastro(User user)
        {
            if (user.Login == null || user.HashPass == null || user.Email == null || user.Name == null ||
                user.Login.Length == 0 || user.HashPass.Length == 0 || user.Email.Length == 0 || user.Name.Length == 0)
            {
                return false;
            }

            return true;
        }
    }
}
