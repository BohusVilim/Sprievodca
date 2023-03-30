using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sprievodca.Migrations
{
    public partial class _14220231 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Cesta",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Year",
                table: "Cesta");
        }
    }
}
