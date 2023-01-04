using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodSpace.Data.Migrations
{
    /// <inheritdoc />
    public partial class foreignkey28 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemRecipe_Item_ItemsItemId",
                table: "ItemRecipe");

            migrationBuilder.RenameColumn(
                name: "ItemsItemId",
                table: "ItemRecipe",
                newName: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemRecipe_Item_ItemId",
                table: "ItemRecipe",
                column: "ItemId",
                principalTable: "Item",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemRecipe_Item_ItemId",
                table: "ItemRecipe");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "ItemRecipe",
                newName: "ItemsItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemRecipe_Item_ItemsItemId",
                table: "ItemRecipe",
                column: "ItemsItemId",
                principalTable: "Item",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
