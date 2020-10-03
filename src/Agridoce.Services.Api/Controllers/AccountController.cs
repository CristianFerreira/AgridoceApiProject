using Agridoce.Application.Interfaces;
using Agridoce.Application.ViewModels.AccountViewModels;
using Agridoce.Domain.Core;
using Agridoce.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Agridoce.Services.Api.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : ApiController
    {
        private readonly SignInManager<User> _signInManager;
        private readonly IAccountService _accountService;
        private readonly UserManager<User> _userManager;

        public AccountController(
            SignInManager<User> signInManager,
            UserManager<User> userManager,
            IAccountService accountService,
            INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _accountService = accountService;
        }

        [HttpPost]
        [Route("register")]
        [ProducesResponseType(typeof(SuccessfulResponse<AccountViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register(RegisterAccountViewModel registerAccountViewModel)
        {
            var account = await _accountService.RegisterAccount(registerAccountViewModel);
            return Response(account);
        }

        [HttpPost]
        [Route("token")]
        [ProducesResponseType(typeof(SuccessfulResponse<AccountViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login(LoginAccountViewModel accountLoginViewModel)
        {
            var account = await _accountService.LoginAccount(accountLoginViewModel);
            return Response(account);
        }


        [HttpPost]
        [Route("token/validate")]
        [ProducesResponseType(typeof(SuccessfulResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public IActionResult ValidateAccountToken(string token)
        {
            var isValid = _accountService.ValidateAccountToken(token);
            return Response(isValid);
        }




    }
}
