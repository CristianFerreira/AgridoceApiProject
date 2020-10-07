using Agridoce.Domain.Enums;

namespace Agridoce.Domain.Factories
{
    public interface IUserClaimFactory
    {
        public IClaim Create(UserType userType);
    }
}
