using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Simple.Infra.TypeConfigurations
{
    public class AppUserClaimTypeConfiguration : IEntityTypeConfiguration<IdentityUserClaim<string>>
    {

        public void Configure(EntityTypeBuilder<IdentityUserClaim<string>> builder)
        {
            builder.ToTable("AppUserClaims");
        }
    }
}