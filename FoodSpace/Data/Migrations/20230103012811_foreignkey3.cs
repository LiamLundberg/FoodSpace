using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodSpace.Data.Migrations
{
    /// <inheritdoc />
    public partial class foreignkey3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Recipe_RecipeId",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "RecipeId",
                table: "Items",
                newName: "ItemFK");

            migrationBuilder.RenameIndex(
                name: "IX_Items_RecipeId",
                table: "Items",
                newName: "IX_Items_ItemFK");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Recipe_ItemFK",
                table: "Items",
                column: "ItemFK",
                principalTable: "Recipe",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Recipe_ItemFK",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "ItemFK",
                table: "Items",
                newName: "RecipeId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_ItemFK",
                table: "Items",
                newName: "IX_Items_RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Recipe_RecipeId",
                table: "Items",
                column: "RecipeId",
                principalTable: "Recipe",
                principalColumn: "Id");
        }
    }
}
