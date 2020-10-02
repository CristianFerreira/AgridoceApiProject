namespace Agridoce.Services.Api.Extensions
{
    public class AppJwtSettings
    {
        public string SecretKey { get; set; }
        public int ExpirationHours { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
