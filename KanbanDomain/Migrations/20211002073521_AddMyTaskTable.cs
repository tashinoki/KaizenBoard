using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KanbanDomain.Migrations
{
    public partial class AddMyTaskTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_member_my_task_my_task_id",
                table: "member");

            migrationBuilder.DropForeignKey(
                name: "fk_my_task_kanbans_kanban_id",
                table: "my_task");

            migrationBuilder.DropForeignKey(
                name: "fk_task_timer_my_task_my_task_id",
                table: "task_timer");

            migrationBuilder.DropPrimaryKey(
                name: "pk_task_timer",
                table: "task_timer");

            migrationBuilder.DropPrimaryKey(
                name: "pk_my_task",
                table: "my_task");

            migrationBuilder.DropPrimaryKey(
                name: "pk_member",
                table: "member");

            migrationBuilder.RenameTable(
                name: "task_timer",
                newName: "task_timers");

            migrationBuilder.RenameTable(
                name: "my_task",
                newName: "my_tasks");

            migrationBuilder.RenameTable(
                name: "member",
                newName: "members");

            migrationBuilder.RenameIndex(
                name: "ix_task_timer_my_task_id",
                table: "task_timers",
                newName: "ix_task_timers_my_task_id");

            migrationBuilder.RenameIndex(
                name: "ix_my_task_kanban_id",
                table: "my_tasks",
                newName: "ix_my_tasks_kanban_id");

            migrationBuilder.RenameIndex(
                name: "ix_member_my_task_id",
                table: "members",
                newName: "ix_members_my_task_id");

            migrationBuilder.AddColumn<Guid>(
                name: "kanban_board_id",
                table: "kanbans",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "kanban_board_id",
                table: "members",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "pk_task_timers",
                table: "task_timers",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_my_tasks",
                table: "my_tasks",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_members",
                table: "members",
                column: "id");

            migrationBuilder.CreateTable(
                name: "kanban_boards",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_kanban_boards", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_kanbans_kanban_board_id",
                table: "kanbans",
                column: "kanban_board_id");

            migrationBuilder.CreateIndex(
                name: "ix_members_kanban_board_id",
                table: "members",
                column: "kanban_board_id");

            migrationBuilder.AddForeignKey(
                name: "fk_kanbans_kanban_boards_kanban_board_id",
                table: "kanbans",
                column: "kanban_board_id",
                principalTable: "kanban_boards",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_members_kanban_boards_kanban_board_id",
                table: "members",
                column: "kanban_board_id",
                principalTable: "kanban_boards",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_members_my_tasks_my_task_id",
                table: "members",
                column: "my_task_id",
                principalTable: "my_tasks",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_my_tasks_kanbans_kanban_id",
                table: "my_tasks",
                column: "kanban_id",
                principalTable: "kanbans",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_task_timers_my_tasks_my_task_id",
                table: "task_timers",
                column: "my_task_id",
                principalTable: "my_tasks",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_kanbans_kanban_boards_kanban_board_id",
                table: "kanbans");

            migrationBuilder.DropForeignKey(
                name: "fk_members_kanban_boards_kanban_board_id",
                table: "members");

            migrationBuilder.DropForeignKey(
                name: "fk_members_my_tasks_my_task_id",
                table: "members");

            migrationBuilder.DropForeignKey(
                name: "fk_my_tasks_kanbans_kanban_id",
                table: "my_tasks");

            migrationBuilder.DropForeignKey(
                name: "fk_task_timers_my_tasks_my_task_id",
                table: "task_timers");

            migrationBuilder.DropTable(
                name: "kanban_boards");

            migrationBuilder.DropIndex(
                name: "ix_kanbans_kanban_board_id",
                table: "kanbans");

            migrationBuilder.DropPrimaryKey(
                name: "pk_task_timers",
                table: "task_timers");

            migrationBuilder.DropPrimaryKey(
                name: "pk_my_tasks",
                table: "my_tasks");

            migrationBuilder.DropPrimaryKey(
                name: "pk_members",
                table: "members");

            migrationBuilder.DropIndex(
                name: "ix_members_kanban_board_id",
                table: "members");

            migrationBuilder.DropColumn(
                name: "kanban_board_id",
                table: "kanbans");

            migrationBuilder.DropColumn(
                name: "kanban_board_id",
                table: "members");

            migrationBuilder.RenameTable(
                name: "task_timers",
                newName: "task_timer");

            migrationBuilder.RenameTable(
                name: "my_tasks",
                newName: "my_task");

            migrationBuilder.RenameTable(
                name: "members",
                newName: "member");

            migrationBuilder.RenameIndex(
                name: "ix_task_timers_my_task_id",
                table: "task_timer",
                newName: "ix_task_timer_my_task_id");

            migrationBuilder.RenameIndex(
                name: "ix_my_tasks_kanban_id",
                table: "my_task",
                newName: "ix_my_task_kanban_id");

            migrationBuilder.RenameIndex(
                name: "ix_members_my_task_id",
                table: "member",
                newName: "ix_member_my_task_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_task_timer",
                table: "task_timer",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_my_task",
                table: "my_task",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_member",
                table: "member",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_member_my_task_my_task_id",
                table: "member",
                column: "my_task_id",
                principalTable: "my_task",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_my_task_kanbans_kanban_id",
                table: "my_task",
                column: "kanban_id",
                principalTable: "kanbans",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_task_timer_my_task_my_task_id",
                table: "task_timer",
                column: "my_task_id",
                principalTable: "my_task",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
