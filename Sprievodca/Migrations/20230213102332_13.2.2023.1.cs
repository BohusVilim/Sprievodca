using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sprievodca.Migrations
{
    public partial class _13220231 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cesta_Sektor_SektorId1",
                table: "Cesta");

            migrationBuilder.DropForeignKey(
                name: "FK_Kraj_Oblast_OblastId",
                table: "Kraj");

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
                name: "IX_PodOblast_OblastId1",
                table: "PodOblast");

            migrationBuilder.DropIndex(
                name: "IX_Oblast_KrajId1",
                table: "Oblast");

            migrationBuilder.DropIndex(
                name: "IX_Kraj_OblastId",
                table: "Kraj");

            migrationBuilder.DropIndex(
                name: "IX_Cesta_SektorId1",
                table: "Cesta");

            migrationBuilder.DropColumn(
                name: "PodOblastId1",
                table: "Sektor");

            migrationBuilder.DropColumn(
                name: "OblastId1",
                table: "PodOblast");

            migrationBuilder.DropColumn(
                name: "KrajId1",
                table: "Oblast");

            migrationBuilder.DropColumn(
                name: "OblastId",
                table: "Kraj");

            migrationBuilder.DropColumn(
                name: "SektorId1",
                table: "Cesta");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Sektor",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "PodOblast",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Oblast",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Kraj",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Cesta",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_Sektor_PodOblastId",
                table: "Sektor",
                column: "PodOblastId");

            migrationBuilder.CreateIndex(
                name: "IX_PodOblast_OblastId",
                table: "PodOblast",
                column: "OblastId");

            migrationBuilder.CreateIndex(
                name: "IX_Oblast_KrajId",
                table: "Oblast",
                column: "KrajId");

            migrationBuilder.CreateIndex(
                name: "IX_Cesta_SektorId",
                table: "Cesta",
                column: "SektorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cesta_Sektor_SektorId",
                table: "Cesta",
                column: "SektorId",
                principalTable: "Sektor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Oblast_Kraj_KrajId",
                table: "Oblast",
                column: "KrajId",
                principalTable: "Kraj",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PodOblast_Oblast_OblastId",
                table: "PodOblast",
                column: "OblastId",
                principalTable: "Oblast",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sektor_PodOblast_PodOblastId",
                table: "Sektor",
                column: "PodOblastId",
                principalTable: "PodOblast",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cesta_Sektor_SektorId",
                table: "Cesta");

            migrationBuilder.DropForeignKey(
                name: "FK_Oblast_Kraj_KrajId",
                table: "Oblast");

            migrationBuilder.DropForeignKey(
                name: "FK_PodOblast_Oblast_OblastId",
                table: "PodOblast");

            migrationBuilder.DropForeignKey(
                name: "FK_Sektor_PodOblast_PodOblastId",
                table: "Sektor");

            migrationBuilder.DropIndex(
                name: "IX_Sektor_PodOblastId",
                table: "Sektor");

            migrationBuilder.DropIndex(
                name: "IX_PodOblast_OblastId",
                table: "PodOblast");

            migrationBuilder.DropIndex(
                name: "IX_Oblast_KrajId",
                table: "Oblast");

            migrationBuilder.DropIndex(
                name: "IX_Cesta_SektorId",
                table: "Cesta");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Sektor",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "PodOblastId1",
                table: "Sektor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "PodOblast",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "OblastId1",
                table: "PodOblast",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Oblast",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "KrajId1",
                table: "Oblast",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Kraj",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "OblastId",
                table: "Kraj",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Cesta",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

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
                name: "IX_PodOblast_OblastId1",
                table: "PodOblast",
                column: "OblastId1");

            migrationBuilder.CreateIndex(
                name: "IX_Oblast_KrajId1",
                table: "Oblast",
                column: "KrajId1");

            migrationBuilder.CreateIndex(
                name: "IX_Kraj_OblastId",
                table: "Kraj",
                column: "OblastId");

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
                name: "FK_Kraj_Oblast_OblastId",
                table: "Kraj",
                column: "OblastId",
                principalTable: "Oblast",
                principalColumn: "Id");

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
    }
}
