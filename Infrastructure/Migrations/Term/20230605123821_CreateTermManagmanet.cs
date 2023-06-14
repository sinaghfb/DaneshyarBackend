using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations.Term
{
    /// <inheritdoc />
    public partial class CreateTermManagmanet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.CreateTable(
                name: "Term",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StartYear = table.Column<int>(type: "int", nullable: false),
                    EndYear = table.Column<int>(type: "int", nullable: false),
                    TermCount = table.Column<int>(type: "int", nullable: false),
                    TermNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TermTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeStamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Term", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TermCourse",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TermCourseNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TeacherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartHour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndHour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TermId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CourseId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Day = table.Column<int>(type: "int", nullable: false),
                    ExamDate = table.Column<int>(type: "int", nullable: false),
                    ExamStartHour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExamEndHour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntraceYear = table.Column<int>(type: "int", nullable: false),
                    TimeStamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TermCourse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TermCourse_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TermCourse_Term_TermId",
                        column: x => x.TermId,
                        principalTable: "Term",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Term_TermNo",
                table: "Term",
                column: "TermNo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TermCourse_CourseId",
                table: "TermCourse",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_TermCourse_TermCourseNo",
                table: "TermCourse",
                column: "TermCourseNo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TermCourse_TermId",
                table: "TermCourse",
                column: "TermId");


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PreRequired");

            migrationBuilder.DropTable(
                name: "TermCourse");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Term");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
