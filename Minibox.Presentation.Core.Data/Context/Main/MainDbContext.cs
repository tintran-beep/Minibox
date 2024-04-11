using Microsoft.EntityFrameworkCore;
using Minibox.Presentation.Core.Data.Context.Main.Schema.Dbo.Table;

namespace Minibox.Presentation.Core.Data.Context.Main
{
    public class MainDbContext(DbContextOptions options) : BaseDbContext(options)
    {
        #region Schema: dbo
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
