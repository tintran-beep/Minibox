using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Minibox.Presentation.Core.Data.Context.Main.Schema.Dbo.Seeding;

namespace Minibox.Presentation.Core.Data.Context.Main.Schema.Dbo.Table
{
    public class Category : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid? ImageId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public virtual Image? Image { get; set; }
        public virtual ICollection<Product>? Products { get; set; }
    }

    public class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Name).IsUnique();
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(3000).IsRequired();

            builder.HasOne(x => x.Image).WithOne(x => x.Category).HasForeignKey<Category>(x => x.ImageId);

            builder.ToTable(name: nameof(Category), schema: Share.Library.Constant.MiniboxConstants.DbSchema.Dbo);

            builder.HasData(_Seeder.Categories());
        }
    }
}
