using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderOut.Migrations
{
    /// <inheritdoc />
    public partial class mig8718 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersRoles",
                table: "UsersRoles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersRoles",
                table: "UsersRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UsersRoles_Users_UserId",
                table: "UsersRoles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersRoles_Users_UserId",
                table: "UsersRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersRoles",
                table: "UsersRoles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersRoles",
                table: "UsersRoles",
                column: "Id");
        }
    }
}
