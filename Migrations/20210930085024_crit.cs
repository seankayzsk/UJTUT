using Microsoft.EntityFrameworkCore.Migrations;



namespace UJTUT.Migrations
{
    public partial class crit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RateCriteria",
                table: "Tutor",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RateCriteria",
                table: "Tutor");
        }
    }
}
