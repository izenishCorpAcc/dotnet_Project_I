using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BulkyWeb_1._0.Migrations
{
    /// <inheritdoc />
    public partial class Adding_to_DBAndQuizs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "QuestionList",
                keyColumn: "Question_ID",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "QuestionList",
                keyColumn: "Question_ID",
                keyValue: -1);

            migrationBuilder.InsertData(
                table: "QuestionList",
                columns: new[] { "Question_ID", "Correct_Answer", "Question", "WrongAnswer_1", "WrongAnswer_2", "WrongAnswer_3" },
                values: new object[,]
                {
                    { 2, "King Charles III", "King Of England", "King Charles II", "King Charles I", "King Charles IV" },
                    { 3, "50", "How many states are there in USA", "51", "49", "52" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "QuestionList",
                keyColumn: "Question_ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "QuestionList",
                keyColumn: "Question_ID",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "QuestionList",
                columns: new[] { "Question_ID", "Correct_Answer", "Question", "WrongAnswer_1", "WrongAnswer_2", "WrongAnswer_3" },
                values: new object[,]
                {
                    { -2, "50", "How many states are there in USA", "51", "49", "52" },
                    { -1, "King Charles III", "King Of England", "King Charles II", "King Charles I", "King Charles IV" }
                });
        }
    }
}
