using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KanbanDomain.Migrations
{
    public partial class AddMemberProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_members_kanban_boards_kanban_board_id",
                table: "members");

            migrationBuilder.DropForeignKey(
                name: "fk_members_my_tasks_my_task_id",
                table: "members");

            migrationBuilder.DropIndex(
                name: "ix_members_kanban_board_id",
                table: "members");

            migrationBuilder.DropIndex(
                name: "ix_members_my_task_id",
                table: "members");

            migrationBuilder.AlterColumn<Guid>(
                name: "my_task_id",
                table: "members",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "kanban_board_id",
                table: "members",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "members",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "member_id",
                table: "members",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "kanban_board_member",
                columns: table => new
                {
                    kanban_boards_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    members_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_kanban_board_member", x => new { x.kanban_boards_id, x.members_id });
                    table.ForeignKey(
                        name: "fk_kanban_board_member_kanban_boards_kanban_boards_id",
                        column: x => x.kanban_boards_id,
                        principalTable: "kanban_boards",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_kanban_board_member_members_members_id",
                        column: x => x.members_id,
                        principalTable: "members",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "member_my_task",
                columns: table => new
                {
                    members_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    my_tasks_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_member_my_task", x => new { x.members_id, x.my_tasks_id });
                    table.ForeignKey(
                        name: "fk_member_my_task_members_members_id",
                        column: x => x.members_id,
                        principalTable: "members",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_member_my_task_my_tasks_my_tasks_id",
                        column: x => x.my_tasks_id,
                        principalTable: "my_tasks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_kanban_board_member_members_id",
                table: "kanban_board_member",
                column: "members_id");

            migrationBuilder.CreateIndex(
                name: "ix_member_my_task_my_tasks_id",
                table: "member_my_task",
                column: "my_tasks_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "kanban_board_member");

            migrationBuilder.DropTable(
                name: "member_my_task");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "members");

            migrationBuilder.DropColumn(
                name: "member_id",
                table: "members");

            migrationBuilder.AlterColumn<Guid>(
                name: "my_task_id",
                table: "members",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "kanban_board_id",
                table: "members",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "ix_members_kanban_board_id",
                table: "members",
                column: "kanban_board_id");

            migrationBuilder.CreateIndex(
                name: "ix_members_my_task_id",
                table: "members",
                column: "my_task_id");

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
        }
    }
}
