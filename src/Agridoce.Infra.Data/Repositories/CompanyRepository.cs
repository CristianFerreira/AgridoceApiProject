using Agridoce.Domain.Interfaces.Repositories;
using Agridoce.Domain.Models;
using Agridoce.Infra.Data.Context;
using System.Threading.Tasks;
using System.Linq;
using System;
using Agridoce.Domain.Enums;

namespace Agridoce.Infra.Data.Repositories
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(AgridoceContext context) : base(context)
        {
        }

        public Company GetByUserId(Guid userId)
        {
            var result = (from u in Db.Users
                          join cu in Db.CompanyUsers on u.Id equals cu.UserId
                          join c in Db.Companies on cu.CompanyId equals c.Id
                          where cu.UserId == userId & u.UserType == UserType.Company
                          select c).ToList().FirstOrDefault();
            return result;
        }

    }
}
