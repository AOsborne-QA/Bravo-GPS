using Microsoft.EntityFrameworkCore.Migrations;

namespace Radar.API.Migrations
{
    public partial class AlertTableMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Alerts_VehicleID",
                table: "Alerts",
                column: "VehicleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Alerts_Vehicles_VehicleID",
                table: "Alerts",
                column: "VehicleID",
                principalTable: "Vehicles",
                principalColumn: "VehicleID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alerts_Vehicles_VehicleID",
                table: "Alerts");

            migrationBuilder.DropIndex(
                name: "IX_Alerts_VehicleID",
                table: "Alerts");
        }
    }
}
