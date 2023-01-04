using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodSpace.Data.Migrations
{
    /// <inheritdoc />
    public partial class foreignkey39 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemRecipe",
                table: "ItemRecipe");

            migrationBuilder.AddColumn<int>(
                name: "ItemRecipeId",
                table: "ItemRecipe",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemRecipe",
                table: "ItemRecipe",
                column: "ItemRecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemRecipe_RecipeId",
                table: "ItemRecipe",
                column: "RecipeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemRecipe",
                table: "ItemRecipe");

            migrationBuilder.DropIndex(
                name: "IX_ItemRecipe_RecipeId",
                table: "ItemRecipe");

            migrationBuilder.DropColumn(
                name: "ItemRecipeId",
                table: "ItemRecipe");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemRecipe",
                table: "ItemRecipe",
                columns: new[] { "RecipeId", "ItemId" });
        }
    }
}
