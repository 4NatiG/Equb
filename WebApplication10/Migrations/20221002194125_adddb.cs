using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication10.Migrations
{
    public partial class adddb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    account_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    balance = table.Column<float>(nullable: false),
                    Id = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.account_id);
                });

            migrationBuilder.CreateTable(
                name: "equb_detail",
                columns: table => new
                {
                    equb_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    equb_name = table.Column<string>(maxLength: 25, nullable: false),
                    equb_type = table.Column<string>(nullable: false),
                    cycle = table.Column<string>(nullable: false),
                    duration = table.Column<int>(nullable: false),
                    status = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: false),
                    number_of_users = table.Column<int>(nullable: false),
                    amount = table.Column<float>(nullable: false),
                    start_date = table.Column<DateTime>(nullable: false),
                    end_date = table.Column<DateTime>(nullable: false),
                    user_id = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_equb_detail", x => x.equb_id);
                });

            migrationBuilder.CreateTable(
                name: "Transact",
                columns: table => new
                {
                    trans_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    amount = table.Column<float>(nullable: false),
                    trans_type = table.Column<string>(nullable: false),
                    trans_to = table.Column<string>(nullable: false),
                    time = table.Column<DateTime>(nullable: false),
                    id = table.Column<string>(nullable: false),
                    ac_id = table.Column<int>(nullable: true),
                    account_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transact", x => x.trans_id);
                    table.ForeignKey(
                        name: "FK_Transact_Account_account_id",
                        column: x => x.account_id,
                        principalTable: "Account",
                        principalColumn: "account_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "equb_order",
                columns: table => new
                {
                    equb_order_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<string>(nullable: false),
                    equb_id = table.Column<int>(nullable: true),
                    order_no = table.Column<int>(nullable: false),
                    status = table.Column<string>(nullable: false),
                    win_date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_equb_order", x => x.equb_order_id);
                    table.ForeignKey(
                        name: "FK_equb_order_equb_detail_equb_id",
                        column: x => x.equb_id,
                        principalTable: "equb_detail",
                        principalColumn: "equb_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_Id",
                table: "Account",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_equb_order_equb_id",
                table: "equb_order",
                column: "equb_id");

            migrationBuilder.CreateIndex(
                name: "IX_Transact_account_id",
                table: "Transact",
                column: "account_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "equb_order");

            migrationBuilder.DropTable(
                name: "Transact");

            migrationBuilder.DropTable(
                name: "equb_detail");

            migrationBuilder.DropTable(
                name: "Account");
        }
    }
}
