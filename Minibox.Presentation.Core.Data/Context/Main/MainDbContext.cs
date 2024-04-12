using Microsoft.EntityFrameworkCore;
using Minibox.Presentation.Core.Data.Context.Main.Schema.Dbo.Table;
using Minibox.Presentation.Core.Data.Context.Main.Schema.Dbo.Table.AdministrativeDirectory;

namespace Minibox.Presentation.Core.Data.Context.Main
{
    public class MainDbContext(DbContextOptions options) : BaseDbContext(options)
    {
        #region Schema: dbo

        //Administrative Directory
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<Ward> Wards { get; set; }
        //------------------------

        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductClassification> ProductClassifications { get; set; }
        public virtual DbSet<ProductClassificationDetail> ProductClassificationsDetails { get; set; }
        public virtual DbSet<ProductOtherImage> ProductOtherImages { get; set; }
        public virtual DbSet<ProductProperty> ProductProperties { get; set; }
        public virtual DbSet<Video> Videos { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region Schema: dbo

            //Administrative Directory
            new AddressEntityTypeConfiguration().Configure(builder.Entity<Address>());

            new AddressEntityTypeConfiguration().Configure(builder.Entity<Address>());

            new DistrictEntityTypeConfiguration().Configure(builder.Entity<District>());

            new ProvinceEntityTypeConfiguration().Configure(builder.Entity<Province>());

            new WardEntityTypeConfiguration().Configure(builder.Entity<Ward>());
            //------------------------

            new BrandEntityTypeConfiguration().Configure(builder.Entity<Brand>());

            new CategoryEntityTypeConfiguration().Configure(builder.Entity<Category>());

            new ImageEntityTypeConfiguration().Configure(builder.Entity<Image>());

            new ProductEntityTypeConfiguration().Configure(builder.Entity<Product>());

            new ProductClassificationEntityTypeConfiguration().Configure(builder.Entity<ProductClassification>());

            new ProductClassificationDetailEntityTypeConfiguration().Configure(builder.Entity<ProductClassificationDetail>());

            new ProductOtherImageEntityTypeConfiguration().Configure(builder.Entity<ProductOtherImage>());

            new ProductPropertyEntityTypeConfiguration().Configure(builder.Entity<ProductProperty>());

            new VideoEntityTypeConfiguration().Configure(builder.Entity<Video>());
            #endregion

            base.OnModelCreating(builder);
        }
    }
}
