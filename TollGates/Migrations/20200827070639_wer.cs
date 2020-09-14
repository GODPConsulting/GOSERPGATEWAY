using Microsoft.EntityFrameworkCore.Migrations;

namespace TollGates.Migrations
{
    public partial class wer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ScrewIdentifierGrid",
                columns: table => new
                {
                    ScrewIdentifierGridId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Notifier = table.Column<int>(nullable: false),
                    Module = table.Column<int>(nullable: false),
                    ActiveOnMobileApp = table.Column<bool>(nullable: false),
                    ActiveOnWebApp = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScrewIdentifierGrid", x => x.ScrewIdentifierGridId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScrewIdentifierGrid");
        }
    }
}
