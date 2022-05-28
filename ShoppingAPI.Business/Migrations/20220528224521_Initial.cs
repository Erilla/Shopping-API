using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingAPI.Business.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false, collation: "NOCASE")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductCode = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false, collation: "NOCASE"),
                    ProductPrice = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpecificPrices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecificPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecificPrices_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpecificPrices_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_SpecificPrices_CustomerId",
                table: "SpecificPrices",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecificPrices_ProductId",
                table: "SpecificPrices",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpecificPrices");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
