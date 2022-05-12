using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HungryHelper.Data.Migrations
{
    public partial class AddUsernamePasswordColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "UserProfile",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "UserProfile",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "UserProfile");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "UserProfile");
        }
    }
}
