using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleQuotes.Migrations;

/// <inheritdoc />
public partial class AddUniqueIndexesForVehicleModelTables : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropIndex(
            name: "ix_modelstyles_modelid",
            table: "modelstyles");

        migrationBuilder.CreateIndex(
            name: "ix_modelstyleyears_year_modelstyleid",
            table: "modelstyleyears",
            columns: new[] { "year", "modelstyleid" },
            unique: true);

        migrationBuilder.CreateIndex(
            name: "ix_modelstyles_modelid_bodytypeid_sizeid",
            table: "modelstyles",
            columns: new[] { "modelid", "bodytypeid", "sizeid" },
            unique: true);

        migrationBuilder.CreateIndex(
            name: "ix_models_name_makeid",
            table: "models",
            columns: new[] { "name", "makeid" },
            unique: true);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropIndex(
            name: "ix_modelstyleyears_year_modelstyleid",
            table: "modelstyleyears");

        migrationBuilder.DropIndex(
            name: "ix_modelstyles_modelid_bodytypeid_sizeid",
            table: "modelstyles");

        migrationBuilder.DropIndex(
            name: "ix_models_name_makeid",
            table: "models");

        migrationBuilder.CreateIndex(
            name: "ix_modelstyles_modelid",
            table: "modelstyles",
            column: "modelid");
    }
}
