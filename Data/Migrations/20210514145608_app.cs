using Microsoft.EntityFrameworkCore.Migrations;

namespace UJTUT.Data.Migrations
{
    public partial class app : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Tutor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Tutor",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
