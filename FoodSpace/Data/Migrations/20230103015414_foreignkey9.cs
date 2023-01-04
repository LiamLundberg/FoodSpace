using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodSpace.Data.Migrations
{
    /// <inheritdoc />
    public partial class foreignkey9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemRecipeItems_Items_Item",
                table: "ItemRecipeItems");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeRecipeItems_Recipe_Recipe",
                table: "RecipeRecipeItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeRecipeItems",
                table: "RecipeRecipeItems");

            migrationBuilder.DropIndex(
                name: "IX_RecipeRecipeItems_RecipeItemsId",
                table: "RecipeRecipeItems");

            migrationBuilder.RenameColumn(
                name: "Recipe",
                table: "RecipeRecipeItems",
                newName: "recipesId");

            migrationBuilder.RenameColumn(
                name: "Item",
                table: "ItemRecipeItems",
                newName: "ItemsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeRecipeItems",
                table: "RecipeRecipeItems",
                columns: new[] { "RecipeItemsId", "recipesId" });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeRecipeItems_recipesId",
                table: "RecipeRecipeItems",
                column: "recipesId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemRecipeItems_Items_ItemsId",
                table: "ItemRecipeItems",
                column: "ItemsId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeRecipeItems_Recipe_recipesId",
                table: "RecipeRecipeItems",
                column: "recipesId",
                principalTable: "Recipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemRecipeItems_Items_ItemsId",
                table: "ItemRecipeItems");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeRecipeItems_Recipe_recipesId",
                table: "RecipeRecipeItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeRecipeItems",
                table: "RecipeRecipeItems");

            migrationBuilder.DropIndex(
                name: "IX_RecipeRecipeItems_recipesId",
                table: "RecipeRecipeItems");

            migrationBuilder.RenameColumn(
                name: "recipesId",
                table: "RecipeRecipeItems",
                newName: "Recipe");

            migrationBuilder.RenameColumn(
                name: "ItemsId",
                table: "ItemRecipeItems",
                newName: "Item");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeRecipeItems",
                table: "RecipeRecipeItems",
                columns: new[] { "Recipe", "RecipeItemsId" });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeRecipeItems_RecipeItemsId",
                table: "RecipeRecipeItems",
                column: "RecipeItemsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemRecipeItems_Items_Item",
                table: "ItemRecipeItems",
                column: "Item",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeRecipeItems_Recipe_Recipe",
                table: "RecipeRecipeItems",
                column: "Recipe",
                principalTable: "Recipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
