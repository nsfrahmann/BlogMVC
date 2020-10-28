using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogMVC.Data.Migrations
{
    public partial class postcount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PostTotal",
                table: "Blog",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostTotal",
                table: "Blog");
        }
    }
}
