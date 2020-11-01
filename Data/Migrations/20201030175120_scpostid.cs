using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogMVC.Migrations
{
    public partial class scpostid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubComment_Post_PostId",
                table: "SubComment");

            migrationBuilder.AlterColumn<int>(
                name: "PostId",
                table: "SubComment",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SubComment_Post_PostId",
                table: "SubComment",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubComment_Post_PostId",
                table: "SubComment");

            migrationBuilder.AlterColumn<int>(
                name: "PostId",
                table: "SubComment",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_SubComment_Post_PostId",
                table: "SubComment",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
