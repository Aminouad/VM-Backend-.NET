using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniProjet.Migrations
{
    public partial class addDateAttributeAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Accounts");
        }
    }
}
