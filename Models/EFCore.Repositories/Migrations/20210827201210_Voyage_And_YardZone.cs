using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.Repositories.Migrations
{
    public partial class Voyage_And_YardZone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Voyage",
                columns: table => new
                {
                    Number = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    State = table.Column<int>(type: "int", nullable: false),
                    BerthPlan_FromMeter = table.Column<int>(type: "int", nullable: true),
                    BerthPlan_ToMeter = table.Column<int>(type: "int", nullable: true),
                    BerthPlan_FromDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BerthPlan_ToDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voyage", x => x.Number);
                });

            migrationBuilder.CreateTable(
                name: "YardZone",
                columns: table => new
                {
                    Number = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DistanceInMeter = table.Column<int>(type: "int", nullable: false),
                    ZoneDistance_Total = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YardZone", x => x.Number);
                });

            migrationBuilder.CreateTable(
                name: "Berth",
                columns: table => new
                {
                    YardZoneNumber = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FromMeter = table.Column<int>(type: "int", nullable: false),
                    ToMeter = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Berth", x => new { x.YardZoneNumber, x.Id });
                    table.ForeignKey(
                        name: "FK_Berth_YardZone_YardZoneNumber",
                        column: x => x.YardZoneNumber,
                        principalTable: "YardZone",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BerthPlanPoint",
                columns: table => new
                {
                    ZoneMeter = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VoyageNumber = table.Column<int>(type: "int", nullable: false),
                    BerthPlanSheetYardZoneNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BerthPlanPoint", x => new { x.Date, x.ZoneMeter });
                    table.ForeignKey(
                        name: "FK_BerthPlanPoint_YardZone_BerthPlanSheetYardZoneNumber",
                        column: x => x.BerthPlanSheetYardZoneNumber,
                        principalTable: "YardZone",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DistancePoint",
                columns: table => new
                {
                    MeterNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BerthName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZoneDistanceYardZoneNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DistancePoint", x => x.MeterNumber);
                    table.ForeignKey(
                        name: "FK_DistancePoint_YardZone_ZoneDistanceYardZoneNumber",
                        column: x => x.ZoneDistanceYardZoneNumber,
                        principalTable: "YardZone",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BerthPlanPoint_BerthPlanSheetYardZoneNumber",
                table: "BerthPlanPoint",
                column: "BerthPlanSheetYardZoneNumber");

            migrationBuilder.CreateIndex(
                name: "IX_DistancePoint_ZoneDistanceYardZoneNumber",
                table: "DistancePoint",
                column: "ZoneDistanceYardZoneNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Berth");

            migrationBuilder.DropTable(
                name: "BerthPlanPoint");

            migrationBuilder.DropTable(
                name: "DistancePoint");

            migrationBuilder.DropTable(
                name: "Voyage");

            migrationBuilder.DropTable(
                name: "YardZone");
        }
    }
}
