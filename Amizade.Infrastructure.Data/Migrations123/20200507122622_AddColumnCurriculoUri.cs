using Microsoft.EntityFrameworkCore.Migrations;

namespace Amizade.Infrastructure.Data.Migrations
{
    public partial class AddColumnCurriculoUri : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CurriculoUri",
                table: "Amigo",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurriculoUri",
                table: "Amigo");
        }
    }
}
