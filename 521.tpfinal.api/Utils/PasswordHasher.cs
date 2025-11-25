using System.Security.Cryptography;
using System.Text;

namespace _521.tpfinal.api.Utils
{
    public class PasswordHasher(IConfiguration configuration)
    {
        private const int SaltSize = 16; 
        private const int KeySize = 32; 
        private const int Iterations = 10000;
        private static readonly HashAlgorithmName _algorithm = HashAlgorithmName.SHA256;

        private readonly string _serverSecret = configuration["JwtSettings:SecretKey"]
                ?? throw new InvalidOperationException("JwtSettings:SecretKey is missing from configuration");

        public string Hash(string password, string userEmail)
        {
            using var rng = RandomNumberGenerator.Create();
            // Génère un salt aléatoire
            byte[] randomSalt = new byte[SaltSize];
            rng.GetBytes(randomSalt);

            // Crée un salt composite : salt aléatoire + clé serveur + email utilisateur
            byte[] compositeSalt = CreateCompositeSalt(randomSalt, userEmail);

            // Hash le mot de passe avec le salt composite
            var pbkdf2 = new Rfc2898DeriveBytes(password, compositeSalt, Iterations, _algorithm);
            byte[] hash = pbkdf2.GetBytes(KeySize);

            // Stocke le salt aléatoire + hash (le salt serveur et email sont implicites)
            byte[] hashWithSalt = new byte[SaltSize + KeySize];
            Array.Copy(randomSalt, 0, hashWithSalt, 0, SaltSize);
            Array.Copy(hash, 0, hashWithSalt, SaltSize, KeySize);

            return Convert.ToBase64String(hashWithSalt);
        }

        public bool Verify(string password, string hash, string userEmail)
        {
            byte[] hashWithSalt = Convert.FromBase64String(hash);

            byte[] randomSalt = new byte[SaltSize];
            Array.Copy(hashWithSalt, 0, randomSalt, 0, SaltSize);

            // Recrée le salt composite avec les mêmes données
            byte[] compositeSalt = CreateCompositeSalt(randomSalt, userEmail);

            // Hash le mot de passe fourni avec le salt composite
            var pbkdf2 = new Rfc2898DeriveBytes(password, compositeSalt, Iterations, _algorithm);
            byte[] computedHash = pbkdf2.GetBytes(KeySize);

            // Compare les hashes
            for (int i = 0; i < KeySize; i++)
            {
                if (hashWithSalt[i + SaltSize] != computedHash[i])
                {
                    return false;
                }
            }

            return true;
        }

        private byte[] CreateCompositeSalt(byte[] randomSalt, string userEmail)
        {
            // Combine le salt aléatoire, la clé serveur et l'email
            byte[] serverSecretBytes = Encoding.UTF8.GetBytes(_serverSecret);
            byte[] emailBytes = Encoding.UTF8.GetBytes(userEmail);

            // Crée un buffer combiné
            byte[] combined = new byte[randomSalt.Length + serverSecretBytes.Length + emailBytes.Length];
            Array.Copy(randomSalt, 0, combined, 0, randomSalt.Length);
            Array.Copy(serverSecretBytes, 0, combined, randomSalt.Length, serverSecretBytes.Length);
            Array.Copy(emailBytes, 0, combined, randomSalt.Length + serverSecretBytes.Length, emailBytes.Length);

            // Hash le tout pour créer un salt uniforme
            return System.Security.Cryptography.SHA256.HashData(combined);
        }
    }
}
