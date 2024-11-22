using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School.Api.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class EnableCascadeDeleteForLevelGrades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Levels_LevelId",
                table: "Grades");

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Levels_LevelId",
                table: "Grades",
                column: "LevelId",
                principalTable: "Levels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Levels_LevelId",
                table: "Grades");

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Levels_LevelId",
                table: "Grades",
                column: "LevelId",
                principalTable: "Levels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
