using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BulkyWeb_1._0.Migrations
{
    /// <inheritdoc />
    public partial class newDB_prasna : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionList");

            migrationBuilder.CreateTable(
                name: "Prasna",
                columns: table => new
                {
                    Question_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correct_Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WrongAnswer_1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WrongAnswer_2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WrongAnswer_3 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prasna", x => x.Question_ID);
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "DisplayOrder",
                value: 4);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prasna");

            migrationBuilder.CreateTable(
                name: "QuestionList",
                columns: table => new
                {
                    Question_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Correct_Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WrongAnswer_1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WrongAnswer_2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WrongAnswer_3 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionList", x => x.Question_ID);
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "DisplayOrder",
                value: 40);

            migrationBuilder.InsertData(
                table: "QuestionList",
                columns: new[] { "Question_ID", "Correct_Answer", "Question", "WrongAnswer_1", "WrongAnswer_2", "WrongAnswer_3" },
                values: new object[,]
                {
                    { 2, "King Charles III", "King Of England", "King Charles II", "King Charles I", "King Charles IV" },
                    { 3, "50", "How many states are there in USA", "51", "49", "52" }
                });
        }
    }
}
