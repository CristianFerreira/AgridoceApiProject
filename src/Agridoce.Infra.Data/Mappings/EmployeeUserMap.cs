using Agridoce.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agridoce.Infra.Data.Mappings
{
    public class EmployeeUserMap : IEntityTypeConfiguration<EmployeeUser>
    {
        public void Configure(EntityTypeBuilder<EmployeeUser> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .HasColumnType("varchar(256)")
                .HasMaxLength(256)
                .IsRequired();

            builder.HasOne(c => c.User)
                        .WithOne(c => c.EmployeeUser)
                                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(c => c.CompanyUser)
                        .WithMany(c => c.EmployeeUsers)
                            .OnDelete(DeleteBehavior.SetNull);

            builder.ToTable("EmployeeUsers");
        }
    }
}
