using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnesCentar.Data.Migrations
{
    /// <inheritdoc />
    public partial class migrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "FitnesInstructors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FitnesInstructors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProgramCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProgramTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramNumber = table.Column<int>(type: "int", nullable: false),
                    ProgramCAategoriesId = table.Column<int>(type: "int", nullable: false),
                    ProgramCategoriesId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,3)", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgramTasks_ProgramCategories_ProgramCategoriesId",
                        column: x => x.ProgramCategoriesId,
                        principalTable: "ProgramCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleActivities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityNumber = table.Column<int>(type: "int", nullable: false),
                    ProgramTasksId = table.Column<int>(type: "int", nullable: false),
                    FitnesInstructorId = table.Column<int>(type: "int", nullable: false),
                    WeekDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StarHour = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndHour = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleActivities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduleActivities_FitnesInstructors_FitnesInstructorId",
                        column: x => x.FitnesInstructorId,
                        principalTable: "FitnesInstructors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScheduleActivities_ProgramTasks_ProgramTasksId",
                        column: x => x.ProgramTasksId,
                        principalTable: "ProgramTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScheduleActivitiesId = table.Column<int>(type: "int", nullable: false),
                    ClientsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_AspNetUsers_ClientsId",
                        column: x => x.ClientsId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_ScheduleActivities_ScheduleActivitiesId",
                        column: x => x.ScheduleActivitiesId,
                        principalTable: "ScheduleActivities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProgramTasks_ProgramCategoriesId",
                table: "ProgramTasks",
                column: "ProgramCategoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ClientsId",
                table: "Reservations",
                column: "ClientsId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ScheduleActivitiesId",
                table: "Reservations",
                column: "ScheduleActivitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleActivities_FitnesInstructorId",
                table: "ScheduleActivities",
                column: "FitnesInstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleActivities_ProgramTasksId",
                table: "ScheduleActivities",
                column: "ProgramTasksId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "ScheduleActivities");

            migrationBuilder.DropTable(
                name: "FitnesInstructors");

            migrationBuilder.DropTable(
                name: "ProgramTasks");

            migrationBuilder.DropTable(
                name: "ProgramCategories");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");
        }
    }
}
