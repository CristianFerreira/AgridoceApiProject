﻿using Agridoce.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agridoce.Infra.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(256);

            builder.Property(u => u.UserName)
                .HasMaxLength(256);

            builder.Property(u => u.UserType)
                .IsRequired();

            builder.HasOne(c => c.EmployeeUser)
                       .WithOne(c => c.User)
                               .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(c => c.CompanyUser)
                       .WithOne(c => c.User)
                               .OnDelete(DeleteBehavior.SetNull);

            builder.ToTable("Users");
        }
    }
}
