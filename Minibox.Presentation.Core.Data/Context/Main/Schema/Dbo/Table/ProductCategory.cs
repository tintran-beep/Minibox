using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Minibox.Presentation.Core.Data.Context.Main.Schema.Dbo.Table
{
    public class ProductCategory : BaseEntity
    {
        public Guid ProductId { get; set; }
        public Guid CategoryId { get; set; }

        public virtual required Product Product { get; set; }
        public virtual required Category Category { get; set; }
    }

    public class ProductCategoryEntityTypeConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasKey(x => new { x.ProductId, x.CategoryId });

            builder.HasOne(x => x.Product).WithMany(x => x.ProductCategories).HasForeignKey(x => x.ProductId);
            builder.HasOne(x => x.Category).WithMany(x => x.ProductCategories).HasForeignKey(x => x.CategoryId);

            builder.ToTable(name: nameof(ProductCategory), schema: Share.Library.Constant.MiniboxConstants.DbSchema.Dbo);
        }
    }
}
