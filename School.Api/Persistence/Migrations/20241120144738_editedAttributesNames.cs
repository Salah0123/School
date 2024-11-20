using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School.Api.Migrations
{
    /// <inheritdoc />
    public partial class editedAttributesNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Count",
                table: "Regions",
                newName: "TeacherCount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TeacherCount",
                table: "Regions",
                newName: "Count");
        }
    }
}
