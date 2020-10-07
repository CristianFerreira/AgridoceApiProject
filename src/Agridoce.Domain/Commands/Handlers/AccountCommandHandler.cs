using Agridoce.Domain.Commands.Types.AccountCommand;
using Agridoce.Domain.Configurations;
using Agridoce.Domain.Core;
using Agridoce.Domain.Factories;
using Agridoce.Domain.Interfaces;
using Agridoce.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Agridoce.Domain.Commands.Handlers
{
    public class AccountCommandHandler : CommandHandler,
          IRequestHandler<RegisterCompanyAccountCommand, ICommandResult>,
          IRequestHandler<RegisterEmployeeAccountCommand, ICommandResult>,    
          IRequestHandler<LoginAccountCommand, ICommandResult>
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;
        private readonly IUserClaimFactory _userClaimFactory;

        public AccountCommandHandler(SignInManager<User> signInManager,
                                     UserManager<User> userManager,
                                     IUserClaimFactory userClaimFactory,
                                     ITokenService tokenService,
                                     IUnitOfWork uow,
                                     IMediatorHandler mediator,
                                     INotificationHandler<DomainNotification> notifications) : base(uow, mediator, notifications)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _tokenService = tokenService;
            _userClaimFactory = userClaimFactory;
        }

        public async Task<ICommandResult> Handle(LoginAccountCommand command, CancellationToken cancellationToken)
        {
            var result = await _signInManager.PasswordSignInAsync(command.Email, command.Password, false, true);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(command.Email);

                if (user.LockoutEnabled)
                {
                    AddError("This user is temporarily blocked");
                    return CanceledTask();
                }

                var claims = await _userManager.GetClaimsAsync(user);
                var roles = await _userManager.GetRolesAsync(user);

                var token = _tokenService.NewToken(user.Id, roles, claims);
                user.SetToken(token);
                return await CompletedTaskAsync(user);
            }

            AddError("Incorrect user or password");
            return CanceledTask();
        }

        public async Task<ICommandResult> Handle(RegisterCompanyAccountCommand command, CancellationToken cancellationToken)
        {
            var userClaim = _userClaimFactory.Create(Enums.UserType.Company);
            var userClaims = userClaim.Get();
            using var transaction = _uow.BeginTransaction();
            {
                var user = new User(command.Id, command.Email, userClaims);
                var result = await _userManager.CreateAsync(user, command.Password);

                if (result.Succeeded)
                {
                    var claims = await _userManager.GetClaimsAsync(user);
                    var roles = await _userManager.GetRolesAsync(user);

                    var token = _tokenService.NewToken(user.Id, roles, claims);
                    user.SetToken(token);

                    _uow.Commit(transaction);
                    return await CompletedTaskAsync(user);
                }

                AddError($"There was a problem creating an account: {string.Join(",", result.Errors.Select(x => x.Description))}");
                return await CanceledTaskAsync();
            }
        }

        public Task<ICommandResult> Handle(RegisterEmployeeAccountCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
