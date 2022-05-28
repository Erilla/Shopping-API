using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingAPI.Business.Migrations
{
    public partial class CaseInsensitiveColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<string>(
                name: "ProductCode",
                table: "Products",
                type: "TEXT",
                maxLength: 10,
                nullable: false,
                collation: "NOCASE",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Customers",
                type: "TEXT",
                nullable: false,
                collation: "NOCASE",
                oldClrType: typeof(string),
                oldType: "TEXT");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<string>(
                name: "ProductCode",
                table: "Products",
                type: "TEXT",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 10,
                oldCollation: "NOCASE");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Customers",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldCollation: "NOCASE");

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
        }
    }
}
