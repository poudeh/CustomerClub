using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Club.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class editEconomicalCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customers_EconomicCode",
                table: "Customers");

            migrationBuilder.AlterColumn<string>(
                name: "EconomicCode",
                table: "Customers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EconomicCode",
                table: "Customers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_EconomicCode",
                table: "Customers",
                column: "EconomicCode",
                unique: true,
                filter: "[EconomicCode] IS NOT NULL");
        }
    }
}
