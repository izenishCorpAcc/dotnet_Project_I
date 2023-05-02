using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BulkyWeb_1._0.Migrations
{
    /// <inheritdoc />
    public partial class AddQuestionsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuestionList",
                columns: table => new
                {
                    Question_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnswerID = table.Column<int>(type: "int", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer_1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer_2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer_3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer_4 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionList", x => x.Question_ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionList");
        }
    }
}
