using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VehicleQuotes.Migrations;

/// <inheritdoc />
public partial class AddSeedDataForSizes : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.InsertData(
            table: "sizes",
            columns: new[] { "id", "name" },
            values: new object[,]
            {
                { 1, "Subcompact" },
                { 2, "Compact" },
                { 3, "Mid Size" },
                { 4, "Full Size" }
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DeleteData(
            table: "sizes",
            keyColumn: "id",
            keyValue: 1);

        migrationBuilder.DeleteData(
            table: "sizes",
            keyColumn: "id",
            keyValue: 2);

        migrationBuilder.DeleteData(
            table: "sizes",
            keyColumn: "id",
            keyValue: 3);

        migrationBuilder.DeleteData(
            table: "sizes",
            keyColumn: "id",
            keyValue: 4);
    }
}
