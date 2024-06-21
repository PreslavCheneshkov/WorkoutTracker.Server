using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkoutTracker.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedStats : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "CurrentBodyfatPercentage",
                table: "AspNetUsers",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "CurrentWeightKg",
                table: "AspNetUsers",
                type: "float",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PersonalStats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkoutTrackerUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MeasurementDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WeightKilograms = table.Column<double>(type: "float", nullable: true),
                    BodyFatPercentage = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalStats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalStats_AspNetUsers_WorkoutTrackerUserId",
                        column: x => x.WorkoutTrackerUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonalStats_WorkoutTrackerUserId",
                table: "PersonalStats",
                column: "WorkoutTrackerUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonalStats");

            migrationBuilder.DropColumn(
                name: "CurrentBodyfatPercentage",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CurrentWeightKg",
                table: "AspNetUsers");
        }
    }
}
