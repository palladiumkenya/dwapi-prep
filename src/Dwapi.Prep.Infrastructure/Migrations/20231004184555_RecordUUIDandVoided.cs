using Microsoft.EntityFrameworkCore.Migrations;

namespace Dwapi.Prep.Infrastructure.Migrations
{
    public partial class RecordUUIDandVoided : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RecordUUID",
                table: "PrepVisits",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Voided",
                table: "PrepVisits",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecordUUID",
                table: "PrepPharmacys",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Voided",
                table: "PrepPharmacys",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecordUUID",
                table: "PrepPatients",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Voided",
                table: "PrepPatients",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecordUUID",
                table: "PrepLabs",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Voided",
                table: "PrepLabs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecordUUID",
                table: "PrepCareTerminations",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Voided",
                table: "PrepCareTerminations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecordUUID",
                table: "PrepBehaviourRisks",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Voided",
                table: "PrepBehaviourRisks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecordUUID",
                table: "PrepAdverseEvents",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Voided",
                table: "PrepAdverseEvents",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecordUUID",
                table: "PrepVisits");

            migrationBuilder.DropColumn(
                name: "Voided",
                table: "PrepVisits");

            migrationBuilder.DropColumn(
                name: "RecordUUID",
                table: "PrepPharmacys");

            migrationBuilder.DropColumn(
                name: "Voided",
                table: "PrepPharmacys");

            migrationBuilder.DropColumn(
                name: "RecordUUID",
                table: "PrepPatients");

            migrationBuilder.DropColumn(
                name: "Voided",
                table: "PrepPatients");

            migrationBuilder.DropColumn(
                name: "RecordUUID",
                table: "PrepLabs");

            migrationBuilder.DropColumn(
                name: "Voided",
                table: "PrepLabs");

            migrationBuilder.DropColumn(
                name: "RecordUUID",
                table: "PrepCareTerminations");

            migrationBuilder.DropColumn(
                name: "Voided",
                table: "PrepCareTerminations");

            migrationBuilder.DropColumn(
                name: "RecordUUID",
                table: "PrepBehaviourRisks");

            migrationBuilder.DropColumn(
                name: "Voided",
                table: "PrepBehaviourRisks");

            migrationBuilder.DropColumn(
                name: "RecordUUID",
                table: "PrepAdverseEvents");

            migrationBuilder.DropColumn(
                name: "Voided",
                table: "PrepAdverseEvents");
        }
    }
}
