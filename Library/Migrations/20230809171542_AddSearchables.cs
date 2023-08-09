using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Migrations
{
    /// <inheritdoc />
    public partial class AddSearchables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SerialName",
                table: "BookSeries",
                newName: "Searchable");

            migrationBuilder.RenameColumn(
                name: "BookName",
                table: "Books",
                newName: "Searchable");

            migrationBuilder.AddColumn<string>(
                name: "Searchable",
                table: "SerialTitles",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Searchable",
                table: "Publishers",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Searchable",
                table: "Persons",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Searchable",
                table: "Patrons",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Searchable",
                table: "Languages",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Searchable",
                table: "Formats",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Searchable",
                table: "Contributors",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Searchable",
                table: "Categories",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Searchable",
                table: "BookTitles",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Searchable",
                table: "Authors",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Searchable",
                table: "SerialTitles");

            migrationBuilder.DropColumn(
                name: "Searchable",
                table: "Publishers");

            migrationBuilder.DropColumn(
                name: "Searchable",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Searchable",
                table: "Patrons");

            migrationBuilder.DropColumn(
                name: "Searchable",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "Searchable",
                table: "Formats");

            migrationBuilder.DropColumn(
                name: "Searchable",
                table: "Contributors");

            migrationBuilder.DropColumn(
                name: "Searchable",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Searchable",
                table: "BookTitles");

            migrationBuilder.DropColumn(
                name: "Searchable",
                table: "Authors");

            migrationBuilder.RenameColumn(
                name: "Searchable",
                table: "BookSeries",
                newName: "SerialName");

            migrationBuilder.RenameColumn(
                name: "Searchable",
                table: "Books",
                newName: "BookName");
        }
    }
}
