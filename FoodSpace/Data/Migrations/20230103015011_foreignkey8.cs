using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodSpace.Data.Migrations
{
    /// <inheritdoc />
    public partial class foreignkey8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Recipe_RecipeId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeItems_Items_ItemId",
                table: "RecipeItems");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeItems_Recipe_recipeId",
                table: "RecipeItems");

            migrationBuilder.DropIndex(
                name: "IX_RecipeItems_ItemId",
                table: "RecipeItems");

            migrationBuilder.DropIndex(
                name: "IX_RecipeItems_recipeId",
                table: "RecipeItems");

            migrationBuilder.DropIndex(
                name: "IX_Items_RecipeId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "RecipeItems");

            migrationBuilder.DropColumn(
                name: "recipeId",
                table: "RecipeItems");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "Items");

            migrationBuilder.CreateTable(
                name: "ItemRecipeItems",
                columns: table => new
                {
                    Item = table.Column<int>(type: "int", nullable: false),
                    RecipeItemsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemRecipeItems", x => new { x.Item, x.RecipeItemsId });
                    table.ForeignKey(
                        name: "FK_ItemRecipeItems_Items_Item",
                        column: x => x.Item,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemRecipeItems_RecipeItems_RecipeItemsId",
                        column: x => x.RecipeItemsId,
                        principalTable: "RecipeItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeRecipeItems",
                columns: table => new
                {
                    Recipe = table.Column<int>(type: "int", nullable: false),
                    RecipeItemsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeRecipeItems", x => new { x.Recipe, x.RecipeItemsId });
                    table.ForeignKey(
                        name: "FK_RecipeRecipeItems_RecipeItems_RecipeItemsId",
                        column: x => x.RecipeItemsId,
                        principalTable: "RecipeItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeRecipeItems_Recipe_Recipe",
                        column: x => x.Recipe,
                        principalTable: "Recipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemRecipeItems_RecipeItemsId",
                table: "ItemRecipeItems",
                column: "RecipeItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeRecipeItems_RecipeItemsId",
                table: "RecipeRecipeItems",
                column: "RecipeItemsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemRecipeItems");

            migrationBuilder.DropTable(
                name: "RecipeRecipeItems");

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "RecipeItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "recipeId",
                table: "RecipeItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RecipeId",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RecipeItems_ItemId",
                table: "RecipeItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeItems_recipeId",
                table: "RecipeItems",
                column: "recipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_RecipeId",
                table: "Items",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Recipe_RecipeId",
                table: "Items",
                column: "RecipeId",
                principalTable: "Recipe",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeItems_Items_ItemId",
                table: "RecipeItems",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeItems_Recipe_recipeId",
                table: "RecipeItems",
                column: "recipeId",
                principalTable: "Recipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
