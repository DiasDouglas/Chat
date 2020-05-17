using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Chat.Services
{
    public static class Security
    {
        public static PasswordVerificationResult CheckPassword(string hashed, string provided)
        {
            provided = HashPassword(provided);
            return (provided == hashed ? PasswordVerificationResult.Success : PasswordVerificationResult.Failed);
        }

        public static string HashPassword(string password)
        {
            SHA1 sha1 = SHA1.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(password);
            byte[] hash = sha1.ComputeHash(inputBytes);
            return Convert.ToBase64String(hash);
        }
    }
}
