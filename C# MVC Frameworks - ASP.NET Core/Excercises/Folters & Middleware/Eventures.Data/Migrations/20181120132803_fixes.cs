using Microsoft.EntityFrameworkCore.Migrations;

namespace Eventures.Data.Migrations
{
    public partial class fixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);
        }
    }
}
