using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BulkyWeb_1._0.Migrations
{
    /// <inheritdoc />
    public partial class AddQuestionsTable_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnswerID",
                table: "QuestionList");

            migrationBuilder.RenameColumn(
                name: "Answer_4",
                table: "QuestionList",
                newName: "WrongAnswer_3");

            migrationBuilder.RenameColumn(
                name: "Answer_3",
                table: "QuestionList",
                newName: "WrongAnswer_2");

            migrationBuilder.RenameColumn(
                name: "Answer_2",
                table: "QuestionList",
                newName: "WrongAnswer_1");

            migrationBuilder.RenameColumn(
                name: "Answer_1",
                table: "QuestionList",
                newName: "Correct_Answer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WrongAnswer_3",
                table: "QuestionList",
                newName: "Answer_4");

            migrationBuilder.RenameColumn(
                name: "WrongAnswer_2",
                table: "QuestionList",
                newName: "Answer_3");

            migrationBuilder.RenameColumn(
                name: "WrongAnswer_1",
                table: "QuestionList",
                newName: "Answer_2");

            migrationBuilder.RenameColumn(
                name: "Correct_Answer",
                table: "QuestionList",
                newName: "Answer_1");

            migrationBuilder.AddColumn<int>(
                name: "AnswerID",
                table: "QuestionList",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
