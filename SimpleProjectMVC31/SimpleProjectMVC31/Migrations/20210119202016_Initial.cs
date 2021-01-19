﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleProjectMVC31.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    Code = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Chocolates" },
                    { 2, "Fruit Candy" },
                    { 3, "Gummy Candy" },
                    { 4, "Halloween Candy" },
                    { 5, "Hard Candy" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Code", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "Chocolate_Assorted", "Assorted Chocolate", 4.99m },
                    { 2, 1, "Chocolate_Mixed", "Chocolate Mixed Candy", 5.99m },
                    { 3, 1, "Chocolate_MMS", "M&M", 3.75m },
                    { 4, 2, "Fruit_Chewy", "Chewy Fruit Candy", 6.9m },
                    { 5, 2, "Fruit_Pops", "Fruit Lolli Pops", 2.9m },
                    { 6, 2, "Fruit_Sour", "Sour Fruit Candy", 4.95m },
                    { 7, 3, "Gummy_Import", "Imported Gummy Candy", 11.9m },
                    { 8, 3, "Gummy_Sour", "Gummy Sour Candy", 1.9m },
                    { 9, 3, "Gummy_Traditional", "Traditional Gummy Candy", 2.9m },
                    { 10, 4, "Halloween_Assorted", "Assorted Halloween Candy", 3.5m },
                    { 11, 4, "Halloween_Orange", "Halloween Orange Cones", 4.33m },
                    { 12, 4, "Halloween_Red", "Halloween Red Cones", 3.98m },
                    { 13, 5, "Hard_Fruit", "Hard Fruit Candy", 9.9m },
                    { 14, 5, "Hard_Assorted", "Hard Assorted Candy", 8.97m },
                    { 15, 5, "Hard_Sour", "Sour Hard Candy", 5.55m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
