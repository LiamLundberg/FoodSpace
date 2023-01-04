using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodSpace.Data.Migrations
{
    /// <inheritdoc />
    public partial class updaterecipewithitemlist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AllerginLactose",
                table: "DynamicRecipes");

            migrationBuilder.DropColumn(
                name: "AllerginNuts",
                table: "DynamicRecipes");

            migrationBuilder.DropColumn(
                name: "AllerginSoy",
                table: "DynamicRecipes");

            migrationBuilder.DropColumn(
                name: "Carbohydrates",
                table: "DynamicRecipes");

            migrationBuilder.DropColumn(
                name: "DietaryFibre",
                table: "DynamicRecipes");

            migrationBuilder.DropColumn(
                name: "Energy",
                table: "DynamicRecipes");

            migrationBuilder.DropColumn(
                name: "Fat",
                table: "DynamicRecipes");

            migrationBuilder.DropColumn(
                name: "ItemsListID",
                table: "DynamicRecipes");

            migrationBuilder.DropColumn(
                name: "Protein",
                table: "DynamicRecipes");

            migrationBuilder.AddColumn<int>(
                name: "RecipeId",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_RecipeId",
                table: "Items",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_DynamicRecipes_RecipeId",
                table: "Items",
                column: "RecipeId",
                principalTable: "DynamicRecipes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_DynamicRecipes_RecipeId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_RecipeId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "Items");

            migrationBuilder.AddColumn<bool>(
                name: "AllerginLactose",
                table: "DynamicRecipes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AllerginNuts",
                table: "DynamicRecipes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AllerginSoy",
                table: "DynamicRecipes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<float>(
                name: "Carbohydrates",
                table: "DynamicRecipes",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "DietaryFibre",
                table: "DynamicRecipes",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "Energy",
                table: "DynamicRecipes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "Fat",
                table: "DynamicRecipes",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "ItemsListID",
                table: "DynamicRecipes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "Protein",
                table: "DynamicRecipes",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
