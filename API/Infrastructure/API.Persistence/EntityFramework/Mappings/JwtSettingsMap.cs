using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Persistence.EntityFramework.Mappings
{
    using Model.Entities;

    public class JwtSettingsMap : BaseMap, IEntityTypeConfiguration<JwtSettings>
    {
        public void Configure(EntityTypeBuilder<JwtSettings> builder)
        {
            builder.Property(r => r.Id).ValueGeneratedOnAdd();

            builder.Property(r => r.Name).HasColumnType(DbType.VarChar(250)).IsRequired();

            builder.Property(r => r.Audience).HasColumnType(DbType.VarChar(250)).IsRequired();

            builder.Property(r => r.Issuer).HasColumnType(DbType.VarChar(250)).IsRequired();

            builder.Property(r => r.Key).HasColumnType(DbType.VarChar(250)).IsRequired();

            builder.Property(r => r.DurationInMinutes).IsRequired();

            builder.Property(r => r.IsActive).IsRequired().HasDefaultValue(true);

            // Maps to the JwtSettings table
            builder.ToTable("JwtSettings");

            builder.HasData(new List<JwtSettings>
            {
                new() {
                    Id = 1,
                    Name = "Default",
                    Issuer = "domain.com",
                    Audience = "domain.com",
                    DurationInMinutes = 60,
                    Key = "8ae369193154333272c22d9aec9cb09b4369284f4b2df9973efea03105d9c46b",
                    IsActive = true
                }
            });
        }
    }
}
