using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkoutTracker.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class Added_TrainingSession_Name_Comment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "TrainingSessions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "TrainingSessions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_ExerciseNameId",
                table: "Exercises",
                column: "ExerciseNameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_ExerciseNames_ExerciseNameId",
                table: "Exercises",
                column: "ExerciseNameId",
                principalTable: "ExerciseNames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_ExerciseNames_ExerciseNameId",
                table: "Exercises");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_ExerciseNameId",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "TrainingSessions");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "TrainingSessions");
        }
    }
}
