using Agridoce.Domain.Core;
using MediatR;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Agridoce.Application.Interfaces;
using Agridoce.Application.ViewModels;

namespace Agridoce.Services.Api.Controllers
{
    [Route("api/test")]
    public class TestController : ApiController
    {
        private readonly ITestService _testService;

        public TestController(ITestService testService, 
                            INotificationHandler<DomainNotification> notifications)
                              : base(notifications)
        {
            _testService = testService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(TestViewModel testViewModel)
        {
            return Response(await _testService.Register(testViewModel));
        }
    }
}
