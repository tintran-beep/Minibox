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
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_Image_ImageId",
                        column: x => x.ImageId,
                        principalSchema: "dbo",
                        principalTable: "Image",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CoverImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CoverVideoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SKU = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: false)
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
                name: "ProductClassificationDetail",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductClassificationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SKU = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                values: new object[] { new Guid("1aa06459-843a-4958-9d21-13e900920001"), "", null, "No brand", "" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Category",
                columns: new[] { "Id", "Description", "ImageId", "Name" },
                values: new object[,]
                {
                    { new Guid("1aa06459-843a-4958-9d21-13e900920001"), "Category.Skincare.Description", null, "Category.Skincare" },
                    { new Guid("1aa06459-843a-4958-9d21-13e900920002"), "Category.Bodycare.Description", null, "Category.Bodycare" },
                    { new Guid("1aa06459-843a-4958-9d21-13e900920003"), "Category.Teethcare.Description", null, "Category.Teethcare" },
                    { new Guid("1aa06459-843a-4958-9d21-13e900920004"), "Category.Haircare.Description", null, "Category.Haircare" },
                    { new Guid("1aa06459-843a-4958-9d21-13e900920005"), "Category.Makeup.Description", null, "Category.Makeup" }
                });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "ProductClassification",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Product",
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
                name: "Image",
                schema: "dbo");
        }
    }
}
