using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student_Microservice.Migrations
{
    /// <inheritdoc />
    public partial class ini5897898 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exam",
                columns: table => new
                {
                    ExamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ExamName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Exam_StartDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Exam_EndDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Exam_Duration = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    QuestionBankId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exam", x => x.ExamId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_ExamId",
                table: "Enrollments",
                column: "ExamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Exam_ExamId",
                table: "Enrollments",
                column: "ExamId",
                principalTable: "Exam",
                principalColumn: "ExamId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Exam_ExamId",
                table: "Enrollments");

            migrationBuilder.DropTable(
                name: "Exam");

            migrationBuilder.DropIndex(
                name: "IX_Enrollments_ExamId",
                table: "Enrollments");
        }
    }
}
