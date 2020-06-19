using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JewelryShop.Migrations
{
    public partial class OrderAndOrderdetailToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    OrderTotal = table.Column<double>(nullable: false),
                    OrderStatus = table.Column<string>(nullable: true),
                    PaymentType = table.Column<string>(nullable: true),
                    TransactionId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JewelryIdF = table.Column<int>(nullable: false),
                    OrderIdF = table.Column<int>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailId);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Jewelries_JewelryIdF",
                        column: x => x.JewelryIdF,
                        principalTable: "Jewelries",
                        principalColumn: "JewelryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderIdF",
                        column: x => x.OrderIdF,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_JewelryIdF",
                table: "OrderDetails",
                column: "JewelryIdF");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderIdF",
                table: "OrderDetails",
                column: "OrderIdF");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ApplicationUserId",
                table: "Orders",
                column: "ApplicationUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Orders");

            
        }
    }
}
