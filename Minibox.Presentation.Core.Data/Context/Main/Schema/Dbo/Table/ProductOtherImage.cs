using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Minibox.Presentation.Core.Data.Context.Main.Schema.Dbo.Table
{
    public class ProductOtherImage : BaseEntity
    {
        public ProductOtherImage()
        {
            Id = Share.Library.Common.CommonHelper.NewSequenceGuid();
        }
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid ImageId { get; set; }

        public virtual required Product Product { get; set; }
        public virtual required Image Image { get; set; }
    }

    public class ProductOtherImageEntityTypeConfiguration : IEntityTypeConfiguration<ProductOtherImage>
    {
        public void Configure(EntityTypeBuilder<ProductOtherImage> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Product).WithMany(x => x.ProductOtherImages).HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Image).WithOne(x => x.ProductOtherImage).HasForeignKey<ProductOtherImage>(x => x.ImageId);

            builder.ToTable(name: nameof(ProductOtherImage), schema: Share.Library.Constant.MiniboxConstants.DbSchema.Dbo);
        }
    }
}
