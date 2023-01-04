using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodSpace.Data.Migrations
{
    /// <inheritdoc />
    public partial class foreignkey6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "itemId",
                table: "Recipe");

            migrationBuilder.AddColumn<int>(
                name: "ItemsFK",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemsFK",
                table: "Items",
                column: "ItemsFK");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Recipe_ItemsFK",
                table: "Items",
                column: "ItemsFK",
                principalTable: "Recipe",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Recipe_ItemsFK",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_ItemsFK",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ItemsFK",
                table: "Items");

            migrationBuilder.AddColumn<int>(
                name: "itemId",
                table: "Recipe",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
