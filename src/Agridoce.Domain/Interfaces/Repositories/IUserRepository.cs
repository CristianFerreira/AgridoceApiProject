using Agridoce.Domain.Models;
using System.Threading.Tasks;

namespace Agridoce.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByEmail(string email);
    }
}
