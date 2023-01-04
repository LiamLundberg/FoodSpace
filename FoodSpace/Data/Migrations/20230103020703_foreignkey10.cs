using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodSpace.Data.Migrations
{
    /// <inheritdoc />
    public partial class foreignkey10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeRecipeItems_Recipe_recipesId",
                table: "RecipeRecipeItems");

            migrationBuilder.RenameColumn(
                name: "recipesId",
                table: "RecipeRecipeItems",
                newName: "RecipesId");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeRecipeItems_recipesId",
                table: "RecipeRecipeItems",
                newName: "IX_RecipeRecipeItems_RecipesId");

            migrationBuilder.AddColumn<int>(
                name: "ItemsId",
                table: "RecipeItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RecipeId",
                table: "RecipeItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeRecipeItems_Recipe_RecipesId",
                table: "RecipeRecipeItems",
                column: "RecipesId",
                principalTable: "Recipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeRecipeItems_Recipe_RecipesId",
                table: "RecipeRecipeItems");

            migrationBuilder.DropColumn(
                name: "ItemsId",
                table: "RecipeItems");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "RecipeItems");

            migrationBuilder.RenameColumn(
                name: "RecipesId",
                table: "RecipeRecipeItems",
                newName: "recipesId");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeRecipeItems_RecipesId",
                table: "RecipeRecipeItems",
                newName: "IX_RecipeRecipeItems_recipesId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeRecipeItems_Recipe_recipesId",
                table: "RecipeRecipeItems",
                column: "recipesId",
                principalTable: "Recipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
