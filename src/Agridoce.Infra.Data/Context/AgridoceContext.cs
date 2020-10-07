using Agridoce.Domain.Models;
using Agridoce.Infra.Data.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Agridoce.Infra.Data.Context
{
    public class AgridoceContext : IdentityDbContext<User, Role, Guid>
    {
        public DbSet<CompanyUser> CompanyUsers { get; set; }
        public DbSet<EmployeeUser> EmployeeUsers { get; set; }

        public AgridoceContext(DbContextOptions<AgridoceContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddIdentityTableConfiguration();
            modelBuilder.AddMapConfiguration();

            base.OnModelCreating(modelBuilder);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

    }
}
