using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace VehicleQuotes.Migrations;

/// <inheritdoc />
public partial class AddVehicleModelTables : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "models",
            columns: table => new
            {
                id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                name = table.Column<string>(type: "text", nullable: false),
                makeid = table.Column<int>(type: "integer", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_models", x => x.id);
                table.ForeignKey(
                    name: "fk_models_makes_makeid",
                    column: x => x.makeid,
                    principalTable: "makes",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "modelstyles",
            columns: table => new
            {
                id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                modelid = table.Column<int>(type: "integer", nullable: false),
                bodytypeid = table.Column<int>(type: "integer", nullable: false),
                sizeid = table.Column<int>(type: "integer", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_modelstyles", x => x.id);
                table.ForeignKey(
                    name: "fk_modelstyles_bodytypes_bodytypeid",
                    column: x => x.bodytypeid,
                    principalTable: "bodytypes",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "fk_modelstyles_models_modelid",
                    column: x => x.modelid,
                    principalTable: "models",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "fk_modelstyles_sizes_sizeid",
                    column: x => x.sizeid,
                    principalTable: "sizes",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "modelstyleyears",
            columns: table => new
            {
                id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                year = table.Column<string>(type: "text", nullable: false),
                modelstyleid = table.Column<int>(type: "integer", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_modelstyleyears", x => x.id);
                table.ForeignKey(
                    name: "fk_modelstyleyears_modelstyles_modelstyleid",
                    column: x => x.modelstyleid,
                    principalTable: "modelstyles",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "ix_models_makeid",
            table: "models",
            column: "makeid");

        migrationBuilder.CreateIndex(
            name: "ix_modelstyles_bodytypeid",
            table: "modelstyles",
            column: "bodytypeid");

        migrationBuilder.CreateIndex(
            name: "ix_modelstyles_modelid",
            table: "modelstyles",
            column: "modelid");

        migrationBuilder.CreateIndex(
            name: "ix_modelstyles_sizeid",
            table: "modelstyles",
            column: "sizeid");

        migrationBuilder.CreateIndex(
            name: "ix_modelstyleyears_modelstyleid",
            table: "modelstyleyears",
            column: "modelstyleid");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "modelstyleyears");

        migrationBuilder.DropTable(
            name: "modelstyles");

        migrationBuilder.DropTable(
            name: "models");
    }
}
