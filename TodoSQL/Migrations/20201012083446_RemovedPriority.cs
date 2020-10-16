using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoSqlCodeFirst.Migrations
{
    public partial class RemovedPriority : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Priority",
                table: "ToDos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "ToDos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
