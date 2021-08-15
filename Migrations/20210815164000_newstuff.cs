using Microsoft.EntityFrameworkCore.Migrations;

namespace UJTUT.Migrations
{
    public partial class newstuff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "Tutor",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "password",
                table: "Tutor");
        }
    }
}
