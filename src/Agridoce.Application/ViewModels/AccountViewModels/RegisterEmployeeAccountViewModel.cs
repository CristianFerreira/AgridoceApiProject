using System;

namespace Agridoce.Application.ViewModels.AccountViewModels
{
    public class RegisterEmployeeAccountViewModel : RegisterUserAccountViewModel
    {
        public Guid CompanyId { get; set; }
    }
}
