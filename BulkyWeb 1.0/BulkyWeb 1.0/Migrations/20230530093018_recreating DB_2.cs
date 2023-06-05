using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BulkyWeb_1._0.Migrations
{
    /// <inheritdoc />
    public partial class recreatingDB_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuizResults_Prasna_Question_ID",
                table: "QuizResults");

            migrationBuilder.DropIndex(
                name: "IX_QuizResults_Question_ID",
                table: "QuizResults");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_QuizResults_Question_ID",
                table: "QuizResults",
                column: "Question_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_QuizResults_Prasna_Question_ID",
                table: "QuizResults",
                column: "Question_ID",
                principalTable: "Prasna",
                principalColumn: "Question_ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
