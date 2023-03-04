using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleDomain.Entities;

namespace SimpleInfra.TypeConfiguratiions
{
    public class UserTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            /*
             * Configurações da tabela.
             * Nome da tabela.
             */
            builder.ToTable("Users");

            /*
             * Configurações das colunas.
             */
            // * ID - Chave primária.
            builder.HasKey(e => e.Id);
            // * ID - Configurações da coluna.
            builder.Property(e => e.Id).HasColumnName("Id");
            builder.Property(e => e.Id).HasColumnType<int>("integer");
            builder.Property(e => e.Id).IsRequired();
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            // * Nome - Configurações da coluna.
            builder.Property(e => e.Name).HasColumnName("Name");
            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.Name).HasMaxLength(100);
            // * Email - Configurações da coluna.
            builder.Property(e => e.Email).HasColumnName("Email");
            builder.Property(e => e.Email).IsRequired();
            builder.Property(e => e.Email).HasMaxLength(100);
            // * Senha - Configurações da coluna.
            builder.Property(e => e.Password).HasColumnName("Password");
            builder.Property(e => e.Password).IsRequired();
            builder.Property(e => e.Password).HasMaxLength(20);

            /*
             * Adicinar dados iniciais.
             */
            builder.HasData(
                new User
                {
                    Id = 1,
                    Name = "Administrador",
                    Email = "admin@local.com",
                    Password = "123456"
                }
            );
        }
    }
}