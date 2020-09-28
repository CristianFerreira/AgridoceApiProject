using Agridoce.Domain.Interfaces;
using Agridoce.Domain.Models;
using Agridoce.Infra.Data.Context;

namespace Agridoce.Infra.Data.Repositories
{
    public class TestRepository : Repository<Test>, ITestRepository
    {
        public TestRepository(AgridoceContext context) : base(context)
        {
        }
    }
}
