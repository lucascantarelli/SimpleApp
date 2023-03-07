using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Simple.Infra.TypeConfigurations
{
    public class AppUserTokenTypeConfiguration : IEntityTypeConfiguration<IdentityUserToken<string>>
    {

        public void Configure(EntityTypeBuilder<IdentityUserToken<string>> builder)
        {
            builder.ToTable("AppUserTokens");
        }
    }
}