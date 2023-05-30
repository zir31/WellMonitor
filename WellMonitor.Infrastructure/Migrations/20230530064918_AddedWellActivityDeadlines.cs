using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WellMonitor.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedWellActivityDeadlines : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "t_well_deadline",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WellId = table.Column<int>(type: "INTEGER", nullable: false),
                    Deadline = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_well_deadline", x => x.Id);
                    table.ForeignKey(
                        name: "FK_t_well_deadline_t_well_WellId",
                        column: x => x.WellId,
                        principalTable: "t_well",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_t_well_deadline_WellId",
                table: "t_well_deadline",
                column: "WellId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_well_deadline");
        }
    }
}
