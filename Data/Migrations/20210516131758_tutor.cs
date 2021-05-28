using Microsoft.EntityFrameworkCore.Migrations;

namespace UJTUT.Data.Migrations
{
    public partial class tutor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "pic_name",
                table: "Tutor",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pic_name",
                table: "Tutor");
        }
    }
}
