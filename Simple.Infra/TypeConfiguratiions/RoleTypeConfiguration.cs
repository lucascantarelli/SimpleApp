using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Simple.Domain.Entities;

namespace Simple.Infra.TypeConfiguratiions
{
    public class RoleTypeConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            /*
             * Configurações da tabela.
             * Nome da tabela.
             */
            builder.ToTable("Roles");
            /*
             * Configurações das colunas.
             */
            // * ID - Chave primária.
            builder.HasKey(e => e.Id);
            // * ID - Nome da coluna.
            builder.Property(e => e.Id).HasColumnName("Id");
            builder.Property(e => e.Id).HasColumnType<int>("integer");
            builder.Property(e => e.Id).IsRequired();
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            // * Nome - Nome da coluna.
            builder.Property(e => e.Description).HasColumnName("Description");
            builder.Property(e => e.Description).IsRequired();
            builder.Property(e => e.Description).HasMaxLength(100);

            /*
             * Adicinar dados iniciais.
             */
            builder.HasData(
                new Role
                {
                    Id = 1,
                    Description = "Administrador"
                },
                new Role
                {
                    Id = 2,
                    Description = "AppUser"
                }
            );
        }
    }
}