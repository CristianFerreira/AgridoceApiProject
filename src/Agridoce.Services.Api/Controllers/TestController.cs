using Agridoce.Domain.Core;
using MediatR;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Agridoce.Application.Interfaces;
using Agridoce.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using static Agridoce.Services.Api.Extensions.CustomAuthorization;

namespace Agridoce.Services.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class TestController : ApiController
    {
        private readonly ITestService _testService;

        public TestController(ITestService testService, 
                            INotificationHandler<DomainNotification> notifications)
                              : base(notifications)
        {
            _testService = testService;
        }

        [ClaimsAuthorize("test", "register")]
        [HttpPost("register")]
        public async Task<IActionResult> Register(TestViewModel testViewModel)
        {
            return Response(await _testService.Register(testViewModel));
        } 
    }
}
