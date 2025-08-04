using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class migaddDestinitonnewentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CoverImage",
                table: "destinitons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Detail1",
                table: "destinitons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Detail2",
                table: "destinitons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Detail3",
                table: "destinitons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Detail4",
                table: "destinitons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Detail5",
                table: "destinitons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Image2",
                table: "destinitons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Image3",
                table: "destinitons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title1",
                table: "destinitons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title3",
                table: "destinitons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title4",
                table: "destinitons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title5",
                table: "destinitons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoverImage",
                table: "destinitons");

            migrationBuilder.DropColumn(
                name: "Detail1",
                table: "destinitons");

            migrationBuilder.DropColumn(
                name: "Detail2",
                table: "destinitons");

            migrationBuilder.DropColumn(
                name: "Detail3",
                table: "destinitons");

            migrationBuilder.DropColumn(
                name: "Detail4",
                table: "destinitons");

            migrationBuilder.DropColumn(
                name: "Detail5",
                table: "destinitons");

            migrationBuilder.DropColumn(
                name: "Image2",
                table: "destinitons");

            migrationBuilder.DropColumn(
                name: "Image3",
                table: "destinitons");

            migrationBuilder.DropColumn(
                name: "Title1",
                table: "destinitons");

            migrationBuilder.DropColumn(
                name: "Title3",
                table: "destinitons");

            migrationBuilder.DropColumn(
                name: "Title4",
                table: "destinitons");

            migrationBuilder.DropColumn(
                name: "Title5",
                table: "destinitons");
        }
    }
}
