using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Amizade.Infrastructure.Data.Migrations
{
    public partial class AddColumnLastView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UltimaVisualizacao",
                table: "Amigo",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UltimaVisualizacao",
                table: "Amigo");
        }
    }
}
