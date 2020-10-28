using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogMVC.Data.Migrations
{
    public partial class blogimage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Blog",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Blog",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Blog");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Blog");
        }
    }
}
