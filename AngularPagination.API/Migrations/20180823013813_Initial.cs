using Microsoft.EntityFrameworkCore.Migrations;

namespace AngularPagination.API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recipients",
                columns: table => new
                {
                    RecipientId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RecipientName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    IsValid = table.Column<bool>(nullable: false),
                    Unsubscribe = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipients", x => x.RecipientId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recipients");
        }
    }
}
