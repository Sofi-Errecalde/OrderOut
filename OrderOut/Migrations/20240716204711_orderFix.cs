using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderOut.Migrations
{
    /// <inheritdoc />
    public partial class orderFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersRoles_Users_UserId1",
                table: "UsersRoles");

            migrationBuilder.DropIndex(
                name: "IX_UsersRoles_UserId1",
                table: "UsersRoles");

            migrationBuilder.DropIndex(
                name: "IX_Orders_TableId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UsersRoles");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "TablesWaiters");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "TablesWaiters");

            migrationBuilder.AddColumn<DateOnly>(
                name: "Date",
                table: "TablesWaiters",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<int>(
                name: "Shift",
                table: "TablesWaiters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_TableId",
                table: "Orders",
                column: "TableId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Orders_TableId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "TablesWaiters");

            migrationBuilder.DropColumn(
                name: "Shift",
                table: "TablesWaiters");

            migrationBuilder.AddColumn<long>(
                name: "UserId1",
                table: "UsersRoles",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "TablesWaiters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "TablesWaiters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_UsersRoles_UserId1",
                table: "UsersRoles",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_TableId",
                table: "Orders",
                column: "TableId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersRoles_Users_UserId1",
                table: "UsersRoles",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
