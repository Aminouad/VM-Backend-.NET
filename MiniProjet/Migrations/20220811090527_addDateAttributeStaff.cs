using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniProjet.Migrations
{
    public partial class addDateAttributeStaff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "Staffs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Staffs");
        }
    }
}
