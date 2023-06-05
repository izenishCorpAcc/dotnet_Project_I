using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BulkyWeb_1._0.Migrations
{
    /// <inheritdoc />
    public partial class recreatingDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddPrimaryKey(
                name: "PK_QuizResults",
                table: "QuizResults",
                column: "QuizResult_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_QuizResults",
                table: "QuizResults");
        }
    }
}
