using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sprievodca.Migrations
{
    public partial class Creating_Kraj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cesta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    Lenght = table.Column<int>(type: "int", nullable: false),
                    Style = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cesta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sektor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PictureURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CestaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sektor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sektor_Cesta_CestaId",
                        column: x => x.CestaId,
                        principalTable: "Cesta",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PodOblast",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SektorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PodOblast", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PodOblast_Sektor_SektorId",
                        column: x => x.SektorId,
                        principalTable: "Sektor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Oblast",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PodOblastId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oblast", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Oblast_PodOblast_PodOblastId",
                        column: x => x.PodOblastId,
                        principalTable: "PodOblast",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kraj",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazov = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OblastId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kraj", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kraj_Oblast_OblastId",
                        column: x => x.OblastId,
                        principalTable: "Oblast",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kraj_OblastId",
                table: "Kraj",
                column: "OblastId");

            migrationBuilder.CreateIndex(
                name: "IX_Oblast_PodOblastId",
                table: "Oblast",
                column: "PodOblastId");

            migrationBuilder.CreateIndex(
                name: "IX_PodOblast_SektorId",
                table: "PodOblast",
                column: "SektorId");

            migrationBuilder.CreateIndex(
                name: "IX_Sektor_CestaId",
                table: "Sektor",
                column: "CestaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kraj");

            migrationBuilder.DropTable(
                name: "Oblast");

            migrationBuilder.DropTable(
                name: "PodOblast");

            migrationBuilder.DropTable(
                name: "Sektor");

            migrationBuilder.DropTable(
                name: "Cesta");
        }
    }
}
