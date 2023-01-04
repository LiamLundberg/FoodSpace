using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodSpace.Data.Migrations
{
    /// <inheritdoc />
    public partial class foreignkey31 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemRecipe",
                table: "ItemRecipe");

            migrationBuilder.AlterColumn<int>(
                name: "RecipeId",
                table: "ItemRecipe",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "ItemRecipe",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 1);

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
                name: "IX_ItemRecipe_ItemId",
                table: "ItemRecipe",
                column: "ItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemRecipe",
                table: "ItemRecipe");

            migrationBuilder.DropIndex(
                name: "IX_ItemRecipe_ItemId",
                table: "ItemRecipe");

            migrationBuilder.DropColumn(
                name: "ItemRecipeId",
                table: "ItemRecipe");

            migrationBuilder.AlterColumn<int>(
                name: "RecipeId",
                table: "ItemRecipe",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "ItemRecipe",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemRecipe",
                table: "ItemRecipe",
                columns: new[] { "ItemId", "RecipeId" });
        }
    }
}
