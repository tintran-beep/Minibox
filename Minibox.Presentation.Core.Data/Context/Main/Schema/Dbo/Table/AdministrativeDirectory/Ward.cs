using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Minibox.Presentation.Core.Data.Context.Main.Schema.Dbo.Table.AdministrativeDirectory
{
    public class Ward : BaseEntity
    {
        public Ward()
        {
            Id = Share.Library.Common.CommonHelper.NewSequenceGuid();
        }
        public Guid Id { get; set; }
        public Guid DistrictId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Code { get; set; }
        public string? ZipCode { get; set; }

        public virtual required District District { get; set; }
        public virtual ICollection<Address>? Addresses { get; set; }
    }

    public class WardEntityTypeConfiguration : IEntityTypeConfiguration<Ward>
    {
        public void Configure(EntityTypeBuilder<Ward> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();

            builder.Property(x => x.Code).HasMaxLength(10);
            builder.Property(x => x.ZipCode).HasMaxLength(10);

            builder.HasOne(x => x.District).WithMany(x => x.Wards).HasForeignKey(x => x.DistrictId);

            builder.ToTable(name: nameof(Ward), schema: Share.Library.Constant.MiniboxConstants.DbSchema.Dbo);
        }
    }
}
