using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sprievodca.Migrations
{
    public partial class _9220234 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OblastId",
                table: "Kraj",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Kraj_OblastId",
                table: "Kraj",
                column: "OblastId");

            migrationBuilder.AddForeignKey(
                name: "FK_Kraj_Oblast_OblastId",
                table: "Kraj",
                column: "OblastId",
                principalTable: "Oblast",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kraj_Oblast_OblastId",
                table: "Kraj");

            migrationBuilder.DropIndex(
                name: "IX_Kraj_OblastId",
                table: "Kraj");

            migrationBuilder.DropColumn(
                name: "OblastId",
                table: "Kraj");
        }
    }
}
