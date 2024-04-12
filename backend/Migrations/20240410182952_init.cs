using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "email",
                table: "UserTBL");

            migrationBuilder.CreateTable(
                name: "MutualFundOrderTBL",
                columns: table => new
                {
                    orderid = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    orderGuid = table.Column<string>(type: "TEXT", nullable: false),
                    fundName = table.Column<string>(type: "TEXT", nullable: false),
                    paymentid = table.Column<string>(type: "TEXT", nullable: false),
                    amount = table.Column<double>(type: "REAL", nullable: false),
                    units = table.Column<double>(type: "REAL", nullable: false),
                    status = table.Column<bool>(type: "INTEGER", nullable: false),
                    pricePerUnit = table.Column<double>(type: "REAL", nullable: false),
                    createdDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MutualFundOrderTBL", x => x.orderid);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTBL",
                columns: table => new
                {
                    transactionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    amount = table.Column<double>(type: "REAL", nullable: false),
                    createdDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    status = table.Column<bool>(type: "INTEGER", nullable: false),
                    paymentid = table.Column<string>(type: "TEXT", nullable: false),
                    phoneNumber = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTBL", x => x.transactionId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MutualFundOrderTBL");

            migrationBuilder.DropTable(
                name: "PaymentTBL");

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "UserTBL",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
