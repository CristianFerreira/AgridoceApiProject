using Agridoce.Application.ViewModels.AccountViewModels;
using System.Threading.Tasks;

namespace Agridoce.Application.Interfaces
{
    public interface IAccountService
    {
        Task<AccountViewModel> LoginAccount(LoginAccountViewModel accountLoginViewModel);
        Task<AccountViewModel> RegisterAccount(RegisterAccountViewModel registerAccountViewModel);
        bool ValidateAccountToken(string token);
    }
}
