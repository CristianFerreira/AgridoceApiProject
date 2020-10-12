using Agridoce.Application.Interfaces;
using Agridoce.Application.ViewModels.AccountViewModels;
using Agridoce.Domain.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static Agridoce.Services.Api.Extensions.CustomAuthorization;

namespace Agridoce.Services.Api.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : ApiController
    {
        private readonly IAccountService _accountService;

        public AccountController(
            IAccountService accountService,
            INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            _accountService = accountService;
        }

        [HttpPost]
        [Route("company")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(SuccessfulResponse<UserAccountViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register(RegisterCompanyUserAccountViewModel registerCompanyAccountViewModel)
        {
            var account = await _accountService.RegisterCompanyAccount(registerCompanyAccountViewModel);
            return Response(account);
        }

        [HttpPost]
        [Route("employee")]
        [CustomAuthorize("EmployeeAccount", "Write")]
        [ProducesResponseType(typeof(SuccessfulResponse<UserAccountViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register(RegisterEmployeeAccountViewModel registerEmployeeAccountViewModel)
        {
            var account = await _accountService.RegisterEmployeeAccount(registerEmployeeAccountViewModel);
            return Response(account);
        }

        [HttpPost]
        [Route("token")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(SuccessfulResponse<UserAccountViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login(LoginAccountViewModel accountLoginViewModel)
        {
            var account = await _accountService.LoginAccount(accountLoginViewModel);
            return Response(account);
        }


        [HttpPost]
        [Route("token/validate")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(SuccessfulResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public IActionResult ValidateAccountToken(string token)
        {
            var isValid = _accountService.ValidateAccountToken(token);
            return Response(isValid);
        }
    }
}
