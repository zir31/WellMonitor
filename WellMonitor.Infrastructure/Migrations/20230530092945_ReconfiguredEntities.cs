using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WellMonitor.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ReconfiguredEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id_telemetry",
                table: "t_well");

            migrationBuilder.AddColumn<int>(
                name: "WellId",
                table: "t_telemetry",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_t_well_Id_company",
                table: "t_well",
                column: "Id_company");

            migrationBuilder.CreateIndex(
                name: "IX_t_telemetry_WellId",
                table: "t_telemetry",
                column: "WellId");

            migrationBuilder.AddForeignKey(
                name: "FK_t_telemetry_t_well_WellId",
                table: "t_telemetry",
                column: "WellId",
                principalTable: "t_well",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_t_well_t_company_Id_company",
                table: "t_well",
                column: "Id_company",
                principalTable: "t_company",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_t_telemetry_t_well_WellId",
                table: "t_telemetry");

            migrationBuilder.DropForeignKey(
                name: "FK_t_well_t_company_Id_company",
                table: "t_well");

            migrationBuilder.DropIndex(
                name: "IX_t_well_Id_company",
                table: "t_well");

            migrationBuilder.DropIndex(
                name: "IX_t_telemetry_WellId",
                table: "t_telemetry");

            migrationBuilder.DropColumn(
                name: "WellId",
                table: "t_telemetry");

            migrationBuilder.AddColumn<int>(
                name: "Id_telemetry",
                table: "t_well",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
