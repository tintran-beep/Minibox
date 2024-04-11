using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Minibox.Presentation.Core.Data.Context.Main.Schema.Dbo.Table
{
    public class Video : BaseEntity
    {
        public Guid Id { get; set; }
        public byte[] Buffer { get; set; } = [];
        public string Url { get; set; } = string.Empty;

        public virtual Product? Product { get; set; }
    }

    public class VideoEntityTypeConfiguration : IEntityTypeConfiguration<Video>
    {
        public void Configure(EntityTypeBuilder<Video> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Url).HasMaxLength(250).IsRequired();
            builder.Property(x => x.Buffer).HasMaxLength(8000).IsRequired();

            builder.ToTable(name: nameof(Video), schema: Share.Library.Constant.MiniboxConstants.DbSchema.Dbo);
        }
    }
}
