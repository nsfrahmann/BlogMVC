using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogMVC.Migrations
{
    public partial class moresubcomment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubComment_Comment_CommentId",
                table: "SubComment");

            migrationBuilder.AlterColumn<int>(
                name: "CommentId",
                table: "SubComment",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SubComment_Comment_CommentId",
                table: "SubComment",
                column: "CommentId",
                principalTable: "Comment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubComment_Comment_CommentId",
                table: "SubComment");

            migrationBuilder.AlterColumn<int>(
                name: "CommentId",
                table: "SubComment",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_SubComment_Comment_CommentId",
                table: "SubComment",
                column: "CommentId",
                principalTable: "Comment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
