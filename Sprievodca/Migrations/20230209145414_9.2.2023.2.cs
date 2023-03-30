using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sprievodca.Migrations
{
    public partial class _9220232 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kraj_Oblast_OblastId",
                table: "Kraj");

            migrationBuilder.DropForeignKey(
                name: "FK_Oblast_PodOblast_PodOblastId",
                table: "Oblast");

            migrationBuilder.DropForeignKey(
                name: "FK_PodOblast_Sektor_SektorId",
                table: "PodOblast");

            migrationBuilder.DropForeignKey(
                name: "FK_Sektor_Cesta_CestaId",
                table: "Sektor");

            migrationBuilder.DropIndex(
                name: "IX_Sektor_CestaId",
                table: "Sektor");

            migrationBuilder.DropIndex(
                name: "IX_Kraj_OblastId",
                table: "Kraj");

            migrationBuilder.DropColumn(
                name: "CestaId",
                table: "Sektor");

            migrationBuilder.DropColumn(
                name: "OblastId",
                table: "Kraj");

            migrationBuilder.RenameColumn(
                name: "SektorId",
                table: "PodOblast",
                newName: "OblastId1");

            migrationBuilder.RenameIndex(
                name: "IX_PodOblast_SektorId",
                table: "PodOblast",
                newName: "IX_PodOblast_OblastId1");

            migrationBuilder.RenameColumn(
                name: "PodOblastId",
                table: "Oblast",
                newName: "KrajId1");

            migrationBuilder.RenameIndex(
                name: "IX_Oblast_PodOblastId",
                table: "Oblast",
                newName: "IX_Oblast_KrajId1");

            migrationBuilder.AddColumn<long>(
                name: "PodOblastId",
                table: "Sektor",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "PodOblastId1",
                table: "Sektor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "OblastId",
                table: "PodOblast",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "KrajId",
                table: "Oblast",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "SektorId",
                table: "Cesta",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "SektorId1",
                table: "Cesta",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sektor_PodOblastId1",
                table: "Sektor",
                column: "PodOblastId1");

            migrationBuilder.CreateIndex(
                name: "IX_Cesta_SektorId1",
                table: "Cesta",
                column: "SektorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Cesta_Sektor_SektorId1",
                table: "Cesta",
                column: "SektorId1",
                principalTable: "Sektor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Oblast_Kraj_KrajId1",
                table: "Oblast",
                column: "KrajId1",
                principalTable: "Kraj",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PodOblast_Oblast_OblastId1",
                table: "PodOblast",
                column: "OblastId1",
                principalTable: "Oblast",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sektor_PodOblast_PodOblastId1",
                table: "Sektor",
                column: "PodOblastId1",
                principalTable: "PodOblast",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cesta_Sektor_SektorId1",
                table: "Cesta");

            migrationBuilder.DropForeignKey(
                name: "FK_Oblast_Kraj_KrajId1",
                table: "Oblast");

            migrationBuilder.DropForeignKey(
                name: "FK_PodOblast_Oblast_OblastId1",
                table: "PodOblast");

            migrationBuilder.DropForeignKey(
                name: "FK_Sektor_PodOblast_PodOblastId1",
                table: "Sektor");

            migrationBuilder.DropIndex(
                name: "IX_Sektor_PodOblastId1",
                table: "Sektor");

            migrationBuilder.DropIndex(
                name: "IX_Cesta_SektorId1",
                table: "Cesta");

            migrationBuilder.DropColumn(
                name: "PodOblastId",
                table: "Sektor");

            migrationBuilder.DropColumn(
                name: "PodOblastId1",
                table: "Sektor");

            migrationBuilder.DropColumn(
                name: "OblastId",
                table: "PodOblast");

            migrationBuilder.DropColumn(
                name: "KrajId",
                table: "Oblast");

            migrationBuilder.DropColumn(
                name: "SektorId",
                table: "Cesta");

            migrationBuilder.DropColumn(
                name: "SektorId1",
                table: "Cesta");

            migrationBuilder.RenameColumn(
                name: "OblastId1",
                table: "PodOblast",
                newName: "SektorId");

            migrationBuilder.RenameIndex(
                name: "IX_PodOblast_OblastId1",
                table: "PodOblast",
                newName: "IX_PodOblast_SektorId");

            migrationBuilder.RenameColumn(
                name: "KrajId1",
                table: "Oblast",
                newName: "PodOblastId");

            migrationBuilder.RenameIndex(
                name: "IX_Oblast_KrajId1",
                table: "Oblast",
                newName: "IX_Oblast_PodOblastId");

            migrationBuilder.AddColumn<int>(
                name: "CestaId",
                table: "Sektor",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OblastId",
                table: "Kraj",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sektor_CestaId",
                table: "Sektor",
                column: "CestaId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Oblast_PodOblast_PodOblastId",
                table: "Oblast",
                column: "PodOblastId",
                principalTable: "PodOblast",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PodOblast_Sektor_SektorId",
                table: "PodOblast",
                column: "SektorId",
                principalTable: "Sektor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sektor_Cesta_CestaId",
                table: "Sektor",
                column: "CestaId",
                principalTable: "Cesta",
                principalColumn: "Id");
        }
    }
}
