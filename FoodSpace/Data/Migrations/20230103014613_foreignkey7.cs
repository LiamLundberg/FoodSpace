using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodSpace.Data.Migrations
{
    /// <inheritdoc />
    public partial class foreignkey7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Recipe_ItemsFK",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "ItemsFK",
                table: "Items",
                newName: "RecipeId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_ItemsFK",
                table: "Items",
                newName: "IX_Items_RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Recipe_RecipeId",
                table: "Items",
                column: "RecipeId",
                principalTable: "Recipe",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Recipe_RecipeId",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "RecipeId",
                table: "Items",
                newName: "ItemsFK");

            migrationBuilder.RenameIndex(
                name: "IX_Items_RecipeId",
                table: "Items",
                newName: "IX_Items_ItemsFK");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Recipe_ItemsFK",
                table: "Items",
                column: "ItemsFK",
                principalTable: "Recipe",
                principalColumn: "Id");
        }
    }
}
