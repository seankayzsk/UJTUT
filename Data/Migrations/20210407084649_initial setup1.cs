using Microsoft.EntityFrameworkCore.Migrations;

namespace UJTUT.Data.Migrations
{
    public partial class initialsetup1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "price",
                table: "Tutor",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "price",
                table: "Tutor");
        }
    }
}
