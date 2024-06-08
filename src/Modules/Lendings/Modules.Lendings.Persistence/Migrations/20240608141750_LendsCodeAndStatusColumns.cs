using System;
using DigitalLibrary.Modules.Lendings.Domain.Enumerations;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Modules.Lendings.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class LendsCodeAndStatusColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CancelledDate",
                schema: "lendings",
                table: "Lends",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                schema: "lendings",
                table: "Lends",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ConcludedDate",
                schema: "lendings",
                table: "Lends",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                schema: "lendings",
                table: "Lends",
                type: "int",
                nullable: false,
                defaultValue: LendStatuses.Open);

            migrationBuilder.CreateIndex(
                name: "IX_Lends_Code",
                schema: "lendings",
                table: "Lends",
                column: "Code",
                unique: true);

            migrationBuilder.AddCheckConstraint(
                name: "CK_Lends_Status_Enum",
                schema: "lendings",
                table: "Lends",
                sql: "[Status] BETWEEN 1 AND 5");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Lends_Code",
                schema: "lendings",
                table: "Lends");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Lends_Status_Enum",
                schema: "lendings",
                table: "Lends");

            migrationBuilder.DropColumn(
                name: "CancelledDate",
                schema: "lendings",
                table: "Lends");

            migrationBuilder.DropColumn(
                name: "Code",
                schema: "lendings",
                table: "Lends");

            migrationBuilder.DropColumn(
                name: "ConcludedDate",
                schema: "lendings",
                table: "Lends");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "lendings",
                table: "Lends");
        }
    }
}
