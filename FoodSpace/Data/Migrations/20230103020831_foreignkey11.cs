using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodSpace.Data.Migrations
{
    /// <inheritdoc />
    public partial class foreignkey11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemRecipeItems_Items_ItemsId",
                table: "ItemRecipeItems");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeRecipeItems_Recipe_RecipesId",
                table: "RecipeRecipeItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeRecipeItems",
                table: "RecipeRecipeItems");

            migrationBuilder.DropIndex(
                name: "IX_RecipeRecipeItems_RecipesId",
                table: "RecipeRecipeItems");

            migrationBuilder.RenameColumn(
                name: "RecipesId",
                table: "RecipeRecipeItems",
                newName: "RecipeId");

            migrationBuilder.RenameColumn(
                name: "ItemsId",
                table: "ItemRecipeItems",
                newName: "ItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeRecipeItems",
                table: "RecipeRecipeItems",
                columns: new[] { "RecipeId", "RecipeItemsId" });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeRecipeItems_RecipeItemsId",
                table: "RecipeRecipeItems",
                column: "RecipeItemsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemRecipeItems_Items_ItemId",
                table: "ItemRecipeItems",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeRecipeItems_Recipe_RecipeId",
                table: "RecipeRecipeItems",
                column: "RecipeId",
                principalTable: "Recipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemRecipeItems_Items_ItemId",
                table: "ItemRecipeItems");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeRecipeItems_Recipe_RecipeId",
                table: "RecipeRecipeItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeRecipeItems",
                table: "RecipeRecipeItems");

            migrationBuilder.DropIndex(
                name: "IX_RecipeRecipeItems_RecipeItemsId",
                table: "RecipeRecipeItems");

            migrationBuilder.RenameColumn(
                name: "RecipeId",
                table: "RecipeRecipeItems",
                newName: "RecipesId");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "ItemRecipeItems",
                newName: "ItemsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeRecipeItems",
                table: "RecipeRecipeItems",
                columns: new[] { "RecipeItemsId", "RecipesId" });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeRecipeItems_RecipesId",
                table: "RecipeRecipeItems",
                column: "RecipesId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemRecipeItems_Items_ItemsId",
                table: "ItemRecipeItems",
                column: "ItemsId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeRecipeItems_Recipe_RecipesId",
                table: "RecipeRecipeItems",
                column: "RecipesId",
                principalTable: "Recipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
