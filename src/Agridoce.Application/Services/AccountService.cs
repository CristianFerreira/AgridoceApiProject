using Agridoce.Application.Interfaces;
using Agridoce.Application.ViewModels.AccountViewModels;
using Agridoce.Domain.Commands.Types.AccountCommand;
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

        public async Task<AccountViewModel> LoginAccount(LoginAccountViewModel accountLoginViewModel)
        {
            Command command = _mapper.Map<LoginAccountCommand>(accountLoginViewModel);
            ICommandResult result = await _bus.SendCommand(command);
            return _mapper.Map<AccountViewModel>(result.Data as User);
        }

        public async Task<AccountViewModel> RegisterAccount(RegisterAccountViewModel registerAccountViewModel)
        {
            Command command = _mapper.Map<RegisterAccountCommand>(registerAccountViewModel);
            ICommandResult result = await _bus.SendCommand(command);
            return _mapper.Map<AccountViewModel>(result.Data as User);
        }

        public bool ValidateAccountToken(string token)
        {
            return _tokenService.IsValid(token);
        }
    }
}
