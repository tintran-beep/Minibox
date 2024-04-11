using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Minibox.Presentation.Core.Data.Context.Main.Schema.Dbo.Table
{
    public class Product : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid? BrandId { get; set; }
        public Guid? CategoryId { get; set; }
        public Guid? CoverImageId { get; set; }
        public Guid? CoverVideoId { get; set; }
        public string SKU { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public virtual Brand? Brand { get; set; }
        public virtual Category? Category { get; set; }
        public virtual Image? CoverImage { get; set; }
        public virtual Video? CoverVideo { get; set; }
        public virtual ICollection<ProductProperty>? ProductProperties { get; set; }
        public virtual ICollection<ProductOtherImage>? ProductOtherImages { get; set; }
        public virtual ICollection<ProductClassification>? ProductClassifications { get; set; }
    }

    public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.SKU).IsUnique();
            builder.Property(x => x.SKU).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(120).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(3000).IsRequired();

            builder.HasOne(x => x.CoverImage).WithOne(x => x.Product).HasForeignKey<Product>(x => x.CoverImageId);
            builder.HasOne(x => x.CoverVideo).WithOne(x => x.Product).HasForeignKey<Product>(x => x.CoverVideoId);

            builder.HasOne(x => x.Brand).WithMany(x => x.Products).HasForeignKey(x => x.BrandId);
            builder.HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId);

            builder.ToTable(name: nameof(Product), schema: Share.Library.Constant.MiniboxConstants.DbSchema.Dbo);
        }
    }
}
