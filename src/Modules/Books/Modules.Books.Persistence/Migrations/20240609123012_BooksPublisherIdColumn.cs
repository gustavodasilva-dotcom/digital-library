using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Modules.Books.Persistence.Constants;

#nullable disable

namespace Modules.Books.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class BooksPublisherIdColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PublisherId",
                schema: "books",
                table: "Books",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublisherId",
                schema: "books",
                table: "Books",
                column: "PublisherId");

            migrationBuilder.Sql($@"
                CREATE TABLE #TempPublisherId (Id uniqueidentifier);

                INSERT INTO [books].[Publishers]
                OUTPUT INSERTED.Id INTO #TempPublisherId
                VALUES (NEWID(), N'{DatabaseConstants.DigitalLibraryPublisher}', GETDATE());

                DECLARE @PublisherId uniqueidentifier;
                SELECT @PublisherId = Id FROM #TempPublisherId;

                UPDATE [books].[Books] SET [PublisherId] = @PublisherId;

                DROP TABLE #TempPublisherId;");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Publishers_PublisherId",
                schema: "books",
                table: "Books",
                column: "PublisherId",
                principalSchema: "books",
                principalTable: "Publishers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Publishers_PublisherId",
                schema: "books",
                table: "Books");

            migrationBuilder.Sql($@"
                DELETE FROM [books].[Publishers]
                WHERE [Name] = N'{DatabaseConstants.DigitalLibraryPublisher}';");

            migrationBuilder.DropIndex(
                name: "IX_Books_PublisherId",
                schema: "books",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "PublisherId",
                schema: "books",
                table: "Books");
        }
    }
}
