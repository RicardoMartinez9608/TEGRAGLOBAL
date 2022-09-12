using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API_TEGRA.Migrations
{
    public partial class MigracionSqlServerInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Operation_Types",
                columns: table => new
                {
                    Id_Operation_Type = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Created_At = table.Column<DateTime>(nullable: false),
                    Updated_At = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operation_Types", x => x.Id_Operation_Type);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id_Product = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Created_At = table.Column<DateTime>(nullable: false),
                    Updated_At = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id_Product);
                });

            migrationBuilder.CreateTable(
                name: "Boxes",
                columns: table => new
                {
                    Id_Box = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Box_Number = table.Column<string>(nullable: true),
                    Created_At = table.Column<DateTime>(nullable: false),
                    Updated_At = table.Column<DateTime>(nullable: false),
                    ProductId_Product = table.Column<int>(nullable: true),
                    Id_Product = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boxes", x => x.Id_Box);
                    table.ForeignKey(
                        name: "FK_Boxes_Products_ProductId_Product",
                        column: x => x.ProductId_Product,
                        principalTable: "Products",
                        principalColumn: "Id_Product",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Operations",
                columns: table => new
                {
                    Id_Operation = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoxId_Box = table.Column<int>(nullable: true),
                    Id_Box = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Created_At = table.Column<DateTime>(nullable: false),
                    Updated_At = table.Column<DateTime>(nullable: false),
                    Operation_TypeId_Operation_Type = table.Column<int>(nullable: true),
                    Id_Operation_Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operations", x => x.Id_Operation);
                    table.ForeignKey(
                        name: "FK_Operations_Boxes_BoxId_Box",
                        column: x => x.BoxId_Box,
                        principalTable: "Boxes",
                        principalColumn: "Id_Box",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Operations_Operation_Types_Operation_TypeId_Operation_Type",
                        column: x => x.Operation_TypeId_Operation_Type,
                        principalTable: "Operation_Types",
                        principalColumn: "Id_Operation_Type",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Boxes_ProductId_Product",
                table: "Boxes",
                column: "ProductId_Product");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_BoxId_Box",
                table: "Operations",
                column: "BoxId_Box");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_Operation_TypeId_Operation_Type",
                table: "Operations",
                column: "Operation_TypeId_Operation_Type");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Operations");

            migrationBuilder.DropTable(
                name: "Boxes");

            migrationBuilder.DropTable(
                name: "Operation_Types");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
