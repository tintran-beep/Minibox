﻿using Microsoft.EntityFrameworkCore;
using Minibox.Presentation.Core.Data.Context.Main.Schema.Dbo.Table;
using Minibox.Presentation.Core.Data.Context.Main.Schema.Dbo.Table.AdministrativeDirectory;

namespace Minibox.Presentation.Core.Data.Context.Main
{
    public class MainDbContext(DbContextOptions options) : BaseDbContext(options)
    {
        #region Schema: dbo

        //Administrative Directory
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<District> District { get; set; }
        public virtual DbSet<Province> Province { get; set; }
        public virtual DbSet<Ward> Ward { get; set; }
        //------------------------

        public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Image> Image { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductClassification> ProductClassification { get; set; }
        public virtual DbSet<ProductClassificationDetail> ProductClassificationsDetail { get; set; }
        public virtual DbSet<ProductOtherImage> ProductOtherImage { get; set; }
        public virtual DbSet<ProductProperty> ProductPropertie { get; set; }
        public virtual DbSet<Video> Video { get; set; }
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
