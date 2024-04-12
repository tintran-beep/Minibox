using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Minibox.Presentation.Core.Data.Context.Main.Schema.Dbo.Table
{
    public class ProductProperty : BaseEntity
    {
        public ProductProperty()
        {
            Id = Share.Library.Common.CommonHelper.NewSequenceGuid();
        }
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public string DataType { get; set; } = string.Empty;

        public virtual required Product Product { get; set; }
    }

    public class ProductPropertyEntityTypeConfiguration : IEntityTypeConfiguration<ProductProperty>
    {
        public void Configure(EntityTypeBuilder<ProductProperty> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Value).HasMaxLength(250).IsRequired();
            builder.Property(x => x.DataType).HasMaxLength(50).IsRequired();

            builder.HasOne(x => x.Product).WithMany(x => x.ProductProperties).HasForeignKey(x => x.ProductId);

            builder.ToTable(name: nameof(ProductProperty), schema: Share.Library.Constant.MiniboxConstants.DbSchema.Dbo);
        }
    }
}
