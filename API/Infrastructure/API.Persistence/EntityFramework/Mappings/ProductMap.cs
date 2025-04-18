using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Persistence.EntityFramework.Mappings
{
    using Model.Entities;

    public class ProductMap : BaseMap, IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(r => r.Id).ValueGeneratedOnAdd();

            builder.Property(r => r.Name).HasColumnType(DbType.VarChar(250)).IsRequired();

            builder.Property(r => r.Description).HasColumnType(DbType.NVarChar(1000));

            builder.Property(r => r.Price).HasColumnType(DbType.Decimal(2)).IsRequired();

            builder.Property(r => r.StockQuantity).HasColumnType(DbType.Int).IsRequired();

            builder.Property(r => r.IsActive).IsRequired().HasDefaultValue(true);

            builder.Property(r => r.CreatedDate).HasDefaultValueSql("GETDATE()").IsRequired();

            builder.Property(r => r.ModifiedDate).HasDefaultValueSql("GETDATE()").IsRequired();

            // Maps to the Product table
            builder.ToTable("Product");
        }
    }
}
