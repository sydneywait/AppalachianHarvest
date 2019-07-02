using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppalachianHarvest.Migrations
{
    public partial class dbsets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_AspNetUsers_CustomerId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProduct_Order_OrderId",
                table: "OrderProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProduct_Product_ProductId",
                table: "OrderProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Producer_ProducerId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductType_ProductTypeId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Shelf_ShelfId",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shelf",
                table: "Shelf");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductType",
                table: "ProductType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Producer",
                table: "Producer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 5);

            migrationBuilder.RenameTable(
                name: "Shelf",
                newName: "Shelves");

            migrationBuilder.RenameTable(
                name: "ProductType",
                newName: "ProductTypes");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "Producer",
                newName: "Producers");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "Orders");

            migrationBuilder.RenameIndex(
                name: "IX_Product_ShelfId",
                table: "Products",
                newName: "IX_Products_ShelfId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_ProductTypeId",
                table: "Products",
                newName: "IX_Products_ProductTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_ProducerId",
                table: "Products",
                newName: "IX_Products_ProducerId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_CustomerId",
                table: "Orders",
                newName: "IX_Orders_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shelves",
                table: "Shelves",
                column: "ShelfId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductTypes",
                table: "ProductTypes",
                column: "ProductTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Producers",
                table: "Producers",
                column: "ProducerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "OrderId");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "11bc5d35-bb3e-489c-8abe-820479d8dfe9", "AQAAAAEAACcQAAAAEBaCg/U0ZF/MDzVYt6PjIJRH0Acg7AyR7G6kBljdOhCxtlkkQOqhCrfY80CJ5JNtjQ==" });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CustomerId", "PickupDate" },
                values: new object[] { 1, "00000000-ffff-ffff-ffff-ffffffffffff", new DateTime(2019, 7, 3, 10, 20, 23, 568, DateTimeKind.Local).AddTicks(104) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Image", "IsActive", "IsOrganic", "Name", "Price", "ProducerId", "ProductTypeId", "Quantity", "ShelfId" },
                values: new object[] { 1, null, true, true, "Tomatoes", 1.99, 1, 1, 5, 4 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Image", "IsActive", "IsOrganic", "Name", "Price", "ProducerId", "ProductTypeId", "Quantity", "ShelfId" },
                values: new object[] { 2, null, true, true, "Zucchini", 1.99, 1, 2, 12, 4 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Image", "IsActive", "IsOrganic", "Name", "Price", "ProducerId", "ProductTypeId", "Quantity", "ShelfId" },
                values: new object[] { 3, null, true, true, "Lettuce", 1.99, 1, 3, 5, 4 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Image", "IsActive", "IsOrganic", "Name", "Price", "ProducerId", "ProductTypeId", "Quantity", "ShelfId" },
                values: new object[] { 4, null, true, true, "Lavender Soap", 3.9900000000000002, 2, 8, 12, 3 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Image", "IsActive", "IsOrganic", "Name", "Price", "ProducerId", "ProductTypeId", "Quantity", "ShelfId" },
                values: new object[] { 5, null, true, false, "Knit Scarf", 21.989999999999998, 2, 9, 1, 3 });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProduct_Orders_OrderId",
                table: "OrderProduct",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProduct_Products_ProductId",
                table: "OrderProduct",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Producers_ProducerId",
                table: "Products",
                column: "ProducerId",
                principalTable: "Producers",
                principalColumn: "ProducerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductTypes_ProductTypeId",
                table: "Products",
                column: "ProductTypeId",
                principalTable: "ProductTypes",
                principalColumn: "ProductTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Shelves_ShelfId",
                table: "Products",
                column: "ShelfId",
                principalTable: "Shelves",
                principalColumn: "ShelfId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProduct_Orders_OrderId",
                table: "OrderProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProduct_Products_ProductId",
                table: "OrderProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_CustomerId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Producers_ProducerId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductTypes_ProductTypeId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Shelves_ShelfId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shelves",
                table: "Shelves");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductTypes",
                table: "ProductTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Producers",
                table: "Producers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5);

            migrationBuilder.RenameTable(
                name: "Shelves",
                newName: "Shelf");

            migrationBuilder.RenameTable(
                name: "ProductTypes",
                newName: "ProductType");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.RenameTable(
                name: "Producers",
                newName: "Producer");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Order");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ShelfId",
                table: "Product",
                newName: "IX_Product_ShelfId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ProductTypeId",
                table: "Product",
                newName: "IX_Product_ProductTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ProducerId",
                table: "Product",
                newName: "IX_Product_ProducerId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_CustomerId",
                table: "Order",
                newName: "IX_Order_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shelf",
                table: "Shelf",
                column: "ShelfId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductType",
                table: "ProductType",
                column: "ProductTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Producer",
                table: "Producer",
                column: "ProducerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "OrderId");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1bd98d8e-6dd9-4032-982c-cad11b71c032", "AQAAAAEAACcQAAAAEFxl6BrvIAyO5DVydGJtu2rdX9lZs90IhVI8VDGtqP/NrFanmlhWM6IawblNknlg9Q==" });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "OrderId", "CustomerId", "PickupDate" },
                values: new object[] { 1, "00000000-ffff-ffff-ffff-ffffffffffff", new DateTime(2019, 6, 27, 10, 5, 48, 895, DateTimeKind.Local).AddTicks(768) });

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
                table: "Product",
                columns: new[] { "ProductId", "Image", "IsActive", "IsOrganic", "Name", "Price", "ProducerId", "ProductTypeId", "Quantity", "ShelfId" },
                values: new object[] { 4, null, true, true, "Lavender Soap", 3.9900000000000002, 2, 8, 12, 3 });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "Image", "IsActive", "IsOrganic", "Name", "Price", "ProducerId", "ProductTypeId", "Quantity", "ShelfId" },
                values: new object[] { 5, null, true, false, "Knit Scarf", 21.989999999999998, 2, 9, 1, 3 });

            migrationBuilder.AddForeignKey(
                name: "FK_Order_AspNetUsers_CustomerId",
                table: "Order",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProduct_Order_OrderId",
                table: "OrderProduct",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProduct_Product_ProductId",
                table: "OrderProduct",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Producer_ProducerId",
                table: "Product",
                column: "ProducerId",
                principalTable: "Producer",
                principalColumn: "ProducerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductType_ProductTypeId",
                table: "Product",
                column: "ProductTypeId",
                principalTable: "ProductType",
                principalColumn: "ProductTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Shelf_ShelfId",
                table: "Product",
                column: "ShelfId",
                principalTable: "Shelf",
                principalColumn: "ShelfId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
