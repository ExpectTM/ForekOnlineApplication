using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForekOnlineApplication.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QualifacationType",
                table: "Qualifications",
                newName: "QualificationType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QualificationType",
                table: "Qualifications",
                newName: "QualifacationType");
        }
    }
}
