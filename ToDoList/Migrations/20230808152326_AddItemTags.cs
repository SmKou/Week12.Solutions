using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.Migrations
{
    /// <inheritdoc />
    public partial class AddItemTags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemTag_Items_ItemId",
                table: "ItemTag");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemTag_Tag_TagId",
                table: "ItemTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tag",
                table: "Tag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemTag",
                table: "ItemTag");

            migrationBuilder.RenameTable(
                name: "Tag",
                newName: "Tags");

            migrationBuilder.RenameTable(
                name: "ItemTag",
                newName: "ItemTags");

            migrationBuilder.RenameIndex(
                name: "IX_ItemTag_TagId",
                table: "ItemTags",
                newName: "IX_ItemTags_TagId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemTag_ItemId",
                table: "ItemTags",
                newName: "IX_ItemTags_ItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tags",
                table: "Tags",
                column: "TagId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemTags",
                table: "ItemTags",
                column: "ItemTagId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemTags_Items_ItemId",
                table: "ItemTags",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemTags_Tags_TagId",
                table: "ItemTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "TagId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemTags_Items_ItemId",
                table: "ItemTags");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemTags_Tags_TagId",
                table: "ItemTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tags",
                table: "Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemTags",
                table: "ItemTags");

            migrationBuilder.RenameTable(
                name: "Tags",
                newName: "Tag");

            migrationBuilder.RenameTable(
                name: "ItemTags",
                newName: "ItemTag");

            migrationBuilder.RenameIndex(
                name: "IX_ItemTags_TagId",
                table: "ItemTag",
                newName: "IX_ItemTag_TagId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemTags_ItemId",
                table: "ItemTag",
                newName: "IX_ItemTag_ItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tag",
                table: "Tag",
                column: "TagId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemTag",
                table: "ItemTag",
                column: "ItemTagId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemTag_Items_ItemId",
                table: "ItemTag",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemTag_Tag_TagId",
                table: "ItemTag",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "TagId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
