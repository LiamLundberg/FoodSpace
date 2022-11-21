﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodSpace.Data.Migrations
{
    /// <inheritdoc />
    public partial class advanceditemproperties3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ServingSize",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServingSize",
                table: "Items");
        }
    }
}
