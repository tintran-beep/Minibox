using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Minibox.Presentation.Core.Data.Context.Main.Schema.Dbo.Table
{
    public class ProductClassification : BaseEntity
    {
        public ProductClassification()
        {
            Id = Share.Library.Common.CommonHelper.NewSequenceGuid();
        }
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid? ImageId { get; set; }
        public string Name { get; set; } = string.Empty;

        public virtual required Product Product { get; set; }
        public virtual Image? Image { get; set; }
        public virtual ICollection<ProductClassificationDetail>? ProductClassificationDetails { get; set; }
    }

    public class ProductClassificationEntityTypeConfiguration : IEntityTypeConfiguration<ProductClassification>
    {
        public void Configure(EntityTypeBuilder<ProductClassification> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();

            builder.HasOne(x => x.Product).WithMany(x => x.ProductClassifications).HasForeignKey(x => x.ProductId);
            builder.HasOne(x => x.Image).WithOne(x => x.ProductClassification).HasForeignKey<ProductClassification>(x => x.ImageId);

            builder.ToTable(name: nameof(ProductClassification), schema: Share.Library.Constant.MiniboxConstants.DbSchema.Dbo);
        }
    }
}
