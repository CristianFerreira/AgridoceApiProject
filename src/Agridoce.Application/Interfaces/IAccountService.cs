using Agridoce.Application.ViewModels.AccountViewModels;
using System.Threading.Tasks;

namespace Agridoce.Application.Interfaces
{
    public interface IAccountService
    {
        Task<AccountViewModel> LoginAccount(LoginAccountViewModel accountLoginViewModel);
        Task<AccountViewModel> RegisterCompanyAccount(RegisterCompanyAccountViewModel registerCompanyAccountViewModel);
        Task<AccountViewModel> RegisterEmployeeAccount(RegisterEmployeeAccountViewModel registerEmployeeAccountViewModel);
        bool ValidateAccountToken(string token);
    }
}
