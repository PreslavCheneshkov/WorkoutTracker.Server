using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkoutTracker.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class Updated_TrainingSession_Duration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "TrainingSessions");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "TrainingSessions");

            migrationBuilder.AddColumn<long>(
                name: "DurationTicks",
                table: "TrainingSessions",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Started",
                table: "TrainingSessions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DurationTicks",
                table: "TrainingSessions");

            migrationBuilder.DropColumn(
                name: "Started",
                table: "TrainingSessions");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "TrainingSessions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Duration",
                table: "TrainingSessions",
                type: "time",
                nullable: true);
        }
    }
}
