using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class Moreinfoaboutconverts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "From",
                table: "Converts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Into",
                table: "Converts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "From",
                table: "Converts");

            migrationBuilder.DropColumn(
                name: "Into",
                table: "Converts");
        }
    }
}
