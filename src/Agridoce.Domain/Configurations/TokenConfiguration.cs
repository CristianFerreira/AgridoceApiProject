namespace Agridoce.Domain.Configurations
{
    public class TokenConfiguration
    {
        public string SecretKey { get; set; }
        public int ExpirationHours { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
