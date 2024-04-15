using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Minibox.Presentation.Core.Data.Context.Main.MigrationHistory
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    PrefixPhoneCode = table.Column<string>(type: "nvarchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Buffer = table.Column<byte[]>(type: "varbinary(8000)", maxLength: 8000, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Video",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Buffer = table.Column<byte[]>(type: "varbinary(8000)", maxLength: 8000, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Video", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Province",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Province", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Province_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Brand",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Origin = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Brand_Image_ImageId",
                        column: x => x.ImageId,
                        principalSchema: "dbo",
                        principalTable: "Image",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Category",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_Category_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "dbo",
                        principalTable: "Category",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Category_Image_ImageId",
                        column: x => x.ImageId,
                        principalSchema: "dbo",
                        principalTable: "Image",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "District",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProvinceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_District", x => x.Id);
                    table.ForeignKey(
                        name: "FK_District_Province_ProvinceId",
                        column: x => x.ProvinceId,
                        principalSchema: "dbo",
                        principalTable: "Province",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CoverImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CoverVideoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SKU = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Brand_BrandId",
                        column: x => x.BrandId,
                        principalSchema: "dbo",
                        principalTable: "Brand",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "dbo",
                        principalTable: "Category",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Product_Image_CoverImageId",
                        column: x => x.CoverImageId,
                        principalSchema: "dbo",
                        principalTable: "Image",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Product_Video_CoverVideoId",
                        column: x => x.CoverVideoId,
                        principalSchema: "dbo",
                        principalTable: "Video",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Ward",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DistrictId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ward", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ward_District_DistrictId",
                        column: x => x.DistrictId,
                        principalSchema: "dbo",
                        principalTable: "District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                schema: "dbo",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => new { x.ProductId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ProductCategory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "dbo",
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategory_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "dbo",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductClassification",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductClassification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductClassification_Image_ImageId",
                        column: x => x.ImageId,
                        principalSchema: "dbo",
                        principalTable: "Image",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductClassification_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "dbo",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductOtherImage",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOtherImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductOtherImage_Image_ImageId",
                        column: x => x.ImageId,
                        principalSchema: "dbo",
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductOtherImage_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "dbo",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductProperty",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    DataType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductProperty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductProperty_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "dbo",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressDetail = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    GeographicalCoordinates = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Ward_WardId",
                        column: x => x.WardId,
                        principalSchema: "dbo",
                        principalTable: "Ward",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductClassificationDetail",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductClassificationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SKU = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitPrice = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    NetWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitWeight = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductClassificationDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductClassificationDetail_Image_ImageId",
                        column: x => x.ImageId,
                        principalSchema: "dbo",
                        principalTable: "Image",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductClassificationDetail_ProductClassification_ProductClassificationId",
                        column: x => x.ProductClassificationId,
                        principalSchema: "dbo",
                        principalTable: "ProductClassification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Brand",
                columns: new[] { "Id", "Description", "ImageId", "Name", "Origin" },
                values: new object[,]
                {
                    { new Guid("22da518d-faf0-11ee-ad1e-f889d243ee30"), "", null, "No brand", "" },
                    { new Guid("22da518e-faf0-11ee-ad1e-f889d243ee30"), "", null, "Cosrx", "Korean" },
                    { new Guid("22da518f-faf0-11ee-ad1e-f889d243ee30"), "", null, "Estée Lauder", "USA" },
                    { new Guid("22da5190-faf0-11ee-ad1e-f889d243ee30"), "", null, "Laneige", "Korean" },
                    { new Guid("22da5191-faf0-11ee-ad1e-f889d243ee30"), "", null, "Foodaholic", "Korean" },
                    { new Guid("22da5192-faf0-11ee-ad1e-f889d243ee30"), "", null, "L''Oréal Paris", "France" },
                    { new Guid("22da5193-faf0-11ee-ad1e-f889d243ee30"), "", null, "Dear, Klairs", "Korean" },
                    { new Guid("22da5194-faf0-11ee-ad1e-f889d243ee30"), "", null, "Ceiba Tree", "France" },
                    { new Guid("22da5195-faf0-11ee-ad1e-f889d243ee30"), "", null, "Habaria", "China" },
                    { new Guid("22da5196-faf0-11ee-ad1e-f889d243ee30"), "", null, "Angel's Liquid", "Korean" },
                    { new Guid("22da5197-faf0-11ee-ad1e-f889d243ee30"), "", null, "BNBG", "Korean" },
                    { new Guid("22da5198-faf0-11ee-ad1e-f889d243ee30"), "", null, "Simple", "England" },
                    { new Guid("22da5199-faf0-11ee-ad1e-f889d243ee30"), "", null, "Redwin", "Australia" },
                    { new Guid("22da519a-faf0-11ee-ad1e-f889d243ee30"), "", null, "Silky Hands", "Russia" },
                    { new Guid("22da519b-faf0-11ee-ad1e-f889d243ee30"), "", null, "Olay", "USA" },
                    { new Guid("22da519c-faf0-11ee-ad1e-f889d243ee30"), "", null, "Vaseline", "England" },
                    { new Guid("22da519d-faf0-11ee-ad1e-f889d243ee30"), "", null, "MartiDerm La Formula", "Spain" },
                    { new Guid("22da519e-faf0-11ee-ad1e-f889d243ee30"), "", null, "Skin1004", "Korean" },
                    { new Guid("22da519f-faf0-11ee-ad1e-f889d243ee30"), "", null, "Hatomugi", "Japan" },
                    { new Guid("22da51a0-faf0-11ee-ad1e-f889d243ee30"), "", null, "Silcot", "Japan" },
                    { new Guid("22da51a1-faf0-11ee-ad1e-f889d243ee30"), "", null, "A BONNE", "Thailand" },
                    { new Guid("22da51a2-faf0-11ee-ad1e-f889d243ee30"), "", null, "Evoluderm", "France" },
                    { new Guid("22da51a3-faf0-11ee-ad1e-f889d243ee30"), "", null, "Bioderma", "France" },
                    { new Guid("22da51a4-faf0-11ee-ad1e-f889d243ee30"), "", null, "Balance Active Fomular", "England" },
                    { new Guid("22da51a5-faf0-11ee-ad1e-f889d243ee30"), "", null, "The Odinary", "Canadian" },
                    { new Guid("22da51a6-faf0-11ee-ad1e-f889d243ee30"), "", null, "Huxley", "Korean" },
                    { new Guid("22da51a7-faf0-11ee-ad1e-f889d243ee30"), "", null, "Dr.G", "Korean" },
                    { new Guid("22da51a8-faf0-11ee-ad1e-f889d243ee30"), "", null, "Dr.SkinCare", "Korean" },
                    { new Guid("22da51a9-faf0-11ee-ad1e-f889d243ee30"), "", null, "Ziaja", "Poland" },
                    { new Guid("22da51aa-faf0-11ee-ad1e-f889d243ee30"), "", null, "9Wishes", "Korean" },
                    { new Guid("22da51ab-faf0-11ee-ad1e-f889d243ee30"), "", null, "BYPHASSE", "Spain" },
                    { new Guid("22da51ac-faf0-11ee-ad1e-f889d243ee30"), "", null, "ANESSA", "Japan" },
                    { new Guid("22da51ad-faf0-11ee-ad1e-f889d243ee30"), "", null, "Vichy", "France" },
                    { new Guid("22da51ae-faf0-11ee-ad1e-f889d243ee30"), "", null, "MEDIAN", "Korean" },
                    { new Guid("22da51af-faf0-11ee-ad1e-f889d243ee30"), "", null, "Hada Labo", "Japan" },
                    { new Guid("22da51b0-faf0-11ee-ad1e-f889d243ee30"), "", null, "Rosette", "Japan" },
                    { new Guid("22da51b1-faf0-11ee-ad1e-f889d243ee30"), "", null, "MARVIS", "Italian" },
                    { new Guid("22da51b2-faf0-11ee-ad1e-f889d243ee30"), "", null, "Mediheal", "Korean" },
                    { new Guid("22da51b3-faf0-11ee-ad1e-f889d243ee30"), "", null, "Forencos", "Korean" },
                    { new Guid("22da51b4-faf0-11ee-ad1e-f889d243ee30"), "", null, "Timeless", "USA" },
                    { new Guid("22da51b5-faf0-11ee-ad1e-f889d243ee30"), "", null, "Embryolisse", "France" },
                    { new Guid("22da51b6-faf0-11ee-ad1e-f889d243ee30"), "", null, "Cell Fusion C", "Korean" },
                    { new Guid("22da51b7-faf0-11ee-ad1e-f889d243ee30"), "", null, "CeraVe", "USA" },
                    { new Guid("22da51b8-faf0-11ee-ad1e-f889d243ee30"), "", null, "Propolinse", "Japan" },
                    { new Guid("22da51b9-faf0-11ee-ad1e-f889d243ee30"), "", null, "Elasten", "Germany" },
                    { new Guid("22da51ba-faf0-11ee-ad1e-f889d243ee30"), "", null, "Scentio", "Thailand" },
                    { new Guid("22da51bb-faf0-11ee-ad1e-f889d243ee30"), "", null, "White Conc", "Japan" },
                    { new Guid("22da51bc-faf0-11ee-ad1e-f889d243ee30"), "", null, "La Roche-Posay", "France" },
                    { new Guid("22da51bd-faf0-11ee-ad1e-f889d243ee30"), "", null, "DHC", "Japan" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Category",
                columns: new[] { "Id", "Description", "ImageId", "Name", "ParentId" },
                values: new object[,]
                {
                    { new Guid("cdab81bb-faf2-11ee-ad1e-f889d243ee30"), "", null, "Chưa phân loại", null },
                    { new Guid("cdab81bc-faf2-11ee-ad1e-f889d243ee30"), "", null, "Nước hoa", null },
                    { new Guid("cdab81c1-faf2-11ee-ad1e-f889d243ee30"), "", null, "Trang điểm", null },
                    { new Guid("cdab81c7-faf2-11ee-ad1e-f889d243ee30"), "", null, "Chăm sóc tóc", null },
                    { new Guid("cdab81cc-faf2-11ee-ad1e-f889d243ee30"), "", null, "Chăm sóc da mặt", null },
                    { new Guid("cdab81d5-faf2-11ee-ad1e-f889d243ee30"), "", null, "Chăm sóc cơ thể", null },
                    { new Guid("cdab81df-faf2-11ee-ad1e-f889d243ee30"), "", null, "Chăm sóc cá nhân", null },
                    { new Guid("cdab81e4-faf2-11ee-ad1e-f889d243ee30"), "", null, "Thực phẩm chức năng", null },
                    { new Guid("cdab81bd-faf2-11ee-ad1e-f889d243ee30"), "", null, "Nước hoa nữ", new Guid("cdab81bc-faf2-11ee-ad1e-f889d243ee30") },
                    { new Guid("cdab81be-faf2-11ee-ad1e-f889d243ee30"), "", null, "Nước hoa nam", new Guid("cdab81bc-faf2-11ee-ad1e-f889d243ee30") },
                    { new Guid("cdab81bf-faf2-11ee-ad1e-f889d243ee30"), "", null, "Nước hoa vùng kín", new Guid("cdab81bc-faf2-11ee-ad1e-f889d243ee30") },
                    { new Guid("cdab81c0-faf2-11ee-ad1e-f889d243ee30"), "", null, "Xịt thơm toàn thân", new Guid("cdab81bc-faf2-11ee-ad1e-f889d243ee30") },
                    { new Guid("cdab81c2-faf2-11ee-ad1e-f889d243ee30"), "", null, "Trang điểm môi", new Guid("cdab81c1-faf2-11ee-ad1e-f889d243ee30") },
                    { new Guid("cdab81c3-faf2-11ee-ad1e-f889d243ee30"), "", null, "Trang điểm mặt", new Guid("cdab81c1-faf2-11ee-ad1e-f889d243ee30") },
                    { new Guid("cdab81c4-faf2-11ee-ad1e-f889d243ee30"), "", null, "Trang điểm mắt", new Guid("cdab81c1-faf2-11ee-ad1e-f889d243ee30") },
                    { new Guid("cdab81c5-faf2-11ee-ad1e-f889d243ee30"), "", null, "Trang điểm móng", new Guid("cdab81c1-faf2-11ee-ad1e-f889d243ee30") },
                    { new Guid("cdab81c6-faf2-11ee-ad1e-f889d243ee30"), "", null, "Bộ dụng cụ trang điểm", new Guid("cdab81c1-faf2-11ee-ad1e-f889d243ee30") },
                    { new Guid("cdab81c8-faf2-11ee-ad1e-f889d243ee30"), "", null, "Dầu xả", new Guid("cdab81c7-faf2-11ee-ad1e-f889d243ee30") },
                    { new Guid("cdab81c9-faf2-11ee-ad1e-f889d243ee30"), "", null, "Dầu gội", new Guid("cdab81c7-faf2-11ee-ad1e-f889d243ee30") },
                    { new Guid("cdab81ca-faf2-11ee-ad1e-f889d243ee30"), "", null, "Dưỡng tóc", new Guid("cdab81c7-faf2-11ee-ad1e-f889d243ee30") },
                    { new Guid("cdab81cb-faf2-11ee-ad1e-f889d243ee30"), "", null, "Tẩy tế bào chết da đầu", new Guid("cdab81c7-faf2-11ee-ad1e-f889d243ee30") },
                    { new Guid("cdab81cd-faf2-11ee-ad1e-f889d243ee30"), "", null, "Làm sạch da", new Guid("cdab81cc-faf2-11ee-ad1e-f889d243ee30") },
                    { new Guid("cdab81ce-faf2-11ee-ad1e-f889d243ee30"), "", null, "Đặc trị", new Guid("cdab81cc-faf2-11ee-ad1e-f889d243ee30") },
                    { new Guid("cdab81cf-faf2-11ee-ad1e-f889d243ee30"), "", null, "Dưỡng ẩm", new Guid("cdab81cc-faf2-11ee-ad1e-f889d243ee30") },
                    { new Guid("cdab81d0-faf2-11ee-ad1e-f889d243ee30"), "", null, "Dưỡng mắt", new Guid("cdab81cc-faf2-11ee-ad1e-f889d243ee30") },
                    { new Guid("cdab81d1-faf2-11ee-ad1e-f889d243ee30"), "", null, "Dưỡng môi", new Guid("cdab81cc-faf2-11ee-ad1e-f889d243ee30") },
                    { new Guid("cdab81d2-faf2-11ee-ad1e-f889d243ee30"), "", null, "Chống nắng da mặt", new Guid("cdab81cc-faf2-11ee-ad1e-f889d243ee30") },
                    { new Guid("cdab81d3-faf2-11ee-ad1e-f889d243ee30"), "", null, "Mặt nạ", new Guid("cdab81cc-faf2-11ee-ad1e-f889d243ee30") },
                    { new Guid("cdab81d4-faf2-11ee-ad1e-f889d243ee30"), "", null, "Dụng cụ chăm sóc da mặt", new Guid("cdab81cc-faf2-11ee-ad1e-f889d243ee30") },
                    { new Guid("cdab81d6-faf2-11ee-ad1e-f889d243ee30"), "", null, "Sữa tắm", new Guid("cdab81d5-faf2-11ee-ad1e-f889d243ee30") },
                    { new Guid("cdab81d7-faf2-11ee-ad1e-f889d243ee30"), "", null, "Xà phòng", new Guid("cdab81d5-faf2-11ee-ad1e-f889d243ee30") },
                    { new Guid("cdab81d8-faf2-11ee-ad1e-f889d243ee30"), "", null, "Tẩy tế bào chết body", new Guid("cdab81d5-faf2-11ee-ad1e-f889d243ee30") },
                    { new Guid("cdab81d9-faf2-11ee-ad1e-f889d243ee30"), "", null, "Dưỡng da tay/chân", new Guid("cdab81d5-faf2-11ee-ad1e-f889d243ee30") },
                    { new Guid("cdab81da-faf2-11ee-ad1e-f889d243ee30"), "", null, "Chống nắng cơ thể", new Guid("cdab81d5-faf2-11ee-ad1e-f889d243ee30") },
                    { new Guid("cdab81db-faf2-11ee-ad1e-f889d243ee30"), "", null, "Khử mùi", new Guid("cdab81d5-faf2-11ee-ad1e-f889d243ee30") },
                    { new Guid("cdab81dc-faf2-11ee-ad1e-f889d243ee30"), "", null, "Tẩy lông/triệt lông", new Guid("cdab81d5-faf2-11ee-ad1e-f889d243ee30") },
                    { new Guid("cdab81dd-faf2-11ee-ad1e-f889d243ee30"), "", null, "Dưỡng thể", new Guid("cdab81d5-faf2-11ee-ad1e-f889d243ee30") },
                    { new Guid("cdab81de-faf2-11ee-ad1e-f889d243ee30"), "", null, "Bộ dụng cụ chăm sóc cơ thể", new Guid("cdab81d5-faf2-11ee-ad1e-f889d243ee30") },
                    { new Guid("cdab81e0-faf2-11ee-ad1e-f889d243ee30"), "", null, "Chăm sóc phụ nữ", new Guid("cdab81df-faf2-11ee-ad1e-f889d243ee30") },
                    { new Guid("cdab81e1-faf2-11ee-ad1e-f889d243ee30"), "", null, "Chăm sóc răng miệng", new Guid("cdab81df-faf2-11ee-ad1e-f889d243ee30") },
                    { new Guid("cdab81e2-faf2-11ee-ad1e-f889d243ee30"), "", null, "Chăm sóc sức khỏe", new Guid("cdab81df-faf2-11ee-ad1e-f889d243ee30") },
                    { new Guid("cdab81e3-faf2-11ee-ad1e-f889d243ee30"), "", null, "Khăn giấy/ khăn ướt", new Guid("cdab81df-faf2-11ee-ad1e-f889d243ee30") },
                    { new Guid("cdab81e5-faf2-11ee-ad1e-f889d243ee30"), "", null, "Hỗ trợ làm đẹp", new Guid("cdab81e4-faf2-11ee-ad1e-f889d243ee30") },
                    { new Guid("cdab81e6-faf2-11ee-ad1e-f889d243ee30"), "", null, "Hỗ trợ sức khỏe", new Guid("cdab81e4-faf2-11ee-ad1e-f889d243ee30") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_WardId",
                schema: "dbo",
                table: "Address",
                column: "WardId");

            migrationBuilder.CreateIndex(
                name: "IX_Brand_ImageId",
                schema: "dbo",
                table: "Brand",
                column: "ImageId",
                unique: true,
                filter: "[ImageId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Brand_Name",
                schema: "dbo",
                table: "Brand",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Category_ImageId",
                schema: "dbo",
                table: "Category",
                column: "ImageId",
                unique: true,
                filter: "[ImageId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Category_Name",
                schema: "dbo",
                table: "Category",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Category_ParentId",
                schema: "dbo",
                table: "Category",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_District_ProvinceId",
                schema: "dbo",
                table: "District",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_BrandId",
                schema: "dbo",
                table: "Product",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                schema: "dbo",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CoverImageId",
                schema: "dbo",
                table: "Product",
                column: "CoverImageId",
                unique: true,
                filter: "[CoverImageId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CoverVideoId",
                schema: "dbo",
                table: "Product",
                column: "CoverVideoId",
                unique: true,
                filter: "[CoverVideoId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Product_SKU",
                schema: "dbo",
                table: "Product",
                column: "SKU",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_CategoryId",
                schema: "dbo",
                table: "ProductCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductClassification_ImageId",
                schema: "dbo",
                table: "ProductClassification",
                column: "ImageId",
                unique: true,
                filter: "[ImageId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProductClassification_ProductId",
                schema: "dbo",
                table: "ProductClassification",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductClassificationDetail_ImageId",
                schema: "dbo",
                table: "ProductClassificationDetail",
                column: "ImageId",
                unique: true,
                filter: "[ImageId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProductClassificationDetail_ProductClassificationId",
                schema: "dbo",
                table: "ProductClassificationDetail",
                column: "ProductClassificationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductClassificationDetail_SKU",
                schema: "dbo",
                table: "ProductClassificationDetail",
                column: "SKU",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductOtherImage_ImageId",
                schema: "dbo",
                table: "ProductOtherImage",
                column: "ImageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductOtherImage_ProductId",
                schema: "dbo",
                table: "ProductOtherImage",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductProperty_ProductId",
                schema: "dbo",
                table: "ProductProperty",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Province_CountryId",
                schema: "dbo",
                table: "Province",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Ward_DistrictId",
                schema: "dbo",
                table: "Ward",
                column: "DistrictId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ProductCategory",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ProductClassificationDetail",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ProductOtherImage",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ProductProperty",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Ward",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ProductClassification",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "District",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Province",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Brand",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Category",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Video",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Image",
                schema: "dbo");
        }
    }
}
