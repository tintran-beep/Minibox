using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Minibox.Presentation.Core.Data.Context.Main.Schema.Dbo.Table.AdministrativeDirectory
{
    public class Country : BaseEntity
    {
        public Country()
        {
            Id = Share.Library.Common.CommonHelper.NewSequenceGuid();
        }
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string PrefixPhoneCode { get; set; } = string.Empty;

        public virtual ICollection<Province>? Provinces { get; set; }
    }

    public class CountryEntityTypeConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Name).IsUnique();
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();

            builder.HasIndex(x => x.Code).IsUnique();
            builder.Property(x => x.Code).HasMaxLength(10).IsRequired();

            builder.HasIndex(x => x.PrefixPhoneCode).IsUnique();
            builder.Property(x => x.PrefixPhoneCode).HasMaxLength(10).IsRequired();

            builder.ToTable(name: nameof(Country), schema: Share.Library.Constant.MiniboxConstants.DbSchema.Dbo);
        }
    }
}
