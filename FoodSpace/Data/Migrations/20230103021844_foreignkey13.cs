using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodSpace.Data.Migrations
{
    /// <inheritdoc />
    public partial class foreignkey13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemRecipeItems");

            migrationBuilder.DropTable(
                name: "RecipeRecipeItems");

            migrationBuilder.DropColumn(
                name: "RecipeItemId",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "RecipeItemId",
                table: "Items");

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "RecipeItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RecipeItems_ItemId",
                table: "RecipeItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeItems_RecipeId",
                table: "RecipeItems",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeItems_Items_ItemId",
                table: "RecipeItems",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeItems_Recipe_RecipeId",
                table: "RecipeItems",
                column: "RecipeId",
                principalTable: "Recipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeItems_Items_ItemId",
                table: "RecipeItems");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeItems_Recipe_RecipeId",
                table: "RecipeItems");

            migrationBuilder.DropIndex(
                name: "IX_RecipeItems_ItemId",
                table: "RecipeItems");

            migrationBuilder.DropIndex(
                name: "IX_RecipeItems_RecipeId",
                table: "RecipeItems");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "RecipeItems");

            migrationBuilder.AddColumn<int>(
                name: "RecipeItemId",
                table: "Recipe",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RecipeItemId",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ItemRecipeItems",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    RecipeItemsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemRecipeItems", x => new { x.ItemId, x.RecipeItemsId });
                    table.ForeignKey(
                        name: "FK_ItemRecipeItems_Items_ItemId",
                        column: x => x.ItemId,
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
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    RecipeItemsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeRecipeItems", x => new { x.RecipeId, x.RecipeItemsId });
                    table.ForeignKey(
                        name: "FK_RecipeRecipeItems_RecipeItems_RecipeItemsId",
                        column: x => x.RecipeItemsId,
                        principalTable: "RecipeItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeRecipeItems_Recipe_RecipeId",
                        column: x => x.RecipeId,
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
    }
}
