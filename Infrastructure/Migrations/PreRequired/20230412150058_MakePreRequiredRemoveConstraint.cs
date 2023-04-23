using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations.PreRequired
{
    /// <inheritdoc />
    public partial class MakePreRequiredRemoveConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UnitCount = table.Column<int>(type: "int", nullable: false),
                    CourseNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseType = table.Column<int>(type: "int", nullable: false),
                    TimeStamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PreRequired",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RequiredCourseId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PreRequiredCourseId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TimeStamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreRequired", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PreRequired_Course_PreRequiredCourseId",
                        column: x => x.PreRequiredCourseId,
                        principalTable: "Course",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PreRequired_Course_RequiredCourseId",
                        column: x => x.RequiredCourseId,
                        principalTable: "Course",
                        principalColumn: "Id");
                });


            migrationBuilder.CreateIndex(
                name: "IX_Course_CourseNo",
                table: "Course",
                column: "CourseNo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PreRequired_PreRequiredCourseId",
                table: "PreRequired",
                column: "PreRequiredCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_PreRequired_RequiredCourseId",
                table: "PreRequired",
                column: "RequiredCourseId");


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PreRequired");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
