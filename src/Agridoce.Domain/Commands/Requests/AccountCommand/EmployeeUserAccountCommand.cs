using System;

namespace Agridoce.Domain.Commands.Requests.AccountCommand
{
    public class EmployeeUserAccountCommand : UserAccountCommand
    {
        public Guid CompanyId { get; protected set; }
    }
}
