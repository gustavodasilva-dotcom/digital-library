using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Modules.Patrons.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PatronLendsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PatronLends",
                schema: "patrons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatronId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LendId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartLendDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndLendDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatronLends", x => x.Id);
                    table.CheckConstraint("CK_PatronLends_LendId_NotEmptyGuid", "LendId <> '00000000-0000-0000-0000-000000000000'");
                    table.ForeignKey(
                        name: "FK_PatronLends_Patrons_PatronId",
                        column: x => x.PatronId,
                        principalSchema: "patrons",
                        principalTable: "Patrons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatronLends_PatronId_LendId",
                schema: "patrons",
                table: "PatronLends",
                columns: new[] { "PatronId", "LendId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatronLends",
                schema: "patrons");
        }
    }
}
