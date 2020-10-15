using Agridoce.Domain.Models;
using System;

namespace Agridoce.Domain.Interfaces.Repositories
{
    public interface ICompanyRepository : IRepository<Company>
    {
        Company GetByUserId(Guid userId);
    }
}
