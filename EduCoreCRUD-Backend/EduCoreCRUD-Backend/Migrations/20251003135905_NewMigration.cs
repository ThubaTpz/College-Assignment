using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduCoreCRUD_Backend.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "admin",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    HomeAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "course",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_course", x => x.Id);
                    table.ForeignKey(
                        name: "FK_course_admin_AdminId",
                        column: x => x.AdminId,
                        principalTable: "admin",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "lecturer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    HomeAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdminId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lecturer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_lecturer_admin_AdminId",
                        column: x => x.AdminId,
                        principalTable: "admin",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "module",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Credits = table.Column<int>(type: "int", nullable: false),
                    ModuleCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_module", x => x.Id);
                    table.ForeignKey(
                        name: "FK_module_admin_AdminId",
                        column: x => x.AdminId,
                        principalTable: "admin",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CourseLecturer",
                columns: table => new
                {
                    CoursesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LecturersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseLecturer", x => new { x.CoursesId, x.LecturersId });
                    table.ForeignKey(
                        name: "FK_CourseLecturer_course_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseLecturer_lecturer_LecturersId",
                        column: x => x.LecturersId,
                        principalTable: "lecturer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseModule",
                columns: table => new
                {
                    CoursesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModulesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseModule", x => new { x.CoursesId, x.ModulesId });
                    table.ForeignKey(
                        name: "FK_CourseModule_course_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseModule_module_ModulesId",
                        column: x => x.ModulesId,
                        principalTable: "module",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LecturerModule",
                columns: table => new
                {
                    LecturersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModulesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LecturerModule", x => new { x.LecturersId, x.ModulesId });
                    table.ForeignKey(
                        name: "FK_LecturerModule_lecturer_LecturersId",
                        column: x => x.LecturersId,
                        principalTable: "lecturer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LecturerModule_module_ModulesId",
                        column: x => x.ModulesId,
                        principalTable: "module",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "student",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    HomeAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdminId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModuleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_student_admin_AdminId",
                        column: x => x.AdminId,
                        principalTable: "admin",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_student_course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "course",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_student_module_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "module",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "taskItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DueDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModuleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taskItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_taskItem_module_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "module",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LecturerStudent",
                columns: table => new
                {
                    LecturersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LecturerStudent", x => new { x.LecturersId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_LecturerStudent_lecturer_LecturersId",
                        column: x => x.LecturersId,
                        principalTable: "lecturer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LecturerStudent_student_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LecturerTaskItem",
                columns: table => new
                {
                    LecturersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TasksId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LecturerTaskItem", x => new { x.LecturersId, x.TasksId });
                    table.ForeignKey(
                        name: "FK_LecturerTaskItem_lecturer_LecturersId",
                        column: x => x.LecturersId,
                        principalTable: "lecturer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LecturerTaskItem_taskItem_TasksId",
                        column: x => x.TasksId,
                        principalTable: "taskItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentTaskItem",
                columns: table => new
                {
                    StudentsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TasksId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTaskItem", x => new { x.StudentsId, x.TasksId });
                    table.ForeignKey(
                        name: "FK_StudentTaskItem_student_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentTaskItem_taskItem_TasksId",
                        column: x => x.TasksId,
                        principalTable: "taskItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_course_AdminId",
                table: "course",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseLecturer_LecturersId",
                table: "CourseLecturer",
                column: "LecturersId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseModule_ModulesId",
                table: "CourseModule",
                column: "ModulesId");

            migrationBuilder.CreateIndex(
                name: "IX_lecturer_AdminId",
                table: "lecturer",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_LecturerModule_ModulesId",
                table: "LecturerModule",
                column: "ModulesId");

            migrationBuilder.CreateIndex(
                name: "IX_LecturerStudent_StudentsId",
                table: "LecturerStudent",
                column: "StudentsId");

            migrationBuilder.CreateIndex(
                name: "IX_LecturerTaskItem_TasksId",
                table: "LecturerTaskItem",
                column: "TasksId");

            migrationBuilder.CreateIndex(
                name: "IX_module_AdminId",
                table: "module",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_student_AdminId",
                table: "student",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_student_CourseId",
                table: "student",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_student_ModuleId",
                table: "student",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTaskItem_TasksId",
                table: "StudentTaskItem",
                column: "TasksId");

            migrationBuilder.CreateIndex(
                name: "IX_taskItem_ModuleId",
                table: "taskItem",
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
                name: "lecturer");

            migrationBuilder.DropTable(
                name: "student");

            migrationBuilder.DropTable(
                name: "taskItem");

            migrationBuilder.DropTable(
                name: "course");

            migrationBuilder.DropTable(
                name: "module");

            migrationBuilder.DropTable(
                name: "admin");
        }
    }
}
