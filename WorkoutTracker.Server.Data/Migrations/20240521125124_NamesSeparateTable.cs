using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkoutTracker.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class NamesSeparateTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseParameters_Exercises_ExerciseId",
                table: "ExerciseParameters");

            migrationBuilder.DropTable(
                name: "ExerciseTrainingSession");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ExerciseParameters");

            migrationBuilder.AddColumn<int>(
                name: "TrainingSessionId",
                table: "Exercises",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ExerciseId",
                table: "ExerciseParameters",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ExerciseParameterNameId",
                table: "ExerciseParameters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ExerciseNames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseNames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseParameterNames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseParameterNames", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_TrainingSessionId",
                table: "Exercises",
                column: "TrainingSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseParameters_ExerciseParameterNameId",
                table: "ExerciseParameters",
                column: "ExerciseParameterNameId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseParameters_ExerciseParameterNames_ExerciseParameterNameId",
                table: "ExerciseParameters",
                column: "ExerciseParameterNameId",
                principalTable: "ExerciseParameterNames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseParameters_Exercises_ExerciseId",
                table: "ExerciseParameters",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_TrainingSessions_TrainingSessionId",
                table: "Exercises",
                column: "TrainingSessionId",
                principalTable: "TrainingSessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseParameters_ExerciseParameterNames_ExerciseParameterNameId",
                table: "ExerciseParameters");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseParameters_Exercises_ExerciseId",
                table: "ExerciseParameters");

            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_TrainingSessions_TrainingSessionId",
                table: "Exercises");

            migrationBuilder.DropTable(
                name: "ExerciseNames");

            migrationBuilder.DropTable(
                name: "ExerciseParameterNames");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_TrainingSessionId",
                table: "Exercises");

            migrationBuilder.DropIndex(
                name: "IX_ExerciseParameters_ExerciseParameterNameId",
                table: "ExerciseParameters");

            migrationBuilder.DropColumn(
                name: "TrainingSessionId",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "ExerciseParameterNameId",
                table: "ExerciseParameters");

            migrationBuilder.AlterColumn<int>(
                name: "ExerciseId",
                table: "ExerciseParameters",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ExerciseParameters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ExerciseTrainingSession",
                columns: table => new
                {
                    ExercisesId = table.Column<int>(type: "int", nullable: false),
                    SessionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseTrainingSession", x => new { x.ExercisesId, x.SessionsId });
                    table.ForeignKey(
                        name: "FK_ExerciseTrainingSession_Exercises_ExercisesId",
                        column: x => x.ExercisesId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseTrainingSession_TrainingSessions_SessionsId",
                        column: x => x.SessionsId,
                        principalTable: "TrainingSessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseTrainingSession_SessionsId",
                table: "ExerciseTrainingSession",
                column: "SessionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseParameters_Exercises_ExerciseId",
                table: "ExerciseParameters",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
