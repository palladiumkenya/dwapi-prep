using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dwapi.Prep.Infrastructure.Migrations
{
    public partial class AddedPrepMonthlyRefill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PrepMonthlyRefills",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RefId = table.Column<Guid>(nullable: true),
                    Created = table.Column<DateTime>(nullable: true),
                    PatientPk = table.Column<int>(nullable: false),
                    SiteCode = table.Column<int>(nullable: false),
                    Emr = table.Column<string>(nullable: true),
                    Project = table.Column<string>(nullable: true),
                    Processed = table.Column<bool>(nullable: true),
                    QueueId = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    StatusDate = table.Column<DateTime>(nullable: true),
                    DateExtracted = table.Column<DateTime>(nullable: true),
                    FacilityId = table.Column<Guid>(nullable: false),
                    FacilityName = table.Column<string>(nullable: true),
                    PrepNumber = table.Column<string>(nullable: true),
                    VisitDate = table.Column<string>(nullable: true),
                    BehaviorRiskAssessment = table.Column<string>(nullable: true),
                    SexPartnerHIVStatus = table.Column<string>(nullable: true),
                    SymptomsAcuteHIV = table.Column<string>(nullable: true),
                    AdherenceCounsellingDone = table.Column<string>(nullable: true),
                    ContraIndicationForPrEP = table.Column<string>(nullable: true),
                    PrescribedPrepToday = table.Column<string>(nullable: true),
                    RegimenPrescribed = table.Column<string>(nullable: true),
                    NumberOfMonths = table.Column<string>(nullable: true),
                    CondomsIssued = table.Column<string>(nullable: true),
                    NumberOfCondomsIssued = table.Column<int>(nullable: false),
                    ClientGivenNextAppointment = table.Column<string>(nullable: true),
                    AppointmentDate = table.Column<DateTime>(nullable: true),
                    ReasonForFailureToGiveAppointment = table.Column<string>(nullable: true),
                    DateOfLastPrepDose = table.Column<DateTime>(nullable: true),
                    RecordUUID = table.Column<string>(nullable: true),
                    Voided = table.Column<bool>(nullable: true),
                    Date_Created = table.Column<DateTime>(nullable: true),
                    Date_Last_Modified = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrepMonthlyRefills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrepMonthlyRefills_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PrepMonthlyRefills_FacilityId",
                table: "PrepMonthlyRefills",
                column: "FacilityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrepMonthlyRefills");
        }
    }
}
