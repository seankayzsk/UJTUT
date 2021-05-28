using Microsoft.EntityFrameworkCore.Migrations;

namespace UJTUT.Data.Migrations
{
    public partial class initialsetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tutor",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tutor_name = table.Column<string>(nullable: true),
                    Modules = table.Column<string>(nullable: true),
                    bio = table.Column<string>(nullable: true),
                    cell = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    price = table.Column<string>(nullable: true),

                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tutor", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tutor");
        }
    }
}
