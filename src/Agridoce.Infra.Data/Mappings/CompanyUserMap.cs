using Agridoce.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agridoce.Infra.Data.Mappings
{
    public class CompanyUserMap : IEntityTypeConfiguration<CompanyUser>
    {
        public void Configure(EntityTypeBuilder<CompanyUser> builder)
        {
            builder.HasKey(c => new { c.UserId, c.CompanyId });

            builder.HasOne(c => c.User)
                        .WithMany(c => c.CompanyUsers);

            builder.HasOne(c => c.Company)
                        .WithMany(c => c.CompanyUsers);

            builder.ToTable("CompanyUsers");
        }
    }
}
