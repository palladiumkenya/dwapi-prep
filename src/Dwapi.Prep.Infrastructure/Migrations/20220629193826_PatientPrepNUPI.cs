using Microsoft.EntityFrameworkCore.Migrations;

namespace Dwapi.Prep.Infrastructure.Migrations
{
    public partial class PatientPrepNUPI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NUPI",
                table: "PrepPatients",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NUPI",
                table: "PrepPatients");
        }
    }
}
