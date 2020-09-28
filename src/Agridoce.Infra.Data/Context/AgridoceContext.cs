using Agridoce.Domain.Models;
using Agridoce.Infra.Data.Configurations;
using Agridoce.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;


namespace Agridoce.Infra.Data.Context
{
    public class AgridoceContext : DbContext
    {
        public DbSet<Test> Tests { get; set; }

        public AgridoceContext(DbContextOptions<AgridoceContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TestMap());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionStringConfiguration.ConnectionString());
        }
    }
}
