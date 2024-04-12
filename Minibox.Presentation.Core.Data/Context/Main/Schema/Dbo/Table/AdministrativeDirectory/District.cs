using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Minibox.Presentation.Core.Data.Context.Main.Schema.Dbo.Table.AdministrativeDirectory.Seeding;

namespace Minibox.Presentation.Core.Data.Context.Main.Schema.Dbo.Table.AdministrativeDirectory
{
    public class District : BaseEntity
    {
        public District()
        {
            Id = Share.Library.Common.CommonHelper.NewSequenceGuid();
        }
        public Guid Id { get; set; }
        public Guid ProvinceId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Code { get; set; }
        public string? ZipCode { get; set; }

        public virtual required Province Province { get; set; }
        public virtual ICollection<Ward>? Wards { get; set; }
    }

    public class DistrictEntityTypeConfiguration : IEntityTypeConfiguration<District>
    {
        public void Configure(EntityTypeBuilder<District> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Name).IsUnique();
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();

            builder.Property(x => x.Code).HasMaxLength(10);
            builder.Property(x => x.ZipCode).HasMaxLength(20);

            builder.HasOne(x => x.Province).WithMany(x => x.Districts).HasForeignKey(x => x.ProvinceId);

            builder.ToTable(name: nameof(District), schema: Share.Library.Constant.MiniboxConstants.DbSchema.Dbo);

            //builder.HasData(Seeder.Districts());
        }
    }
}
