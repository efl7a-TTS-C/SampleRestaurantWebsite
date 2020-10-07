using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BethanysPieShop.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            //migrationBuilder.CreateTable(
            //    name: "Pies",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(nullable: true),
            //        Description = table.Column<string>(nullable: true),
            //        ImageUrl = table.Column<string>(nullable: true),
            //        Price = table.Column<double>(nullable: false),
            //        IsPieOfTheWeek = table.Column<bool>(nullable: false),
            //        IsInStock = table.Column<bool>(nullable: false),
            //        Category = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Pies", x => x.Id);
            //    });

           
            //migrationBuilder.CreateTable(
            //    name: "OrderItems",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        PieId = table.Column<int>(nullable: true),
            //        Quantity = table.Column<int>(nullable: false),
            //        OrderId = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_OrderItems", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_OrderItems_Pies_PieId",
            //            column: x => x.PieId,
            //            principalTable: "Pies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

           

            //migrationBuilder.CreateIndex(
            //    name: "IX_OrderItems_PieId",
            //    table: "OrderItems",
            //    column: "PieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "OrderItems");

            //migrationBuilder.DropTable(
            //    name: "Pies");
        }
    }
}
