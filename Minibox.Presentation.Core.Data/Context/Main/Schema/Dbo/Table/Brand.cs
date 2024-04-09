using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Minibox.Presentation.Core.Data.Context.Main.Schema.Dbo.Table
{
    public class Brand : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid? ImageId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Origin { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public virtual Image? Image { get; set; }
    }

    public class BrandEntityTypeConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Name).IsUnique();
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Origin).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(3000).IsRequired();

            builder.HasOne(x => x.Image).WithOne(x => x.Brand).HasForeignKey<Brand>(x => x.ImageId);

            builder.ToTable(name: nameof(Brand), schema: Share.Library.Constant.MiniboxConstants.DbSchema.Dbo);
        }
    }
}
