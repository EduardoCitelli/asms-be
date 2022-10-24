namespace ASMS.CrossCutting.Settings
{
    public class AuthSettings
    {
        public string SecretKey { get; set; } = string.Empty;

        public int TokenDays { get; set; }
    }
}
