using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Simple.Infra.Entities;

namespace Simple.Infra.TypeConfigurations
{
    public class AppUserTypeConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.ToTable("AppUser");

            // Chave primária.
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired();

            // FirstName.
            builder.Property(x => x.FirstName)
                .HasColumnName("FirstName")
                .HasMaxLength(100)
                .IsRequired();

            // LastName.
            builder.Property(x => x.LastName)
                .HasColumnName("LastName")
                .HasMaxLength(100)
                .IsRequired();

            // UserName.
            builder.Property(x => x.UserName)
                .HasColumnName("UserName")
                .HasMaxLength(100)
                .IsRequired();

            // NormalizedUserName.
            builder.Property(x => x.NormalizedUserName)
                .HasColumnName("NormalizedUserName")
                .HasMaxLength(100)
                .IsRequired();

            // Email.
            builder.Property(x => x.Email)
                .HasColumnName("Email")
                .HasMaxLength(100)
                .IsRequired();

            // NormalizedEmail.
            builder.Property(x => x.NormalizedEmail)
                .HasColumnName("NormalizedEmail")
                .HasMaxLength(100)
                .IsRequired();

            // EmailConfirmed.
            builder.Property(x => x.EmailConfirmed)
                .HasColumnName("EmailConfirmed")
                .IsRequired();

            // PasswordHash.
            builder.Property(x => x.PasswordHash)
                .HasColumnName("PasswordHash")
                .HasMaxLength(100)
                .IsRequired();

            // SecurityStamp.
            builder.Property(x => x.SecurityStamp)
                .HasColumnName("SecurityStamp")
                .HasMaxLength(100)
                .IsRequired();

            // ConcurrencyStamp.
            builder.Property(x => x.ConcurrencyStamp)
                .HasColumnName("ConcurrencyStamp")
                .HasMaxLength(100)
                .IsRequired();

            // PhoneNumber.
            builder.Property(x => x.PhoneNumber)
                .HasColumnName("PhoneNumber")
                .HasMaxLength(100)
                .IsRequired();

            // PhoneNumberConfirmed.
            builder.Property(x => x.PhoneNumberConfirmed)
                .HasColumnName("PhoneNumberConfirmed")
                .IsRequired();

            // TwoFactorEnabled.
            builder.Property(x => x.TwoFactorEnabled)
                .HasColumnName("TwoFactorEnabled")
                .IsRequired();

            // LockoutEnd.
            builder.Property(x => x.LockoutEnd)
                .HasColumnName("LockoutEnd")
                .IsRequired();

            // LockoutEnabled.
            builder.Property(x => x.LockoutEnabled)
                .HasColumnName("LockoutEnabled")
                .IsRequired();

            // AccessFailedCount.
            builder.Property(x => x.AccessFailedCount)
                .HasColumnName("AccessFailedCount")
                .IsRequired();

        }
    }
}