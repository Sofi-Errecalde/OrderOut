using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderOut.Migrations
{
    /// <inheritdoc />
    public partial class kitchenCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Kitchen",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Kitchen",
                table: "Categories");
        }
    }
}
