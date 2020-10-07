using System;

namespace Agridoce.Application.ViewModels.AccountViewModels
{
    public class RegisterEmployeeAccountViewModel : RegisterAccountViewModel
    {
        public string Name { get; set; }
        public Guid CompanyUserId { get; set; }
    }
}
