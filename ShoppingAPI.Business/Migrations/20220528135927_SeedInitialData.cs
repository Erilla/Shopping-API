using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingAPI.Business.Migrations
{
    public partial class SeedInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "John" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Mary" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Lucas" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ProductCode", "ProductPrice" },
                values: new object[] { 1, "EAN1", 99.95m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ProductCode", "ProductPrice" },
                values: new object[] { 2, "EAN2", 16.15m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ProductCode", "ProductPrice" },
                values: new object[] { 3, "EAN3", 12m });

            migrationBuilder.InsertData(
                table: "SpecificPrices",
                columns: new[] { "Id", "CustomerId", "Price", "ProductId" },
                values: new object[] { 1, 1, 95.99m, 1 });

            migrationBuilder.InsertData(
                table: "SpecificPrices",
                columns: new[] { "Id", "CustomerId", "Price", "ProductId" },
                values: new object[] { 2, 1, 16.15m, 2 });

            migrationBuilder.InsertData(
                table: "SpecificPrices",
                columns: new[] { "Id", "CustomerId", "Price", "ProductId" },
                values: new object[] { 3, 2, 16.05m, 2 });

            migrationBuilder.InsertData(
                table: "SpecificPrices",
                columns: new[] { "Id", "CustomerId", "Price", "ProductId" },
                values: new object[] { 4, 2, 9.99m, 3 });

            migrationBuilder.InsertData(
                table: "SpecificPrices",
                columns: new[] { "Id", "CustomerId", "Price", "ProductId" },
                values: new object[] { 5, 3, 14m, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SpecificPrices",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SpecificPrices",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SpecificPrices",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SpecificPrices",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SpecificPrices",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
