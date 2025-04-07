using System.Globalization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Persistence.EntityFramework.Mappings
{
    using Model.Entities;

    public class RoleMap : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.Property(r => r.Id).ValueGeneratedNever();
            // Index for "normalized" role name to allow efficient lookups
            builder.HasIndex(r => r.NormalizedName).HasDatabaseName("RoleNameIndex").IsUnique();

            // A concurrency token for use with the optimistic concurrency checking
            builder.Property(r => r.ConcurrencyStamp).IsConcurrencyToken();

            // Limit the size of columns to use efficient database types
            builder.Property(u => u.Name).HasMaxLength(256);
            builder.Property(u => u.NormalizedName).HasMaxLength(256);

            // The relationships between Role and other entity types
            // Note that these relationships are configured with no navigation properties

            // Each Role can have many entries in the UserRole join table
            builder.HasMany<UserRole>().WithOne().HasForeignKey(ur => ur.RoleId).IsRequired();

            // Each Role can have many associated RoleClaims
            builder.HasMany<RoleClaim>().WithOne().HasForeignKey(rc => rc.RoleId).IsRequired();

            // Maps to the AspNetRoles table
            builder.ToTable("Role");

            CultureInfo info = new CultureInfo("en-US");
            builder.HasData(Enum.GetValues(typeof(Enums.User.Role))
                .Cast<Enums.User.Role>()
                .Select(role => new Role
                {
                    Id = (byte)role,
                    Name = role.ToString(),
                    NormalizedName = role.ToString().ToUpper(info)
                }));
        }
    }
}
