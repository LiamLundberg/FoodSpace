using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodSpace.Data.Migrations
{
    /// <inheritdoc />
    public partial class foreignkey4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Recipe_ItemFK",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "ItemFK",
                table: "Items",
                newName: "ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_ItemFK",
                table: "Items",
                newName: "IX_Items_ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Recipe_ItemId",
                table: "Items",
                column: "ItemId",
                principalTable: "Recipe",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Recipe_ItemId",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "Items",
                newName: "ItemFK");

            migrationBuilder.RenameIndex(
                name: "IX_Items_ItemId",
                table: "Items",
                newName: "IX_Items_ItemFK");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Recipe_ItemFK",
                table: "Items",
                column: "ItemFK",
                principalTable: "Recipe",
                principalColumn: "Id");
        }
    }
}
