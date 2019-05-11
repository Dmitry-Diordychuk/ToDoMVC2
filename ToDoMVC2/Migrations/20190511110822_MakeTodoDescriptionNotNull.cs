using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoMVC2.Migrations
{
    public partial class MakeTodoDescriptionNotNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Todos",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Todos",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
