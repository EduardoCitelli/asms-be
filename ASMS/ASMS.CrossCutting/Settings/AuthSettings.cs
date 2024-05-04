namespace ASMS.CrossCutting.Settings
{
    public class AuthSettings
    {
        public string SecretKey { get; set; } = string.Empty;

        public int TokenDays { get; set; }

        public string AdminPassword { get; set; } = string.Empty;

        public string AdminEmail {  get; set; } = string.Empty;
    }
}
