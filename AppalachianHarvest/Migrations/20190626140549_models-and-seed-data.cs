using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppalachianHarvest.Migrations
{
    public partial class modelsandseeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrderDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    CustomerId = table.Column<string>(nullable: false),
                    PickupDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Order_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Producer",
                columns: table => new
                {
                    ProducerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    BusinessName = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    State = table.Column<string>(nullable: false),
                    ZipCode = table.Column<int>(nullable: false),
                    ProducerImage = table.Column<byte[]>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producer", x => x.ProducerId);
                });

            migrationBuilder.CreateTable(
                name: "ProductType",
                columns: table => new
                {
                    ProductTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: false),
                    TimeToExpire = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductType", x => x.ProductTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Shelf",
                columns: table => new
                {
                    ShelfId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shelf", x => x.ShelfId);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 55, nullable: false),
                    ProducerId = table.Column<int>(nullable: false),
                    ProductTypeId = table.Column<int>(nullable: false),
                    ShelfId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Image = table.Column<byte[]>(nullable: true),
                    IsOrganic = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Added = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Product_Producer_ProducerId",
                        column: x => x.ProducerId,
                        principalTable: "Producer",
                        principalColumn: "ProducerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_ProductType_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductType",
                        principalColumn: "ProductTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Shelf_ShelfId",
                        column: x => x.ShelfId,
                        principalTable: "Shelf",
                        principalColumn: "ShelfId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderProduct",
                columns: table => new
                {
                    OrderProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrderId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProduct", x => x.OrderProductId);
                    table.ForeignKey(
                        name: "FK_OrderProduct_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProduct_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "FirstName", "IsCustomer", "IsEmployee", "IsSupervisor", "LastName", "ProfilePicture" },
                values: new object[] { "00000000-ffff-ffff-ffff-ffffffffffff", 0, "1bd98d8e-6dd9-4032-982c-cad11b71c032", "ApplicationUser", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEFxl6BrvIAyO5DVydGJtu2rdX9lZs90IhVI8VDGtqP/NrFanmlhWM6IawblNknlg9Q==", null, false, "7f434309-a4d9-48e9-9ebb-8803db794577", false, "admin@admin.com", "Admin", true, true, true, "Person", null });

            migrationBuilder.InsertData(
                table: "Producer",
                columns: new[] { "ProducerId", "Address", "BusinessName", "City", "Email", "FirstName", "IsActive", "LastName", "Phone", "ProducerImage", "State", "ZipCode" },
                values: new object[,]
                {
                    { 1, "123 Prairie Lane", "Golden Hills Farms", "Ona", "goldenhills@farm.com", "Jimmy", true, "Smith", "304-300-0123", null, "WV", 25545 },
                    { 2, "111 Shocker Place", "Lightning Rod", "Culloden", "lightning@farm.com", "Sandra", true, "Dee", "304-300-2546", null, "WV", 25546 }
                });

            migrationBuilder.InsertData(
                table: "ProductType",
                columns: new[] { "ProductTypeId", "Description", "TimeToExpire" },
                values: new object[,]
                {
                    { 9, "Textiles", 365 },
                    { 8, "Beauty", 90 },
                    { 7, "Dairy", 7 },
                    { 5, "Baked Good", 3 },
                    { 6, "Meat", 7 },
                    { 3, "Leafy Green", 4 },
                    { 2, "Vegetable", 5 },
                    { 1, "Fruit", 4 },
                    { 4, "Canned Good", 180 }
                });

            migrationBuilder.InsertData(
                table: "Shelf",
                columns: new[] { "ShelfId", "Description" },
                values: new object[,]
                {
                    { 4, "Produce" },
                    { 1, "Freezer" },
                    { 2, "Cooler" },
                    { 3, "Center Display" },
                    { 5, "Aisle Shelving" }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "OrderId", "CustomerId", "PickupDate" },
                values: new object[] { 1, "00000000-ffff-ffff-ffff-ffffffffffff", new DateTime(2019, 6, 27, 10, 5, 48, 895, DateTimeKind.Local).AddTicks(768) });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "Image", "IsActive", "IsOrganic", "Name", "Price", "ProducerId", "ProductTypeId", "Quantity", "ShelfId" },
                values: new object[] { 4, null, true, true, "Lavender Soap", 3.9900000000000002, 2, 8, 12, 3 });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "Image", "IsActive", "IsOrganic", "Name", "Price", "ProducerId", "ProductTypeId", "Quantity", "ShelfId" },
                values: new object[] { 5, null, true, false, "Knit Scarf", 21.989999999999998, 2, 9, 1, 3 });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "Image", "IsActive", "IsOrganic", "Name", "Price", "ProducerId", "ProductTypeId", "Quantity", "ShelfId" },
                values: new object[] { 1, null, true, true, "Tomatoes", 1.99, 1, 1, 5, 4 });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "Image", "IsActive", "IsOrganic", "Name", "Price", "ProducerId", "ProductTypeId", "Quantity", "ShelfId" },
                values: new object[] { 2, null, true, true, "Zucchini", 1.99, 1, 2, 12, 4 });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "Image", "IsActive", "IsOrganic", "Name", "Price", "ProducerId", "ProductTypeId", "Quantity", "ShelfId" },
                values: new object[] { 3, null, true, true, "Lettuce", 1.99, 1, 3, 5, 4 });

            migrationBuilder.InsertData(
                table: "OrderProduct",
                columns: new[] { "OrderProductId", "OrderId", "ProductId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "OrderProduct",
                columns: new[] { "OrderProductId", "OrderId", "ProductId" },
                values: new object[] { 2, 1, 2 });

            migrationBuilder.InsertData(
                table: "OrderProduct",
                columns: new[] { "OrderProductId", "OrderId", "ProductId" },
                values: new object[] { 3, 1, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                table: "Order",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_OrderId",
                table: "OrderProduct",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_ProductId",
                table: "OrderProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProducerId",
                table: "Product",
                column: "ProducerId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductTypeId",
                table: "Product",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ShelfId",
                table: "Product",
                column: "ShelfId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderProduct");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Producer");

            migrationBuilder.DropTable(
                name: "ProductType");

            migrationBuilder.DropTable(
                name: "Shelf");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff");
        }
    }
}
