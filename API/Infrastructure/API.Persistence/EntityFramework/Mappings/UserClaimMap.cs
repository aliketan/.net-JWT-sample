using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Persistence.EntityFramework.Mappings
{
    using Model.Entities;

    public class UserClaimMap : IEntityTypeConfiguration<UserClaim>
    {
        public void Configure(EntityTypeBuilder<UserClaim> builder)
        {
            // Primary key
            builder.HasKey(uc => uc.Id);

            // Maps to the AspNetUserClaims table
            builder.ToTable("UserClaim");
        }
    }
}
