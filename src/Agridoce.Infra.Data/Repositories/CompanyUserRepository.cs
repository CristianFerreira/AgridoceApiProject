using Agridoce.Domain.Interfaces.Repositories;
using Agridoce.Domain.Models;
using Agridoce.Infra.Data.Context;

namespace Agridoce.Infra.Data.Repositories
{
    public class CompanyUserRepository : Repository<CompanyUser>, ICompanyUserRepository
    {
        public CompanyUserRepository(AgridoceContext context) : base(context)
        {
        }
    }
}
