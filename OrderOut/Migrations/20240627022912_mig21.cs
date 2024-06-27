using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderOut.Migrations
{
    /// <inheritdoc />
    public partial class mig21 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Users_UserId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_UserId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Roles");

            migrationBuilder.AddColumn<long>(
                name: "UserId1",
                table: "UsersRoles",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersRoles_UserId1",
                table: "UsersRoles",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersRoles_Users_UserId1",
                table: "UsersRoles",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersRoles_Users_UserId1",
                table: "UsersRoles");

            migrationBuilder.DropIndex(
                name: "IX_UsersRoles_UserId1",
                table: "UsersRoles");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UsersRoles");

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "Roles",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_UserId",
                table: "Roles",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Users_UserId",
                table: "Roles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
