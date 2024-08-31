using System.Security.Cryptography;
using System.Text;

namespace eTable.Application.Configs
{
    public class PasswordEncrypter
    {
        private readonly string _secretKey;
        public PasswordEncrypter(string secretKey) => _secretKey = secretKey;
        public string Encrypt(string password)
        {
            var pass = $"{password}{_secretKey}";

            var bytes = Encoding.UTF8.GetBytes(password);

            var hashBytes = SHA512.HashData(bytes);

            return StringBytes(hashBytes);
        }

        public string StringBytes(byte[] bytes)
        {
            var sb = new StringBuilder();

            foreach (var b in bytes)
            {
                var hex = b.ToString("x2");
                sb.Append(hex);
            }
            return sb.ToString();
        }
    }
}
