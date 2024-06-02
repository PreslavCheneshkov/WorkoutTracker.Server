using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkoutTracker.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class addedexerciseIdtoexerciseParameter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseParameters_Exercises_ExerciseId",
                table: "ExerciseParameters");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Exercises");

            migrationBuilder.AddColumn<bool>(
                name: "IsFinished",
                table: "TrainingSessions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ExerciseNameId",
                table: "Exercises",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ExerciseId",
                table: "ExerciseParameters",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseParameters_Exercises_ExerciseId",
                table: "ExerciseParameters",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseParameters_Exercises_ExerciseId",
                table: "ExerciseParameters");

            migrationBuilder.DropColumn(
                name: "IsFinished",
                table: "TrainingSessions");

            migrationBuilder.DropColumn(
                name: "ExerciseNameId",
                table: "Exercises");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Exercises",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "ExerciseId",
                table: "ExerciseParameters",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseParameters_Exercises_ExerciseId",
                table: "ExerciseParameters",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id");
        }
    }
}
