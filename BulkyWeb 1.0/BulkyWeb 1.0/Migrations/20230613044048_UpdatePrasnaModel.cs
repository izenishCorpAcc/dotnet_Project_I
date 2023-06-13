using Microsoft.EntityFrameworkCore.Migrations;

namespace BulkyWeb_1._0.Migrations
{
    public partial class UpdatePrasnaModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Correst_Answer",
                table: "Prasna",
                newName: "Correct_Answer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Correct_Answer",
                table: "Prasna",
                newName: "Correst_Answer");
        }
    }
}
