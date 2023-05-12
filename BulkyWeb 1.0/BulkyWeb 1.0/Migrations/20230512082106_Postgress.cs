using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BulkyWeb_1._0.Migrations
{
    /// <inheritdoc />
    public partial class Postgress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionList");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "DisplayOrder",
                table: "Categories",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Categories",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.CreateTable(
                name: "Prasna",
                columns: table => new
                {
                    Question_ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Question = table.Column<string>(type: "varchar(255)", nullable: false),
                    Correst_Answer = table.Column<string>(type: "varchar(255)", nullable: false),
                    WrongAnswer_1 = table.Column<string>(type: "varchar(255)", nullable: false),
                    WrongAnswer_2 = table.Column<string>(type: "varchar(255)", nullable: false),
                    WrongAnswer_3 = table.Column<string>(type: "varchar(255)", nullable: false)
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

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)");

            migrationBuilder.AlterColumn<int>(
                name: "DisplayOrder",
                table: "Categories",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Categories",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.CreateTable(
                name: "QuestionList",
                columns: table => new
                {
                    Question_ID = table.Column<int>(type: "int", nullable: false),
                    Correst_Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                columns: new[] { "Question_ID", "Correst_Answer", "Question", "WrongAnswer_1", "WrongAnswer_2", "WrongAnswer_3" },
                values: new object[,]
                {
                    { 2, "King Charles III", "King Of England", "King Charles II", "King Charles I", "King Charles IV" },
                    { 3, "50", "How many states are there in USA", "51", "49", "52" }
                });
        }
    }
}
