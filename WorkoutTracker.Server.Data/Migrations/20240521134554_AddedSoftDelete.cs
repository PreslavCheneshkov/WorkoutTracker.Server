using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkoutTracker.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedSoftDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ExerciseParameterNames",
                newName: "Value");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "TrainingSessions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "TrainingSessions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Exercises",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Exercises",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "ExerciseParameters",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ExerciseParameters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "ExerciseParameterNames",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ExerciseParameterNames",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "ExerciseNames",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ExerciseNames",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "TrainingSessions");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TrainingSessions");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "ExerciseParameters");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ExerciseParameters");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "ExerciseParameterNames");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ExerciseParameterNames");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "ExerciseNames");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ExerciseNames");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "ExerciseParameterNames",
                newName: "Name");
        }
    }
}
