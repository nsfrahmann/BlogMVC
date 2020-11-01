using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogMVC.Migrations
{
    public partial class moderate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ModerateId",
                table: "SubComment",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModerateId",
                table: "Post",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModerateId",
                table: "Comment",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Moderate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moderate", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubComment_ModerateId",
                table: "SubComment",
                column: "ModerateId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_ModerateId",
                table: "Post",
                column: "ModerateId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ModerateId",
                table: "Comment",
                column: "ModerateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Moderate_ModerateId",
                table: "Comment",
                column: "ModerateId",
                principalTable: "Moderate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Moderate_ModerateId",
                table: "Post",
                column: "ModerateId",
                principalTable: "Moderate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubComment_Moderate_ModerateId",
                table: "SubComment",
                column: "ModerateId",
                principalTable: "Moderate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Moderate_ModerateId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_Moderate_ModerateId",
                table: "Post");

            migrationBuilder.DropForeignKey(
                name: "FK_SubComment_Moderate_ModerateId",
                table: "SubComment");

            migrationBuilder.DropTable(
                name: "Moderate");

            migrationBuilder.DropIndex(
                name: "IX_SubComment_ModerateId",
                table: "SubComment");

            migrationBuilder.DropIndex(
                name: "IX_Post_ModerateId",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Comment_ModerateId",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "ModerateId",
                table: "SubComment");

            migrationBuilder.DropColumn(
                name: "ModerateId",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "ModerateId",
                table: "Comment");
        }
    }
}
