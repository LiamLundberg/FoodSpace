using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodSpace.Data.Migrations
{
    /// <inheritdoc />
    public partial class foreignkey2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_DynamicRecipes_RecipeId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeItems_DynamicRecipes_recipeId",
                table: "RecipeItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DynamicRecipes",
                table: "DynamicRecipes");

            migrationBuilder.RenameTable(
                name: "DynamicRecipes",
                newName: "Recipe");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recipe",
                table: "Recipe",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Recipe_RecipeId",
                table: "Items",
                column: "RecipeId",
                principalTable: "Recipe",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeItems_Recipe_recipeId",
                table: "RecipeItems",
                column: "recipeId",
                principalTable: "Recipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Recipe_RecipeId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeItems_Recipe_recipeId",
                table: "RecipeItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recipe",
                table: "Recipe");

            migrationBuilder.RenameTable(
                name: "Recipe",
                newName: "DynamicRecipes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DynamicRecipes",
                table: "DynamicRecipes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_DynamicRecipes_RecipeId",
                table: "Items",
                column: "RecipeId",
                principalTable: "DynamicRecipes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeItems_DynamicRecipes_recipeId",
                table: "RecipeItems",
                column: "recipeId",
                principalTable: "DynamicRecipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
