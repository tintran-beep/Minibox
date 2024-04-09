using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Minibox.Presentation.Core.Data.Context.Main.Schema.Dbo.Table
{
    public class ProductClassificationDetail : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid ProductClassificationId { get; set; }
        public Guid? ImageId { get; set; }
        public string SKU { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Currency { get; set; } = string.Empty;
        public decimal Price { get; set; } = 0;
        public decimal NetWeight { get; set; } = 0;

        public virtual ProductClassification? ProductClassification { get; set; }
        public virtual Image? Image { get; set; }
    }

    public class ProductClassificationDetailEntityTypeConfiguration : IEntityTypeConfiguration<ProductClassificationDetail>
    {
        public void Configure(EntityTypeBuilder<ProductClassificationDetail> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.SKU).IsUnique();
            builder.Property(x => x.SKU).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(120).IsRequired();
            builder.Property(x => x.Currency).HasMaxLength(5).IsRequired();

            builder.HasOne(x => x.ProductClassification).WithMany(x => x.ProductClassificationDetails).HasForeignKey(x => x.ProductClassificationId);
            builder.HasOne(x => x.Image).WithOne(x => x.ProductClassificationDetail).HasForeignKey<ProductClassification>(x => x.ImageId);

            builder.ToTable(name: nameof(ProductClassificationDetail), schema: Share.Library.Constant.MiniboxConstants.DbSchema.Dbo);
        }
    }
}
