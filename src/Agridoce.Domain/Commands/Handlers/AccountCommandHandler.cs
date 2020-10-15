using Agridoce.Domain.Commands.Requests.AccountCommand;
using Agridoce.Domain.Commands.Responses;
using Agridoce.Domain.Core;
using Agridoce.Domain.Enums;
using Agridoce.Domain.Factories;
using Agridoce.Domain.Interfaces;
using Agridoce.Domain.Interfaces.Repositories;
using Agridoce.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Agridoce.Domain.Commands.Handlers
{
    public class AccountCommandHandler : CommandHandler,
          IRequestHandler<RegisterCompanyUserAccountCommand, ICommandResult>,
          IRequestHandler<RegisterEmployeeUserAccountCommand, ICommandResult>,    
          IRequestHandler<LoginAccountCommand, ICommandResult>
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;
        private readonly IUserClaimFactory _userClaimFactory;
        private readonly IUserRepository _userRepository;
        private readonly ICompanyUserRepository _companyUserRepository;
        private readonly ICompanyRepository _companyRepository;

        public AccountCommandHandler(SignInManager<User> signInManager,
                                     UserManager<User> userManager,
                                     IUserRepository userRepository,
                                     ICompanyRepository companyRepository,
                                     ICompanyUserRepository companyUserRepository,
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
            _userRepository = userRepository;
            _companyUserRepository = companyUserRepository;
            _companyRepository = companyRepository;
        }

        public async Task<ICommandResult> Handle(LoginAccountCommand command, CancellationToken cancellationToken)
        {
            var result = await _signInManager.PasswordSignInAsync(command.Email, command.Password, false, true);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(command.Email);
                if (user.LockoutEnabled)
                {
                    AddError("Usuário está temporariamente bloqueado.");
                    return CanceledTask();
                }
                var claims = await _userManager.GetClaimsAsync(user);
                var token = _tokenService.NewToken(user.Id, claims);


                var data = new AccountCommandResult(user.Id, user.Email, token, claims);
                return CreateResult(data);
            }

            AddError("E-mail ou Senha inválidos.");
            return CanceledTask();
        }

        public async Task<ICommandResult> Handle(RegisterCompanyUserAccountCommand command, CancellationToken cancellationToken)
        {
            using var transaction = _uow.BeginTransaction();
            {
                if(await HaveEmailRegistered(command.Email))
                {
                    AddError("E-mail já cadastrado.");
                    return await CanceledTaskAsync();
                }

                var claims = _userClaimFactory.Create(UserType.Company).Get();
                var user = new User(Guid.NewGuid(), command.Email);
                var identityResultOfUser = await _userManager.CreateAsync(user, command.Password);

                if (identityResultOfUser.Succeeded)
                {
                    var identityResultOfClaims = await _userManager.AddClaimsAsync(user, claims);

                    if (identityResultOfClaims.Succeeded)
                    {
                        var company = new Company(Guid.NewGuid(), command.Name);
                        _companyRepository.Add(company);

                        var companyUser = new CompanyUser(company, user);
                        _companyUserRepository.Add(companyUser);

                        var token = _tokenService.NewToken(user.Id, claims);
                        _uow.Commit(transaction);

                        var data = new AccountCommandResult(user.Id, user.Email, token, claims);
                        return CreateResult(data);
                    }

                    AddError(identityResultOfClaims.Errors);
                    return await CanceledTaskAsync();
                }

                AddError(identityResultOfUser.Errors);
                return await CanceledTaskAsync();
            }
        }

        public async Task<ICommandResult> Handle(RegisterEmployeeUserAccountCommand command, CancellationToken cancellationToken)
        {
            using var transaction = _uow.BeginTransaction();
            {
                if (await HaveEmailRegistered(command.Email))
                {
                    AddError("E-mail já cadastrado");
                    return await CanceledTaskAsync();
                }

                var claims = _userClaimFactory.Create(UserType.Employee).Get();
                var user = new User(Guid.NewGuid(), command.Email);
                var identityResultOfUser = await _userManager.CreateAsync(user, command.Password);

                if (identityResultOfUser.Succeeded)
                {
                    var identityResultOfClaims = await _userManager.AddClaimsAsync(user, claims);

                    if (identityResultOfClaims.Succeeded)
                    {
                        var company = _companyRepository.GetById(command.CompanyId);
                        if(company != null)
                        {
                            var companyUser = new CompanyUser(company, user);
                            _companyUserRepository.Add(companyUser);

                            var token = _tokenService.NewToken(user.Id, claims);
                            _uow.Commit(transaction);

                            var data = new AccountCommandResult(user.Id, user.Email, token, claims);
                            return CreateResult(data);
                        }

                        AddError($"Nenhuma companhia encontrada com o identificador: {command.CompanyId}");
                        return await CanceledTaskAsync();
                    }

                    AddError(identityResultOfClaims.Errors);
                    return await CanceledTaskAsync();
                }

                AddError(identityResultOfUser.Errors);
                return await CanceledTaskAsync();
            }
        }

        private async Task<bool> HaveEmailRegistered(string email)
        {
            return await _userRepository.GetByEmail(email) != null;
        }
    }
}
