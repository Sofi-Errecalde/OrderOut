using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderOut.Migrations
{
    /// <inheritdoc />
    public partial class fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Tables_TableId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_TableId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_UserId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TableId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ClientEmail",
                table: "Bills");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "TablesWaiters",
                newName: "StartTime");

            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Orders",
                newName: "Requested");

            migrationBuilder.AddColumn<DateTime>(
                name: "Delivered",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "TableWaiterId",
                table: "Bills",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Bills_TableWaiterId",
                table: "Bills",
                column: "TableWaiterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_TablesWaiters_TableWaiterId",
                table: "Bills",
                column: "TableWaiterId",
                principalTable: "TablesWaiters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_TablesWaiters_TableWaiterId",
                table: "Bills");

            migrationBuilder.DropIndex(
                name: "IX_Bills_TableWaiterId",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "Delivered",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TableWaiterId",
                table: "Bills");

            migrationBuilder.RenameColumn(
                name: "StartTime",
                table: "TablesWaiters",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "Requested",
                table: "Orders",
                newName: "DateTime");

            migrationBuilder.AddColumn<long>(
                name: "TableId",
                table: "Orders",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "Orders",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "ClientEmail",
                table: "Bills",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_TableId",
                table: "Orders",
                column: "TableId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Tables_TableId",
                table: "Orders",
                column: "TableId",
                principalTable: "Tables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
