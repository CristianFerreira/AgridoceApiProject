using Microsoft.AspNetCore.Mvc;

namespace Agridoce.Services.Api.Extensions
{
    public interface IValidateCustomAuthorizer
    {
        public bool IsAuthenticated();
        public bool IsValidPermission();
    }
}
