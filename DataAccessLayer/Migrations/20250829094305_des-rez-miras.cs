using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class desrezmiras : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reservitions_destinitons_DestinitonDestinationID",
                table: "reservitions");

            migrationBuilder.AlterColumn<int>(
                name: "DestinitonDestinationID",
                table: "reservitions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_reservitions_destinitons_DestinitonDestinationID",
                table: "reservitions",
                column: "DestinitonDestinationID",
                principalTable: "destinitons",
                principalColumn: "DestinationID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reservitions_destinitons_DestinitonDestinationID",
                table: "reservitions");

            migrationBuilder.AlterColumn<int>(
                name: "DestinitonDestinationID",
                table: "reservitions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_reservitions_destinitons_DestinitonDestinationID",
                table: "reservitions",
                column: "DestinitonDestinationID",
                principalTable: "destinitons",
                principalColumn: "DestinationID");
        }
    }
}
