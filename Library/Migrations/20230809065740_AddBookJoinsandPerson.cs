using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Migrations
{
    /// <inheritdoc />
    public partial class AddBookJoinsandPerson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookVersions_Publisher_PublisherId",
                table: "BookVersions");

            migrationBuilder.DropForeignKey(
                name: "FK_Recommendations_BookVersions_BookVersionId",
                table: "Recommendations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Publisher",
                table: "Publisher");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "BookVersions");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "Publisher",
                newName: "Publishers");

            migrationBuilder.RenameColumn(
                name: "BookVersionId",
                table: "Recommendations",
                newName: "BookSerialId");

            migrationBuilder.RenameIndex(
                name: "IX_Recommendations_BookVersionId",
                table: "Recommendations",
                newName: "IX_Recommendations_BookSerialId");

            migrationBuilder.AddColumn<int>(
                name: "FormatId",
                table: "WaitLists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "SeenByUser",
                table: "UserNotifications",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "Recommendations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "RecommendationForBook",
                table: "Recommendations",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Item",
                table: "Notifications",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "Notifications",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "NumRenewals",
                table: "Checkouts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "BookName",
                table: "Books",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "BookSerialId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumInSeries",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Deceased",
                table: "Authors",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PenName",
                table: "Authors",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Authors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Publishers",
                table: "Publishers",
                column: "PublisherId");

            migrationBuilder.CreateTable(
                name: "BookSeries",
                columns: table => new
                {
                    BookSerialId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SerialName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsFinished = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookSeries", x => x.BookSerialId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BookTitles",
                columns: table => new
                {
                    BookTitleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookTitles", x => x.BookTitleId);
                    table.ForeignKey(
                        name: "FK_BookTitles_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookTitles_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "LanguageId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Contributors",
                columns: table => new
                {
                    ContributorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contributors", x => x.ContributorId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PatronAuthors",
                columns: table => new
                {
                    PatronAuthorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    WatchReleases = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PatronId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatronAuthors", x => x.PatronAuthorId);
                    table.ForeignKey(
                        name: "FK_PatronAuthors_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatronAuthors_Patrons_PatronId",
                        column: x => x.PatronId,
                        principalTable: "Patrons",
                        principalColumn: "PatronId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateOfBirth = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CountryOfOrigin = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SerialTitles",
                columns: table => new
                {
                    SerialTitleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BookSerialId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SerialTitles", x => x.SerialTitleId);
                    table.ForeignKey(
                        name: "FK_SerialTitles_BookSeries_BookSerialId",
                        column: x => x.BookSerialId,
                        principalTable: "BookSeries",
                        principalColumn: "BookSerialId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SerialTitles_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "LanguageId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BookContributors",
                columns: table => new
                {
                    BookContributorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Role = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BookVersionId = table.Column<int>(type: "int", nullable: false),
                    ContributorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookContributors", x => x.BookContributorId);
                    table.ForeignKey(
                        name: "FK_BookContributors_BookVersions_BookVersionId",
                        column: x => x.BookVersionId,
                        principalTable: "BookVersions",
                        principalColumn: "BookVersionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookContributors_Contributors_ContributorId",
                        column: x => x.ContributorId,
                        principalTable: "Contributors",
                        principalColumn: "ContributorId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_WaitLists_FormatId",
                table: "WaitLists",
                column: "FormatId");

            migrationBuilder.CreateIndex(
                name: "IX_Recommendations_BookId",
                table: "Recommendations",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookSerialId",
                table: "Books",
                column: "BookSerialId");

            migrationBuilder.CreateIndex(
                name: "IX_Authors_PersonId",
                table: "Authors",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_BookContributors_BookVersionId",
                table: "BookContributors",
                column: "BookVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_BookContributors_ContributorId",
                table: "BookContributors",
                column: "ContributorId");

            migrationBuilder.CreateIndex(
                name: "IX_BookTitles_BookId",
                table: "BookTitles",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookTitles_LanguageId",
                table: "BookTitles",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_PatronAuthors_AuthorId",
                table: "PatronAuthors",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_PatronAuthors_PatronId",
                table: "PatronAuthors",
                column: "PatronId");

            migrationBuilder.CreateIndex(
                name: "IX_SerialTitles_BookSerialId",
                table: "SerialTitles",
                column: "BookSerialId");

            migrationBuilder.CreateIndex(
                name: "IX_SerialTitles_LanguageId",
                table: "SerialTitles",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_Persons_PersonId",
                table: "Authors",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookSeries_BookSerialId",
                table: "Books",
                column: "BookSerialId",
                principalTable: "BookSeries",
                principalColumn: "BookSerialId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookVersions_Publishers_PublisherId",
                table: "BookVersions",
                column: "PublisherId",
                principalTable: "Publishers",
                principalColumn: "PublisherId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recommendations_BookSeries_BookSerialId",
                table: "Recommendations",
                column: "BookSerialId",
                principalTable: "BookSeries",
                principalColumn: "BookSerialId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recommendations_Books_BookId",
                table: "Recommendations",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WaitLists_Formats_FormatId",
                table: "WaitLists",
                column: "FormatId",
                principalTable: "Formats",
                principalColumn: "FormatId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_Persons_PersonId",
                table: "Authors");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookSeries_BookSerialId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_BookVersions_Publishers_PublisherId",
                table: "BookVersions");

            migrationBuilder.DropForeignKey(
                name: "FK_Recommendations_BookSeries_BookSerialId",
                table: "Recommendations");

            migrationBuilder.DropForeignKey(
                name: "FK_Recommendations_Books_BookId",
                table: "Recommendations");

            migrationBuilder.DropForeignKey(
                name: "FK_WaitLists_Formats_FormatId",
                table: "WaitLists");

            migrationBuilder.DropTable(
                name: "BookContributors");

            migrationBuilder.DropTable(
                name: "BookTitles");

            migrationBuilder.DropTable(
                name: "PatronAuthors");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "SerialTitles");

            migrationBuilder.DropTable(
                name: "Contributors");

            migrationBuilder.DropTable(
                name: "BookSeries");

            migrationBuilder.DropIndex(
                name: "IX_WaitLists_FormatId",
                table: "WaitLists");

            migrationBuilder.DropIndex(
                name: "IX_Recommendations_BookId",
                table: "Recommendations");

            migrationBuilder.DropIndex(
                name: "IX_Books_BookSerialId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Authors_PersonId",
                table: "Authors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Publishers",
                table: "Publishers");

            migrationBuilder.DropColumn(
                name: "FormatId",
                table: "WaitLists");

            migrationBuilder.DropColumn(
                name: "SeenByUser",
                table: "UserNotifications");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Recommendations");

            migrationBuilder.DropColumn(
                name: "RecommendationForBook",
                table: "Recommendations");

            migrationBuilder.DropColumn(
                name: "Item",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "Message",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "NumRenewals",
                table: "Checkouts");

            migrationBuilder.DropColumn(
                name: "BookName",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "BookSerialId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "NumInSeries",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Deceased",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "PenName",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "Publishers",
                newName: "Publisher");

            migrationBuilder.RenameColumn(
                name: "BookSerialId",
                table: "Recommendations",
                newName: "BookVersionId");

            migrationBuilder.RenameIndex(
                name: "IX_Recommendations_BookSerialId",
                table: "Recommendations",
                newName: "IX_Recommendations_BookVersionId");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "BookVersions",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "AspNetUsers",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Publisher",
                table: "Publisher",
                column: "PublisherId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookVersions_Publisher_PublisherId",
                table: "BookVersions",
                column: "PublisherId",
                principalTable: "Publisher",
                principalColumn: "PublisherId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recommendations_BookVersions_BookVersionId",
                table: "Recommendations",
                column: "BookVersionId",
                principalTable: "BookVersions",
                principalColumn: "BookVersionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
