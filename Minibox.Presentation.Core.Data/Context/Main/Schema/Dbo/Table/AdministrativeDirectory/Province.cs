using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Minibox.Presentation.Core.Data.Context.Main.Schema.Dbo.Table.AdministrativeDirectory
{
    public class Province : BaseEntity
    {
        public Province()
        {
            Id = Share.Library.Common.CommonHelper.NewSequenceGuid();
        }
        public Guid Id { get; set; }
        public Guid CountryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Code { get; set; }
        public string? ZipCode { get; set; }

        public virtual required Country Country { get; set; }
        public virtual ICollection<District>? Districts { get; set; }
    }

    public class ProvinceEntityTypeConfiguration : IEntityTypeConfiguration<Province>
    {
        public void Configure(EntityTypeBuilder<Province> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Name).IsUnique();
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();

            builder.Property(x => x.Code).HasMaxLength(10);
            builder.Property(x => x.ZipCode).HasMaxLength(10);

            builder.HasOne(x => x.Country).WithMany(x => x.Provinces).HasForeignKey(x => x.CountryId);

            builder.ToTable(name: nameof(Province), schema: Share.Library.Constant.MiniboxConstants.DbSchema.Dbo);
        }
    }
}
