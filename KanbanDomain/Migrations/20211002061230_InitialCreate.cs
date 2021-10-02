using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KanbanDomain.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "kanbans",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    board_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sequence = table.Column<int>(type: "int", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_kanbans", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "my_task",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    kanban_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_my_task", x => x.id);
                    table.ForeignKey(
                        name: "fk_my_task_kanbans_kanban_id",
                        column: x => x.kanban_id,
                        principalTable: "kanbans",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "member",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    handle_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    my_task_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_member", x => x.id);
                    table.ForeignKey(
                        name: "fk_member_my_task_my_task_id",
                        column: x => x.my_task_id,
                        principalTable: "my_task",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "task_timer",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    started_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    finished_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    is_finised = table.Column<bool>(type: "bit", nullable: false),
                    my_task_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_task_timer", x => x.id);
                    table.ForeignKey(
                        name: "fk_task_timer_my_task_my_task_id",
                        column: x => x.my_task_id,
                        principalTable: "my_task",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_member_my_task_id",
                table: "member",
                column: "my_task_id");

            migrationBuilder.CreateIndex(
                name: "ix_my_task_kanban_id",
                table: "my_task",
                column: "kanban_id");

            migrationBuilder.CreateIndex(
                name: "ix_task_timer_my_task_id",
                table: "task_timer",
                column: "my_task_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "member");

            migrationBuilder.DropTable(
                name: "task_timer");

            migrationBuilder.DropTable(
                name: "my_task");

            migrationBuilder.DropTable(
                name: "kanbans");
        }
    }
}
