using System.Threading.Tasks;

namespace Agridoce.Domain.Interfaces
{
    public interface ITokenService
    {
        Task<string> NewToken(string email);
        bool IsValid(string token);
    }
}
