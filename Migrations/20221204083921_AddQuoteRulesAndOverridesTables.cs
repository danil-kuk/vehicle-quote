using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace VehicleQuotes.Migrations;

/// <inheritdoc />
public partial class AddQuoteRulesAndOverridesTables : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "quoteoverrides",
            columns: table => new
            {
                id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                modelstyleyearid = table.Column<int>(type: "integer", nullable: false),
                price = table.Column<int>(type: "integer", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_quoteoverrides", x => x.id);
                table.ForeignKey(
                    name: "fk_quoteoverrides_modelstyleyears_modelstyleyearid",
                    column: x => x.modelstyleyearid,
                    principalTable: "modelstyleyears",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "quoterules",
            columns: table => new
            {
                id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                featuretype = table.Column<string>(type: "text", nullable: false),
                featurevalue = table.Column<string>(type: "text", nullable: false),
                pricemodifier = table.Column<int>(type: "integer", nullable: false)
            },
            constraints: table => table.PrimaryKey("pk_quoterules", x => x.id));

        migrationBuilder.CreateIndex(
            name: "ix_quoteoverrides_modelstyleyearid",
            table: "quoteoverrides",
            column: "modelstyleyearid",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "ix_quoterules_featuretype_featurevalue",
            table: "quoterules",
            columns: new[] { "featuretype", "featurevalue" },
            unique: true);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "quoteoverrides");

        migrationBuilder.DropTable(
            name: "quoterules");
    }
}
