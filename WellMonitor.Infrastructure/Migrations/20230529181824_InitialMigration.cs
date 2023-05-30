using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WellMonitor.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "t_company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_telemetry",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date_time = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Depth = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_telemetry", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_well",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Id_company = table.Column<int>(type: "INTEGER", nullable: false),
                    Id_telemetry = table.Column<int>(type: "INTEGER", nullable: false),
                    Active = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_well", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_company");

            migrationBuilder.DropTable(
                name: "t_telemetry");

            migrationBuilder.DropTable(
                name: "t_well");
        }
    }
}
