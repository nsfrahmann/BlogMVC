using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogMVC.Data.Migrations
{
    public partial class namechange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "Blog");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Blog",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Blog");

            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "Blog",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
