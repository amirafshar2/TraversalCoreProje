using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class _17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_destinitons_tourliders_tourliderid",
                table: "destinitons");

            migrationBuilder.AlterColumn<int>(
                name: "tourliderid",
                table: "destinitons",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_destinitons_tourliders_tourliderid",
                table: "destinitons",
                column: "tourliderid",
                principalTable: "tourliders",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_destinitons_tourliders_tourliderid",
                table: "destinitons");

            migrationBuilder.AlterColumn<int>(
                name: "tourliderid",
                table: "destinitons",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_destinitons_tourliders_tourliderid",
                table: "destinitons",
                column: "tourliderid",
                principalTable: "tourliders",
                principalColumn: "id");
        }
    }
}
