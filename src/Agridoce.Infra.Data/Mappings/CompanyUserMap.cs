using Agridoce.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agridoce.Infra.Data.Mappings
{
    public class CompanyUserMap : IEntityTypeConfiguration<CompanyUser>
    {
        public void Configure(EntityTypeBuilder<CompanyUser> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .HasColumnType("varchar(256)")
                .HasMaxLength(256)
                .IsRequired();

            builder.HasOne(c => c.User)
                        .WithOne(c => c.CompanyUser)
                             .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(c => c.EmployeeUsers)
                        .WithOne(c => c.CompanyUser)
                             .OnDelete(DeleteBehavior.SetNull);

            builder.ToTable("CompanyUsers");
        }
    }
}
