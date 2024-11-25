using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School.Api.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RemovedGradeForeignKeyFromLesson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Grades_GradeId",
                table: "Lessons");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_GradeId",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "GradeId",
                table: "Lessons");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GradeId",
                table: "Lessons",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_GradeId",
                table: "Lessons",
                column: "GradeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Grades_GradeId",
                table: "Lessons",
                column: "GradeId",
                principalTable: "Grades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
