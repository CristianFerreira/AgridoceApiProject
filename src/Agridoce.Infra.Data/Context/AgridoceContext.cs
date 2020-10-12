using Agridoce.Domain.Models;
using Agridoce.Infra.Data.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Agridoce.Infra.Data.Context
{
    public class AgridoceContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public DbSet<CompanyUser> CompanyUsers { get; set; }
        public DbSet<Company> Companies { get; set; }

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
