using Agridoce.Domain.Commands.AccountCommand;
using Agridoce.Domain.Core;
using Agridoce.Domain.Interfaces;
using Agridoce.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Agridoce.Domain.Handlers
{
    public class AccountCommandHandler : CommandHandler,
          IRequestHandler<RegisterAccountCommand, ICommandResult>,
          IRequestHandler<LoginAccountCommand, ICommandResult>
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;

        public AccountCommandHandler(SignInManager<User> signInManager,
                                     UserManager<User> userManager,
                                     ITokenService tokenService,
                                     IUnitOfWork uow,
                                     IMediatorHandler mediator,
                                     INotificationHandler<DomainNotification> notifications) : base(uow, mediator, notifications)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<ICommandResult> Handle(RegisterAccountCommand command, CancellationToken cancellationToken)
        {
            using (var transaction = _uow.BeginTransaction())
            {
                var user = new User(command.Id, command.Email);
                var result = await _userManager.CreateAsync(user, command.Password);

                if(result.Succeeded)
                {
                    var token = await _tokenService.NewToken(command.Email);
                    user.SetToken(token);
                    _uow.Commit(transaction);

                    return await CompletedTaskAsync(user);
                }

                AddError($"There was a problem creating an account: {string.Join(",", result.Errors.Select(x=>x.Description))}");              
                return await CanceledTaskAsync();
            }
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

                var token = await _tokenService.NewToken(command.Email);                       
                user.SetToken(token);
                return await CompletedTaskAsync(user);
            }

            AddError("Incorrect user or password");
            return CanceledTask();
        }
    }
}
