using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Minibox.Presentation.Core.Data.Context.Main.Schema.Dbo.Table
{
    public class Image : BaseEntity
    {
        public Image()
        {
            Id = Share.Library.Common.CommonHelper.NewSequenceGuid();
        }
        public Guid Id { get; set; }
        public byte[] Buffer { get; set; } = [];
        public string Url { get; set; } = string.Empty;

        public virtual Brand? Brand { get; set; }
        public virtual Product? Product { get; set; }
        public virtual Category? Category { get; set; }
        public virtual ProductOtherImage? ProductOtherImage { get; set; }
        public virtual ProductClassification? ProductClassification { get; set; }
        public virtual ProductClassificationDetail? ProductClassificationDetail { get; set; }
    }

    public class ImageEntityTypeConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Url).HasMaxLength(250).IsRequired();
            builder.Property(x => x.Buffer).HasMaxLength(8000).IsRequired();

            builder.ToTable(name: nameof(Image), schema: Share.Library.Constant.MiniboxConstants.DbSchema.Dbo);
        }
    }
}
