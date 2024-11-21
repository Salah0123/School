using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School.Api.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class editedSubjectEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GradeSubject");

            migrationBuilder.AddColumn<string>(
                name: "GradeId",
                table: "Subjects",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_GradeId",
                table: "Subjects",
                column: "GradeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Grades_GradeId",
                table: "Subjects",
                column: "GradeId",
                principalTable: "Grades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Grades_GradeId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_GradeId",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "GradeId",
                table: "Subjects");

            migrationBuilder.CreateTable(
                name: "GradeSubject",
                columns: table => new
                {
                    GradesId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SubjectsId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradeSubject", x => new { x.GradesId, x.SubjectsId });
                    table.ForeignKey(
                        name: "FK_GradeSubject_Grades_GradesId",
                        column: x => x.GradesId,
                        principalTable: "Grades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GradeSubject_Subjects_SubjectsId",
                        column: x => x.SubjectsId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GradeSubject_SubjectsId",
                table: "GradeSubject",
                column: "SubjectsId");
        }
    }
}
