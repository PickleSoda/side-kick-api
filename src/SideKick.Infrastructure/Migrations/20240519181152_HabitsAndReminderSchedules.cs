using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SideKick.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class HabitsAndReminderSchedules : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CommitmentId",
                table: "Reminders",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Habits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    ReminderIds = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReminderSchedules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TextTemplate = table.Column<string>(type: "TEXT", nullable: false),
                    Time = table.Column<TimeOnly>(type: "TEXT", nullable: false),
                    RequiresConfirmation = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    HabitId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ReminderType = table.Column<int>(type: "INTEGER", nullable: false),
                    Priority = table.Column<int>(type: "INTEGER", nullable: false),
                    DayIndex = table.Column<int>(type: "INTEGER", nullable: false),
                    Mon = table.Column<bool>(type: "INTEGER", nullable: false),
                    Tue = table.Column<bool>(type: "INTEGER", nullable: false),
                    Wed = table.Column<bool>(type: "INTEGER", nullable: false),
                    Thu = table.Column<bool>(type: "INTEGER", nullable: false),
                    Fri = table.Column<bool>(type: "INTEGER", nullable: false),
                    Sat = table.Column<bool>(type: "INTEGER", nullable: false),
                    Sun = table.Column<bool>(type: "INTEGER", nullable: false),
                    DayOfCommitment = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReminderSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReminderSchedules_Habits_HabitId",
                        column: x => x.HabitId,
                        principalTable: "Habits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReminderSchedules_HabitId",
                table: "ReminderSchedules",
                column: "HabitId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReminderSchedules");

            migrationBuilder.DropTable(
                name: "Habits");

            migrationBuilder.DropColumn(
                name: "CommitmentId",
                table: "Reminders");
        }
    }
}
