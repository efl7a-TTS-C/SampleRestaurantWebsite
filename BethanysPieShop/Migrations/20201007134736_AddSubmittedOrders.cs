using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BethanysPieShop.Migrations
{
    public partial class AddSubmittedOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdminIndexViewModelId",
                table: "Pies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubmittedOrderId",
                table: "OrderItems",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AdminIndexViewModel",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminIndexViewModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubmittedOrders",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CustomerId = table.Column<string>(nullable: true),
                    TimeSubmitted = table.Column<DateTime>(nullable: false),
                    EstimatedShippingDate = table.Column<DateTime>(nullable: false),
                    Total = table.Column<double>(nullable: false),
                    AdminIndexViewModelId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubmittedOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubmittedOrders_AdminIndexViewModel_AdminIndexViewModelId",
                        column: x => x.AdminIndexViewModelId,
                        principalTable: "AdminIndexViewModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pies_AdminIndexViewModelId",
                table: "Pies",
                column: "AdminIndexViewModelId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_SubmittedOrderId",
                table: "OrderItems",
                column: "SubmittedOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_SubmittedOrders_AdminIndexViewModelId",
                table: "SubmittedOrders",
                column: "AdminIndexViewModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_SubmittedOrders_SubmittedOrderId",
                table: "OrderItems",
                column: "SubmittedOrderId",
                principalTable: "SubmittedOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pies_AdminIndexViewModel_AdminIndexViewModelId",
                table: "Pies",
                column: "AdminIndexViewModelId",
                principalTable: "AdminIndexViewModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_SubmittedOrders_SubmittedOrderId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Pies_AdminIndexViewModel_AdminIndexViewModelId",
                table: "Pies");

            migrationBuilder.DropTable(
                name: "SubmittedOrders");

            migrationBuilder.DropTable(
                name: "AdminIndexViewModel");

            migrationBuilder.DropIndex(
                name: "IX_Pies_AdminIndexViewModelId",
                table: "Pies");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_SubmittedOrderId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "AdminIndexViewModelId",
                table: "Pies");

            migrationBuilder.DropColumn(
                name: "SubmittedOrderId",
                table: "OrderItems");
        }
    }
}
