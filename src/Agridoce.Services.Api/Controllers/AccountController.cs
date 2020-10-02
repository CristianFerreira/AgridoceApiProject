using Agridoce.Application.ViewModels.AccountViewModels;
using Agridoce.Domain.Core;
using Agridoce.Domain.Models;
using Agridoce.Services.Api.Extensions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Agridoce.Services.Api.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : ApiController
    {
        private readonly SignInManager<User> _signInManager;
        private readonly AppJwtSettings _appJwtSettings;
        private readonly UserManager<User> _userManager;

        public AccountController(
            SignInManager<User> signInManager,
            UserManager<User> userManager,
            IOptions<AppJwtSettings> appJwtSettings,
            INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appJwtSettings = appJwtSettings.Value;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterAccountViewModel registerAccountViewModel)
        {
            var user = new User(Guid.NewGuid(), registerAccountViewModel.Email);

            await _userManager.CreateAsync(user, registerAccountViewModel.Password);

            return Response();
        }

        [HttpPost]
        [Route("token")]
        public async Task<IActionResult> Login(AccountLoginViewModel accountLoginViewModel)
        {

            var result = await _signInManager.PasswordSignInAsync(accountLoginViewModel.Email, accountLoginViewModel.Password, false, true);

            if (result.Succeeded)
            {
                var fullJwt = await GetFullJwt(accountLoginViewModel.Email);
                return Response(fullJwt);
            }

            return Response();
        }


        [HttpPost]
        [Route("token/validate")]
        public IActionResult TokenValidate(string token)
        {
            return Response(ValidateCurrentToken(token));
        }

        private async Task<string> GetFullJwt(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(await _userManager.GetClaimsAsync(user));

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appJwtSettings.SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identityClaims,
                Issuer = _appJwtSettings.Issuer,
                Audience = _appJwtSettings.Audience,
                Expires = DateTime.UtcNow.AddHours(_appJwtSettings.ExpirationHours),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }

        private bool ValidateCurrentToken(string token)
        {
            var mySecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_appJwtSettings.SecretKey));

            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = _appJwtSettings.Issuer,
                    ValidAudience = _appJwtSettings.Audience,
                    IssuerSigningKey = mySecurityKey
                }, out SecurityToken validatedToken);
            }
            catch
            {
                return false;
            }
            return true;
        }



    }
}
