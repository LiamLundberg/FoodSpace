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
            migrationBuilder.Sql("ALTER TABLE Recipe DROP CONSTRAINT DF__Recipe__Carbohyd__531856C7");
            migrationBuilder.DropColumn(
                name: "Carbohydrates",
                table: "Recipe");

            migrationBuilder.DropForeignKey(
                name: "FK_Method_Recipe_RecipeId",
                table: "Method");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Method",
                table: "Method");

            migrationBuilder.AddColumn<float>(
                name: "Carbohydrates",
                table: "Recipe",
                type: "real",
                nullable: false,
                defaultValue: 0f);


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
            migrationBuilder.AddColumn<float>(
               name: "Carbohydrates",
               table: "Recipe",
               type: "real",
               nullable: false,
               defaultValue: 0f);

            migrationBuilder.Sql("ALTER TABLE Recipe ADD CONSTRAINT DF__Recipe__Carbohyd__531856C7 DEFAULT 0 FOR Carbohydrates");

            migrationBuilder.DropForeignKey(
                name: "FK_Step_Recipe_RecipeId",
                table: "Step");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Step",
                table: "Step");

            migrationBuilder.DropColumn(
                name: "Carbohydrates",
                table: "Recipe");


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
