using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class _13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_guides_GuideGuidID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_reservitions_guides_GuideGuidID",
                table: "reservitions");

            migrationBuilder.DropIndex(
                name: "IX_reservitions_GuideGuidID",
                table: "reservitions");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_GuideGuidID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "GuideGuidID",
                table: "reservitions");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "guides");

            migrationBuilder.DropColumn(
                name: "InstgramUrl",
                table: "guides");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "guides");

            migrationBuilder.DropColumn(
                name: "TwiterUrl",
                table: "guides");

            migrationBuilder.DropColumn(
                name: "GuideGuidID",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GuideGuidID",
                table: "reservitions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "guides",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InstgramUrl",
                table: "guides",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "guides",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "TwiterUrl",
                table: "guides",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "GuideGuidID",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_reservitions_GuideGuidID",
                table: "reservitions",
                column: "GuideGuidID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_GuideGuidID",
                table: "AspNetUsers",
                column: "GuideGuidID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_guides_GuideGuidID",
                table: "AspNetUsers",
                column: "GuideGuidID",
                principalTable: "guides",
                principalColumn: "GuidID");

            migrationBuilder.AddForeignKey(
                name: "FK_reservitions_guides_GuideGuidID",
                table: "reservitions",
                column: "GuideGuidID",
                principalTable: "guides",
                principalColumn: "GuidID");
        }
    }
}
