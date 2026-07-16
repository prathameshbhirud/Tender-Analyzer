using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TenderAnalyzer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTenderPagesAndChunks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "Tenders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "FileSizeBytes",
                table: "Tenders",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "TenderChunks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TenderId = table.Column<Guid>(type: "uuid", nullable: false),
                    PageNumber = table.Column<int>(type: "integer", nullable: false),
                    ChunkText = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenderChunks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TenderChunks_Tenders_TenderId",
                        column: x => x.TenderId,
                        principalTable: "Tenders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TenderPages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TenderId = table.Column<Guid>(type: "uuid", nullable: false),
                    PageNumber = table.Column<int>(type: "integer", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenderPages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TenderPages_Tenders_TenderId",
                        column: x => x.TenderId,
                        principalTable: "Tenders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TenderChunks_TenderId",
                table: "TenderChunks",
                column: "TenderId");

            migrationBuilder.CreateIndex(
                name: "IX_TenderPages_TenderId",
                table: "TenderPages",
                column: "TenderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TenderChunks");

            migrationBuilder.DropTable(
                name: "TenderPages");

            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "Tenders");

            migrationBuilder.DropColumn(
                name: "FileSizeBytes",
                table: "Tenders");
        }
    }
}
