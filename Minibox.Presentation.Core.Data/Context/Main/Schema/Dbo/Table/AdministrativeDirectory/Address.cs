using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Minibox.Presentation.Core.Data.Context.Main.Schema.Dbo.Table.AdministrativeDirectory
{
    public class Address : BaseEntity
    {
        public Address()
        {
            Id = Share.Library.Common.CommonHelper.NewSequenceGuid();
        }
        public Guid Id { get; set; }
        public Guid WardId { get; set; }
        public string AddressDetail { get; set; } = string.Empty;
        public string GeographicalCoordinates { get; set; } = string.Empty;

        public virtual required Ward Ward { get; set; }
    }

    public class AddressEntityTypeConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.AddressDetail).HasMaxLength(250).IsRequired(); 
            builder.Property(x => x.GeographicalCoordinates).HasMaxLength(250).IsRequired();

            builder.HasOne(x => x.Ward).WithMany(x => x.Addresses).HasForeignKey(x => x.WardId);

            builder.ToTable(name: nameof(Address), schema: Share.Library.Constant.MiniboxConstants.DbSchema.Dbo);
        }
    }
}
