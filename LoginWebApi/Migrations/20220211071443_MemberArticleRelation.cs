using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoginWebApi.Migrations
{
    public partial class MemberArticleRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MemberID",
                table: "Articles",
                newName: "MemberId");

            migrationBuilder.AlterColumn<int>(
                name: "MemberId",
                table: "Articles",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "MemberID",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_MemberId",
                table: "Articles",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Members_MemberId",
                table: "Articles",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "MemberId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Members_MemberId",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_MemberId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "MemberID",
                table: "Articles");

            migrationBuilder.RenameColumn(
                name: "MemberId",
                table: "Articles",
                newName: "MemberID");

            migrationBuilder.AlterColumn<string>(
                name: "MemberID",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
