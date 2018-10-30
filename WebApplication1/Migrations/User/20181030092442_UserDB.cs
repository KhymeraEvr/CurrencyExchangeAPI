using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations.User
{
    public partial class UserDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Converts",
                table: "Converts");

            migrationBuilder.RenameTable(
                name: "Converts",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Login");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Converts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Converts",
                table: "Converts",
                column: "Login");
        }
    }
}
