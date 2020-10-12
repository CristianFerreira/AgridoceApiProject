using Agridoce.Application.Interfaces;
using Agridoce.Application.ViewModels.AccountViewModels;
using Agridoce.Domain.Commands.Requests.AccountCommand;
using Agridoce.Domain.Commands.Responses;
using Agridoce.Domain.Core;
using Agridoce.Domain.Interfaces;
using Agridoce.Domain.Models;
using AutoMapper;
using System.Threading.Tasks;

namespace Agridoce.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _bus;

        public AccountService(ITokenService tokenService,
                              IMapper mapper,
                              IMediatorHandler bus)
        {
            _tokenService = tokenService;
            _mapper = mapper;
            _bus = bus;
        }

        public async Task<UserAccountViewModel> LoginAccount(LoginAccountViewModel accountLoginViewModel)
        {
            Command command = _mapper.Map<LoginAccountCommand>(accountLoginViewModel);
            ICommandResult result = await _bus.SendCommand(command);
            return _mapper.Map<UserAccountViewModel>(result.Data as AccountCommandResult);
        }

        public async Task<UserAccountViewModel> RegisterCompanyAccount(RegisterCompanyUserAccountViewModel registerCompanyAccountViewModel)
        {
            Command command = _mapper.Map<RegisterCompanyAccountCommand>(registerCompanyAccountViewModel);
            ICommandResult result = await _bus.SendCommand(command);
            return _mapper.Map<UserAccountViewModel>(result.Data as AccountCommandResult);
        }

        public async Task<UserAccountViewModel> RegisterEmployeeAccount(RegisterEmployeeAccountViewModel registerEmployeeAccountViewModel)
        {
            Command command = _mapper.Map<RegisterEmployeeAccountCommand>(registerEmployeeAccountViewModel);
            ICommandResult result = await _bus.SendCommand(command);
            return _mapper.Map<UserAccountViewModel>(result.Data as AccountCommandResult);
        }

        public bool ValidateAccountToken(string token)
        {
            return _tokenService.IsValid(token);
        }
    }
}
