using Agridoce.Domain.Interfaces.Repositories;
using Agridoce.Domain.Models;
using Agridoce.Infra.Data.Context;

namespace Agridoce.Infra.Data.Repositories
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(AgridoceContext context) : base(context)
        {
        }
    }
}
