using GrandHotelAPI.Models;
using System.Security.Cryptography;

namespace GrandHotelAPI
{
    public static class CryptoHelper
    {
        public static string Authenticate(Employee req)
        {
            string employee = req.Name + req.Password;
            var hmac = new HMACSHA512();
            hmac.Key = System.Text.Encoding.UTF8.GetBytes(Vars.ACCESS_TOKEN);
            byte[] hash =  hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(employee));
            return Convert.ToHexString(hash).ToLower();
        }
        public static string toSha256(string input)
        {
            var sha = SHA256.Create();
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(input);
            byte[] result = sha.ComputeHash(bytes);
            return Convert.ToHexString(result).ToLower();
        }
    }
}
