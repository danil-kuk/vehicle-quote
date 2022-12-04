using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace VehicleQuotes.Migrations;

/// <inheritdoc />
public partial class AddQuotesTable : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "quotes",
            columns: table => new
            {
                id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                modelstyleyearid = table.Column<int>(type: "integer", nullable: true),
                year = table.Column<string>(type: "text", nullable: false),
                make = table.Column<string>(type: "text", nullable: false),
                model = table.Column<string>(type: "text", nullable: false),
                bodytypeid = table.Column<int>(type: "integer", nullable: false),
                sizeid = table.Column<int>(type: "integer", nullable: false),
                itmoves = table.Column<bool>(type: "boolean", nullable: false),
                hasallwheels = table.Column<bool>(type: "boolean", nullable: false),
                hasalloywheels = table.Column<bool>(type: "boolean", nullable: false),
                hasalltires = table.Column<bool>(type: "boolean", nullable: false),
                haskey = table.Column<bool>(type: "boolean", nullable: false),
                hastitle = table.Column<bool>(type: "boolean", nullable: false),
                requirespickup = table.Column<bool>(type: "boolean", nullable: false),
                hasengine = table.Column<bool>(type: "boolean", nullable: false),
                hastransmission = table.Column<bool>(type: "boolean", nullable: false),
                hascompleteinterior = table.Column<bool>(type: "boolean", nullable: false),
                offeredquote = table.Column<int>(type: "integer", nullable: false),
                message = table.Column<string>(type: "text", nullable: false),
                createdat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_quotes", x => x.id);
                table.ForeignKey(
                    name: "fk_quotes_bodytypes_bodytypeid",
                    column: x => x.bodytypeid,
                    principalTable: "bodytypes",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "fk_quotes_modelstyleyears_modelstyleyearid",
                    column: x => x.modelstyleyearid,
                    principalTable: "modelstyleyears",
                    principalColumn: "id");
                table.ForeignKey(
                    name: "fk_quotes_sizes_sizeid",
                    column: x => x.sizeid,
                    principalTable: "sizes",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "ix_quotes_bodytypeid",
            table: "quotes",
            column: "bodytypeid");

        migrationBuilder.CreateIndex(
            name: "ix_quotes_modelstyleyearid",
            table: "quotes",
            column: "modelstyleyearid");

        migrationBuilder.CreateIndex(
            name: "ix_quotes_sizeid",
            table: "quotes",
            column: "sizeid");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "quotes");
    }
}
