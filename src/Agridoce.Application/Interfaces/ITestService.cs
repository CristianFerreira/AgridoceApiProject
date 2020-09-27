using Agridoce.Application.ViewModels;
using Agridoce.Domain.Core;
using System.Threading.Tasks;

namespace Agridoce.Application.Interfaces
{
    public interface ITestService
    {
        Task<ICommandResult> Register(TestViewModel testViewModel);
    }
}
