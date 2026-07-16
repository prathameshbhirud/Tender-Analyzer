using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TenderAnalyzer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddProcessingMetadata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProcessingError",
                table: "Tenders",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalChunks",
                table: "Tenders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalPages",
                table: "Tenders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ChunkIndex",
                table: "TenderChunks",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAtUtc",
                table: "TenderChunks",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProcessingError",
                table: "Tenders");

            migrationBuilder.DropColumn(
                name: "TotalChunks",
                table: "Tenders");

            migrationBuilder.DropColumn(
                name: "TotalPages",
                table: "Tenders");

            migrationBuilder.DropColumn(
                name: "ChunkIndex",
                table: "TenderChunks");

            migrationBuilder.DropColumn(
                name: "CreatedAtUtc",
                table: "TenderChunks");
        }
    }
}
