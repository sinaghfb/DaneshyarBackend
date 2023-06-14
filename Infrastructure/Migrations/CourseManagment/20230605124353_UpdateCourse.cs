using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations.CourseManagment
{
    /// <inheritdoc />
    public partial class UpdateCourse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_PreRequireds_PreRequiredId",
                table: "Course");

            migrationBuilder.DropIndex(
                name: "IX_Course_PreRequiredId",
                table: "Course");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PreRequireds",
                table: "PreRequireds");

            migrationBuilder.DropColumn(
                name: "PreRequiredId",
                table: "Course");

            migrationBuilder.RenameTable(
                name: "PreRequireds",
                newName: "PreRequired");

            migrationBuilder.AddColumn<string>(
                name: "PreRequiredCourseId",
                table: "PreRequired",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RequiredCourseId",
                table: "PreRequired",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PreRequired",
                table: "PreRequired",
                column: "Id");

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
                name: "IX_PreRequired_PreRequiredCourseId",
                table: "PreRequired",
                column: "PreRequiredCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_PreRequired_RequiredCourseId",
                table: "PreRequired",
                column: "RequiredCourseId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_PreRequired_Course_PreRequiredCourseId",
                table: "PreRequired",
                column: "PreRequiredCourseId",
                principalTable: "Course",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PreRequired_Course_RequiredCourseId",
                table: "PreRequired",
                column: "RequiredCourseId",
                principalTable: "Course",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PreRequired_Course_PreRequiredCourseId",
                table: "PreRequired");

            migrationBuilder.DropForeignKey(
                name: "FK_PreRequired_Course_RequiredCourseId",
                table: "PreRequired");

            migrationBuilder.DropTable(
                name: "TermCourse");

            migrationBuilder.DropTable(
                name: "Term");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PreRequired",
                table: "PreRequired");

            migrationBuilder.DropIndex(
                name: "IX_PreRequired_PreRequiredCourseId",
                table: "PreRequired");

            migrationBuilder.DropIndex(
                name: "IX_PreRequired_RequiredCourseId",
                table: "PreRequired");

            migrationBuilder.DropColumn(
                name: "PreRequiredCourseId",
                table: "PreRequired");

            migrationBuilder.DropColumn(
                name: "RequiredCourseId",
                table: "PreRequired");

            migrationBuilder.RenameTable(
                name: "PreRequired",
                newName: "PreRequireds");

            migrationBuilder.AddColumn<string>(
                name: "PreRequiredId",
                table: "Course",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PreRequireds",
                table: "PreRequireds",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Course_PreRequiredId",
                table: "Course",
                column: "PreRequiredId");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_PreRequireds_PreRequiredId",
                table: "Course",
                column: "PreRequiredId",
                principalTable: "PreRequireds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
