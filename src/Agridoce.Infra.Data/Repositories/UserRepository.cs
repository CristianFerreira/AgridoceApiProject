using Agridoce.Domain.Interfaces.Repositories;
using Agridoce.Domain.Models;
using Agridoce.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Agridoce.Infra.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AgridoceContext context) : base(context)  { }

        public async Task<User> GetByEmail(string email)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Email == email);
        }

    }
}
