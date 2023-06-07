using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForekOnlineApplication.Migrations
{
    /// <inheritdoc />
    public partial class addSecondarySchoolTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SecondarySchools",
                columns: table => new
                {
                    HighSchoolId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HighSchoolName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GradePassed = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecondarySchools", x => x.HighSchoolId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SecondarySchools");
        }
    }
}
