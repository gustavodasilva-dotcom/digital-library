using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Modules.Lendings.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddingPatronIdColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PatronId",
                schema: "lendings",
                table: "Lends",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.Sql($@"UPDATE [lendings].[Lends] SET [PatronId] = '{Guid.Empty}';");

            migrationBuilder.AlterColumn<Guid>(
                name: "PatronId",
                schema: "lendings",
                table: "Lends",
                type: "uniqueidentifier",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_Lends_PatronId",
                schema: "lendings",
                table: "Lends",
                column: "PatronId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Lends_PatronId",
                schema: "lendings",
                table: "Lends");

            migrationBuilder.DropColumn(
                name: "PatronId",
                schema: "lendings",
                table: "Lends");
        }
    }
}
