using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Minibox.Presentation.Core.Data.Context.Main.Schema.Dbo.Table
{
    public class Image : BaseEntity
    {
        public Guid Id { get; set; }
        public byte[] Buffer { get; set; } = [];

        public virtual Brand? Brand { get; set; }
        public virtual ProductClassification? ProductClassification { get; set; }
        public virtual ProductClassificationDetail? ProductClassificationDetail { get; set; }
    }

    public class ImageEntityTypeConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Buffer).HasMaxLength(8000).IsRequired();

            builder.ToTable(name: nameof(Image), schema: Share.Library.Constant.MiniboxConstants.DbSchema.Dbo);
        }
    }
}
