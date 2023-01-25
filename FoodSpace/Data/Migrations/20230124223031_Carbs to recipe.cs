using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodSpace.Data.Migrations
{
    /// <inheritdoc />
    public partial class Carbstorecipe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Method_Recipe_RecipeId",
                table: "Method");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Method",
                table: "Method");

            migrationBuilder.RenameTable(
                name: "Method",
                newName: "Step");

            migrationBuilder.RenameIndex(
                name: "IX_Method_RecipeId",
                table: "Step",
                newName: "IX_Step_RecipeId");

            migrationBuilder.AddColumn<float>(
                name: "Carbohydrates",
                table: "Recipe",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Step",
                table: "Step",
                column: "StepId");

            migrationBuilder.AddForeignKey(
                name: "FK_Step_Recipe_RecipeId",
                table: "Step",
                column: "RecipeId",
                principalTable: "Recipe",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Step_Recipe_RecipeId",
                table: "Step");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Step",
                table: "Step");

            migrationBuilder.DropColumn(
                name: "Carbohydrates",
                table: "Recipe");

            migrationBuilder.RenameTable(
                name: "Step",
                newName: "Method");

            migrationBuilder.RenameIndex(
                name: "IX_Step_RecipeId",
                table: "Method",
                newName: "IX_Method_RecipeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Method",
                table: "Method",
                column: "StepId");

            migrationBuilder.AddForeignKey(
                name: "FK_Method_Recipe_RecipeId",
                table: "Method",
                column: "RecipeId",
                principalTable: "Recipe",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
