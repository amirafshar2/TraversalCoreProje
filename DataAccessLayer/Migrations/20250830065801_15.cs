using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class _15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "tourliderid",
                table: "destinitons",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Tourliderid",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "tourliders",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SureName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TwiterUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstgramUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tourliders", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_destinitons_tourliderid",
                table: "destinitons",
                column: "tourliderid");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Tourliderid",
                table: "AspNetUsers",
                column: "Tourliderid");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_tourliders_Tourliderid",
                table: "AspNetUsers",
                column: "Tourliderid",
                principalTable: "tourliders",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_destinitons_tourliders_tourliderid",
                table: "destinitons",
                column: "tourliderid",
                principalTable: "tourliders",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_tourliders_Tourliderid",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_destinitons_tourliders_tourliderid",
                table: "destinitons");

            migrationBuilder.DropTable(
                name: "tourliders");

            migrationBuilder.DropIndex(
                name: "IX_destinitons_tourliderid",
                table: "destinitons");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Tourliderid",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "tourliderid",
                table: "destinitons");

            migrationBuilder.DropColumn(
                name: "Tourliderid",
                table: "AspNetUsers");
        }
    }
}
