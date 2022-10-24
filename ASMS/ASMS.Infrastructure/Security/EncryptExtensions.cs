namespace ASMS.Infrastructure.Security
{
    using BCrypt.Net;

    public static class EncryptExtensions
    {
        public static string ToHash(this string password) => BCrypt.HashPassword(password);

        public static bool VerifyPass(string password, string hashedPassword) => BCrypt.Verify(password, hashedPassword);
    }
}
