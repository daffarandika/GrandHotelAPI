using GrandHotelAPI.Models;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;

namespace GrandHotelAPI
{
    public static class CryptoHelper
    {
        public static HMACSHA256 hmac = new HMACSHA256();
        public static string GenerateJWT(Employee req)
        {
            hmac.Key = System.Text.Encoding.UTF8.GetBytes(Vars.ACCESS_TOKEN);
            string algo = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes("HS256"));

            TimeSpan t = DateTime.Now - new DateTime(1970, 1, 1);
            string payload = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(req.Name + req.Password + t.TotalSeconds));

            string signature = Convert.ToHexString(hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(algo + payload)));
            return $"{algo}.{payload}.{signature}";

        }
        public static string toSha256(string input)
        {
            var sha = SHA256.Create();
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(input);
            byte[] result = sha.ComputeHash(bytes);
            return Convert.ToHexString(result).ToLower();
        }
        public static void GenerateAccessToken()
        {
            Vars.ACCESS_TOKEN = Convert.ToBase64String(hmac.Key);
        }
        public static ValidationResponse ValidateToken(string jwt)
        {
            if (jwt.IsNullOrEmpty())
            {
                return new ValidationResponse(false, "A token must be provided");
            }
            string[] arr = jwt.Split('.');
            string algo = arr[0];
            string payload = arr[1];
            string signature = arr[2];
            hmac.Key = System.Text.Encoding.UTF8.GetBytes(Vars.ACCESS_TOKEN);
            bool isValid = signature == Convert.ToHexString(hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(algo + payload)));
            return new ValidationResponse(isValid, "token is invalid");
        }
    }
}
