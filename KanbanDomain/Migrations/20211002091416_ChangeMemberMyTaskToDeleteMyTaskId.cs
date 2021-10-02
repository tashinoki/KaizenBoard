using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KanbanDomain.Migrations
{
    public partial class ChangeMemberMyTaskToDeleteMyTaskId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "kanban_board_id",
                table: "members");

            migrationBuilder.DropColumn(
                name: "my_task_id",
                table: "members");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "kanban_board_id",
                table: "members",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "my_task_id",
                table: "members",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
