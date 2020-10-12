using Agridoce.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Agridoce.Infra.Data.Configurations
{
    public static class MapConfig
    {
        public static void AddMapConfiguration(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new CompanyMap());
            modelBuilder.ApplyConfiguration(new CompanyUserMap());
        }
    }
}
