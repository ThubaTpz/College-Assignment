using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITP_SEM_2_ASS_1.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    AdminId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    homeAdress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "AdminId");
                });

            migrationBuilder.CreateTable(
                name: "lecturers",
                columns: table => new
                {
                    LecturerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    homeAdress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdminId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lecturers", x => x.LecturerId);
                    table.ForeignKey(
                        name: "FK_lecturers_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "AdminId");
                });

            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    credits = table.Column<int>(type: "int", nullable: false),
                    moduleCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modules_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "AdminId");
                });

            migrationBuilder.CreateTable(
                name: "CourseLecturer",
                columns: table => new
                {
                    CoursesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LecturesLecturerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseLecturer", x => new { x.CoursesId, x.LecturesLecturerId });
                    table.ForeignKey(
                        name: "FK_CourseLecturer_Courses_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseLecturer_lecturers_LecturesLecturerId",
                        column: x => x.LecturesLecturerId,
                        principalTable: "lecturers",
                        principalColumn: "LecturerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseModule",
                columns: table => new
                {
                    CoursesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    modulesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseModule", x => new { x.CoursesId, x.modulesId });
                    table.ForeignKey(
                        name: "FK_CourseModule_Courses_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseModule_Modules_modulesId",
                        column: x => x.modulesId,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LecturerModule",
                columns: table => new
                {
                    LecturersLecturerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModulesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LecturerModule", x => new { x.LecturersLecturerId, x.ModulesId });
                    table.ForeignKey(
                        name: "FK_LecturerModule_Modules_ModulesId",
                        column: x => x.ModulesId,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LecturerModule_lecturers_LecturersLecturerId",
                        column: x => x.LecturersLecturerId,
                        principalTable: "lecturers",
                        principalColumn: "LecturerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    homeAdress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdminId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModuleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Students_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "AdminId");
                    table.ForeignKey(
                        name: "FK_Students_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Students_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TaskItems",
                columns: table => new
                {
                    TaskItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dueDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModuleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskItems", x => x.TaskItemId);
                    table.ForeignKey(
                        name: "FK_TaskItems_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LecturerStudent",
                columns: table => new
                {
                    LecturersLecturerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentsStudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LecturerStudent", x => new { x.LecturersLecturerId, x.StudentsStudentId });
                    table.ForeignKey(
                        name: "FK_LecturerStudent_Students_StudentsStudentId",
                        column: x => x.StudentsStudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LecturerStudent_lecturers_LecturersLecturerId",
                        column: x => x.LecturersLecturerId,
                        principalTable: "lecturers",
                        principalColumn: "LecturerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LecturerTaskItem",
                columns: table => new
                {
                    LecturersLecturerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TasksTaskItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LecturerTaskItem", x => new { x.LecturersLecturerId, x.TasksTaskItemId });
                    table.ForeignKey(
                        name: "FK_LecturerTaskItem_TaskItems_TasksTaskItemId",
                        column: x => x.TasksTaskItemId,
                        principalTable: "TaskItems",
                        principalColumn: "TaskItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LecturerTaskItem_lecturers_LecturersLecturerId",
                        column: x => x.LecturersLecturerId,
                        principalTable: "lecturers",
                        principalColumn: "LecturerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentTaskItem",
                columns: table => new
                {
                    StudentsStudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TasksTaskItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTaskItem", x => new { x.StudentsStudentId, x.TasksTaskItemId });
                    table.ForeignKey(
                        name: "FK_StudentTaskItem_Students_StudentsStudentId",
                        column: x => x.StudentsStudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentTaskItem_TaskItems_TasksTaskItemId",
                        column: x => x.TasksTaskItemId,
                        principalTable: "TaskItems",
                        principalColumn: "TaskItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseLecturer_LecturesLecturerId",
                table: "CourseLecturer",
                column: "LecturesLecturerId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseModule_modulesId",
                table: "CourseModule",
                column: "modulesId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_AdminId",
                table: "Courses",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_LecturerModule_ModulesId",
                table: "LecturerModule",
                column: "ModulesId");

            migrationBuilder.CreateIndex(
                name: "IX_lecturers_AdminId",
                table: "lecturers",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_LecturerStudent_StudentsStudentId",
                table: "LecturerStudent",
                column: "StudentsStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_LecturerTaskItem_TasksTaskItemId",
                table: "LecturerTaskItem",
                column: "TasksTaskItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Modules_AdminId",
                table: "Modules",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_AdminId",
                table: "Students",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_CourseId",
                table: "Students",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ModuleId",
                table: "Students",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTaskItem_TasksTaskItemId",
                table: "StudentTaskItem",
                column: "TasksTaskItemId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskItems_ModuleId",
                table: "TaskItems",
                column: "ModuleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseLecturer");

            migrationBuilder.DropTable(
                name: "CourseModule");

            migrationBuilder.DropTable(
                name: "LecturerModule");

            migrationBuilder.DropTable(
                name: "LecturerStudent");

            migrationBuilder.DropTable(
                name: "LecturerTaskItem");

            migrationBuilder.DropTable(
                name: "StudentTaskItem");

            migrationBuilder.DropTable(
                name: "lecturers");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "TaskItems");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropTable(
                name: "Admins");
        }
    }
}
