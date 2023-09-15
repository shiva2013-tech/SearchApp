using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultipleSearchApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
        name: "tblProduct",
        columns: table => new
        {
            ProductId = table.Column<int>(nullable: false)
                .Annotation("SqlServer:Identity", "1, 1"),
            ProductName = table.Column<string>(nullable: false),
            Size = table.Column<string>(nullable: false),
            Price = table.Column<int>(nullable: false),
            MfgDate = table.Column<DateTime>(nullable: false),
            Category = table.Column<string>(nullable: false)
        },
        constraints: table =>
        {
            table.PrimaryKey("PK_tblProduct", x => x.ProductId);
        });

            migrationBuilder.InsertData(
                table: "tblProduct",
                columns: new[] { "ProductName", "Size", "Price", "MfgDate", "Category" },
                values: new object[,]
                {
            { "Product 1", "L", 10, DateTime.Parse("2023-01-01"), "Economy" },
            { "Product 2", "M", 15, DateTime.Parse("2023-02-01"), "Standard" },
            { "Product 2", "S", 15, DateTime.Parse("2023-03-01"), "Premium" }
                    // Add more data as needed
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblProduct");
        }
    }
}
