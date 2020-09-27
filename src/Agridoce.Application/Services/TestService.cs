using Agridoce.Application.Interfaces;
using Agridoce.Application.ViewModels;
using Agridoce.Domain.Commands;
using Agridoce.Domain.Core;
using AutoMapper;
using System.Threading.Tasks;

namespace Agridoce.Application.Services
{
    public class TestService : ITestService
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _bus;

        public TestService(IMapper mapper,
                           IMediatorHandler bus)
        {
            _mapper = mapper;
            _bus = bus;
        }

        public async Task<ICommandResult> Register(TestViewModel testViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewTestCommand>(testViewModel);
            return await _bus.SendCommand(registerCommand);
        }
    }
}
