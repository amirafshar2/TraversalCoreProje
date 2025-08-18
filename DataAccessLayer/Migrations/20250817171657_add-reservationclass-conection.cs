using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class addreservationclassconection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GuideId",
                table: "destinitons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GuideGuidID",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Guidid",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "reservitions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HowmanyPapel = table.Column<int>(type: "int", nullable: false),
                    Userid = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destintionid = table.Column<int>(type: "int", nullable: false),
                    ReservDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReservStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReservEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Guidid = table.Column<int>(type: "int", nullable: false),
                    DestinitonDestinationID = table.Column<int>(type: "int", nullable: true),
                    GuideGuidID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservitions", x => x.id);
                    table.ForeignKey(
                        name: "FK_reservitions_AspNetUsers_Userid",
                        column: x => x.Userid,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reservitions_destinitons_DestinitonDestinationID",
                        column: x => x.DestinitonDestinationID,
                        principalTable: "destinitons",
                        principalColumn: "DestinationID");
                    table.ForeignKey(
                        name: "FK_reservitions_guides_GuideGuidID",
                        column: x => x.GuideGuidID,
                        principalTable: "guides",
                        principalColumn: "GuidID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_GuideGuidID",
                table: "AspNetUsers",
                column: "GuideGuidID");

            migrationBuilder.CreateIndex(
                name: "IX_reservitions_DestinitonDestinationID",
                table: "reservitions",
                column: "DestinitonDestinationID");

            migrationBuilder.CreateIndex(
                name: "IX_reservitions_GuideGuidID",
                table: "reservitions",
                column: "GuideGuidID");

            migrationBuilder.CreateIndex(
                name: "IX_reservitions_Userid",
                table: "reservitions",
                column: "Userid");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_guides_GuideGuidID",
                table: "AspNetUsers",
                column: "GuideGuidID",
                principalTable: "guides",
                principalColumn: "GuidID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_guides_GuideGuidID",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "reservitions");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_GuideGuidID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "GuideId",
                table: "destinitons");

            migrationBuilder.DropColumn(
                name: "GuideGuidID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Guidid",
                table: "AspNetUsers");
        }
    }
}
