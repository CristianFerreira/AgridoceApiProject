using Agridoce.Domain.Models;
using Agridoce.Infra.Data.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Agridoce.Infra.Data.Context
{
    public class AgridoceContext : IdentityDbContext<User, Role, Guid>
    {
        public DbSet<Test> Tests { get; set; }

        public AgridoceContext(DbContextOptions<AgridoceContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddIdentityTableConfiguration();
            modelBuilder.AddMapConfiguration();

            base.OnModelCreating(modelBuilder);
        }

    }
}
