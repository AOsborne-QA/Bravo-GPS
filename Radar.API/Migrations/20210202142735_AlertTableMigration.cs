using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Radar.API.Migrations
{
    public partial class AlertTableMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alerts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AlertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AlertColour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlertType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<float>(type: "real", nullable: false),
                    Longitude = table.Column<float>(type: "real", nullable: false),
                    VehicleTemp = table.Column<float>(type: "real", nullable: false),
                    VehicleHumidity = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alerts", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alerts");
        }
    }
}
