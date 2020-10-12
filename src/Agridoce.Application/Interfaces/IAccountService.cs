using Agridoce.Application.ViewModels.AccountViewModels;
using System.Threading.Tasks;

namespace Agridoce.Application.Interfaces
{
    public interface IAccountService
    {
        Task<UserAccountViewModel> LoginAccount(LoginAccountViewModel accountLoginViewModel);
        Task<UserAccountViewModel> RegisterCompanyAccount(RegisterCompanyUserAccountViewModel registerCompanyAccountViewModel);
        Task<UserAccountViewModel> RegisterEmployeeAccount(RegisterEmployeeAccountViewModel registerEmployeeAccountViewModel);
        bool ValidateAccountToken(string token);
    }
}
