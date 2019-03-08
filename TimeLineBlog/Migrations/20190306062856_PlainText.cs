using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeLineBlog.Migrations
{
    public partial class PlainText : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PlainContent",
                table: "Article",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlainContent",
                table: "Article");
        }
    }
}
