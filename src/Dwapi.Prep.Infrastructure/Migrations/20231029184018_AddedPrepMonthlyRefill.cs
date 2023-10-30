using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dwapi.Prep.Infrastructure.Migrations
{
    public partial class AddedPrepMonthlyRefill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrepMonthlyRefill_Facilities_FacilityId",
                table: "PrepMonthlyRefill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PrepMonthlyRefill",
                table: "PrepMonthlyRefill");

            migrationBuilder.DropColumn(
                name: "AdherenceDone",
                table: "PrepMonthlyRefill");

            migrationBuilder.DropColumn(
                name: "AdherenceOutcome",
                table: "PrepMonthlyRefill");

            migrationBuilder.DropColumn(
                name: "AdherenceReasons",
                table: "PrepMonthlyRefill");

            migrationBuilder.DropColumn(
                name: "BMI",
                table: "PrepMonthlyRefill");

            migrationBuilder.DropColumn(
                name: "BirthDefects",
                table: "PrepMonthlyRefill");

            migrationBuilder.DropColumn(
                name: "BloodPressure",
                table: "PrepMonthlyRefill");

            migrationBuilder.DropColumn(
                name: "Breastfeeding",
                table: "PrepMonthlyRefill");

            migrationBuilder.DropColumn(
                name: "Circumcised",
                table: "PrepMonthlyRefill");

            migrationBuilder.DropColumn(
                name: "ClinicalNotes",
                table: "PrepMonthlyRefill");

            migrationBuilder.DropColumn(
                name: "ContraindicationsPrep",
                table: "PrepMonthlyRefill");

            migrationBuilder.DropColumn(
                name: "EDD",
                table: "PrepMonthlyRefill");

            migrationBuilder.DropColumn(
                name: "EncounterId",
                table: "PrepMonthlyRefill");

            migrationBuilder.DropColumn(
                name: "FPMethods",
                table: "PrepMonthlyRefill");

            migrationBuilder.DropColumn(
                name: "FamilyPlanningStatus",
                table: "PrepMonthlyRefill");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "PrepMonthlyRefill");

            migrationBuilder.DropColumn(
                name: "HepatitisBPositiveResult",
                table: "PrepMonthlyRefill");

            migrationBuilder.DropColumn(
                name: "HepatitisCPositiveResult",
                table: "PrepMonthlyRefill");

            migrationBuilder.DropColumn(
                name: "HtsNumber",
                table: "PrepMonthlyRefill");

            migrationBuilder.DropColumn(
                name: "LMP",
                table: "PrepMonthlyRefill");

            migrationBuilder.DropColumn(
                name: "MenopausalStatus",
                table: "PrepMonthlyRefill");

            migrationBuilder.DropColumn(
                name: "MonthsPrescribed",
                table: "PrepMonthlyRefill");

            migrationBuilder.DropColumn(
                name: "NextAppointment",
                table: "PrepMonthlyRefill");

            migrationBuilder.DropColumn(
                name: "PlanningToGetPregnant",
                table: "PrepMonthlyRefill");

            migrationBuilder.DropColumn(
                name: "PregnancyEndDate",
                table: "PrepMonthlyRefill");

            migrationBuilder.DropColumn(
                name: "PregnancyEnded",
                table: "PrepMonthlyRefill");

            migrationBuilder.DropColumn(
                name: "PregnancyOutcome",
                table: "PrepMonthlyRefill");

            migrationBuilder.DropColumn(
                name: "PregnancyPlanned",
                table: "PrepMonthlyRefill");

            migrationBuilder.DropColumn(
                name: "PregnantAtThisVisit",
                table: "PrepMonthlyRefill");

            migrationBuilder.DropColumn(
                name: "PrepPrescribed",
                table: "PrepMonthlyRefill");

            migrationBuilder.DropColumn(
                name: "PrepTreatmentPlan",
                table: "PrepMonthlyRefill");

            migrationBuilder.DropColumn(
                name: "Reasonfornotgivingnextappointment",
                table: "PrepMonthlyRefill");

            migrationBuilder.DropColumn(
                name: "STIScreening",
                table: "PrepMonthlyRefill");

            migrationBuilder.DropColumn(
                name: "STISymptoms",
                table: "PrepMonthlyRefill");

            migrationBuilder.DropColumn(
                name: "STITreated",
                table: "PrepMonthlyRefill");

            migrationBuilder.DropColumn(
                name: "Temperature",
                table: "PrepMonthlyRefill");

            migrationBuilder.DropColumn(
                name: "Tobegivennextappointment",
                table: "PrepMonthlyRefill");

            migrationBuilder.DropColumn(
                name: "TreatedForHepB",
                table: "PrepMonthlyRefill");

            migrationBuilder.DropColumn(
                name: "TreatedForHepC",
                table: "PrepMonthlyRefill");

            migrationBuilder.DropColumn(
                name: "VMMCReferral",
                table: "PrepMonthlyRefill");

            migrationBuilder.DropColumn(
                name: "VaccinationForHepBStarted",
                table: "PrepMonthlyRefill");

            migrationBuilder.DropColumn(
                name: "VaccinationForHepCStarted",
                table: "PrepMonthlyRefill");

            migrationBuilder.DropColumn(
                name: "VisitID",
                table: "PrepMonthlyRefill");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "PrepMonthlyRefill");

            migrationBuilder.RenameTable(
                name: "PrepMonthlyRefill",
                newName: "PrepMonthlyRefills");

            migrationBuilder.RenameIndex(
                name: "IX_PrepMonthlyRefill_FacilityId",
                table: "PrepMonthlyRefills",
                newName: "IX_PrepMonthlyRefills_FacilityId");

            migrationBuilder.AlterColumn<string>(
                name: "VisitDate",
                table: "PrepMonthlyRefills",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdherenceCounsellingDone",
                table: "PrepMonthlyRefills",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AppointmentDate",
                table: "PrepMonthlyRefills",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BehaviorRiskAssessment",
                table: "PrepMonthlyRefills",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClientGivenNextAppointment",
                table: "PrepMonthlyRefills",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContraIndicationForPrEP",
                table: "PrepMonthlyRefills",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfLastPrepDose",
                table: "PrepMonthlyRefills",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfCondomsIssued",
                table: "PrepMonthlyRefills",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NumberOfMonths",
                table: "PrepMonthlyRefills",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrescribedPrepToday",
                table: "PrepMonthlyRefills",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReasonForFailureToGiveAppointment",
                table: "PrepMonthlyRefills",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SexPartnerHIVStatus",
                table: "PrepMonthlyRefills",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PrepMonthlyRefills",
                table: "PrepMonthlyRefills",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PrepMonthlyRefills_Facilities_FacilityId",
                table: "PrepMonthlyRefills",
                column: "FacilityId",
                principalTable: "Facilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrepMonthlyRefills_Facilities_FacilityId",
                table: "PrepMonthlyRefills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PrepMonthlyRefills",
                table: "PrepMonthlyRefills");

            migrationBuilder.DropColumn(
                name: "AdherenceCounsellingDone",
                table: "PrepMonthlyRefills");

            migrationBuilder.DropColumn(
                name: "AppointmentDate",
                table: "PrepMonthlyRefills");

            migrationBuilder.DropColumn(
                name: "BehaviorRiskAssessment",
                table: "PrepMonthlyRefills");

            migrationBuilder.DropColumn(
                name: "ClientGivenNextAppointment",
                table: "PrepMonthlyRefills");

            migrationBuilder.DropColumn(
                name: "ContraIndicationForPrEP",
                table: "PrepMonthlyRefills");

            migrationBuilder.DropColumn(
                name: "DateOfLastPrepDose",
                table: "PrepMonthlyRefills");

            migrationBuilder.DropColumn(
                name: "NumberOfCondomsIssued",
                table: "PrepMonthlyRefills");

            migrationBuilder.DropColumn(
                name: "NumberOfMonths",
                table: "PrepMonthlyRefills");

            migrationBuilder.DropColumn(
                name: "PrescribedPrepToday",
                table: "PrepMonthlyRefills");

            migrationBuilder.DropColumn(
                name: "ReasonForFailureToGiveAppointment",
                table: "PrepMonthlyRefills");

            migrationBuilder.DropColumn(
                name: "SexPartnerHIVStatus",
                table: "PrepMonthlyRefills");

            migrationBuilder.RenameTable(
                name: "PrepMonthlyRefills",
                newName: "PrepMonthlyRefill");

            migrationBuilder.RenameIndex(
                name: "IX_PrepMonthlyRefills_FacilityId",
                table: "PrepMonthlyRefill",
                newName: "IX_PrepMonthlyRefill_FacilityId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "VisitDate",
                table: "PrepMonthlyRefill",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdherenceDone",
                table: "PrepMonthlyRefill",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdherenceOutcome",
                table: "PrepMonthlyRefill",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdherenceReasons",
                table: "PrepMonthlyRefill",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "BMI",
                table: "PrepMonthlyRefill",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BirthDefects",
                table: "PrepMonthlyRefill",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BloodPressure",
                table: "PrepMonthlyRefill",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Breastfeeding",
                table: "PrepMonthlyRefill",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Circumcised",
                table: "PrepMonthlyRefill",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClinicalNotes",
                table: "PrepMonthlyRefill",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContraindicationsPrep",
                table: "PrepMonthlyRefill",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EDD",
                table: "PrepMonthlyRefill",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EncounterId",
                table: "PrepMonthlyRefill",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FPMethods",
                table: "PrepMonthlyRefill",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FamilyPlanningStatus",
                table: "PrepMonthlyRefill",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Height",
                table: "PrepMonthlyRefill",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HepatitisBPositiveResult",
                table: "PrepMonthlyRefill",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HepatitisCPositiveResult",
                table: "PrepMonthlyRefill",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HtsNumber",
                table: "PrepMonthlyRefill",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LMP",
                table: "PrepMonthlyRefill",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MenopausalStatus",
                table: "PrepMonthlyRefill",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MonthsPrescribed",
                table: "PrepMonthlyRefill",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NextAppointment",
                table: "PrepMonthlyRefill",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlanningToGetPregnant",
                table: "PrepMonthlyRefill",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PregnancyEndDate",
                table: "PrepMonthlyRefill",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PregnancyEnded",
                table: "PrepMonthlyRefill",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PregnancyOutcome",
                table: "PrepMonthlyRefill",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PregnancyPlanned",
                table: "PrepMonthlyRefill",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PregnantAtThisVisit",
                table: "PrepMonthlyRefill",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrepPrescribed",
                table: "PrepMonthlyRefill",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrepTreatmentPlan",
                table: "PrepMonthlyRefill",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Reasonfornotgivingnextappointment",
                table: "PrepMonthlyRefill",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "STIScreening",
                table: "PrepMonthlyRefill",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "STISymptoms",
                table: "PrepMonthlyRefill",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "STITreated",
                table: "PrepMonthlyRefill",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Temperature",
                table: "PrepMonthlyRefill",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tobegivennextappointment",
                table: "PrepMonthlyRefill",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TreatedForHepB",
                table: "PrepMonthlyRefill",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TreatedForHepC",
                table: "PrepMonthlyRefill",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VMMCReferral",
                table: "PrepMonthlyRefill",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VaccinationForHepBStarted",
                table: "PrepMonthlyRefill",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VaccinationForHepCStarted",
                table: "PrepMonthlyRefill",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VisitID",
                table: "PrepMonthlyRefill",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Weight",
                table: "PrepMonthlyRefill",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PrepMonthlyRefill",
                table: "PrepMonthlyRefill",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PrepMonthlyRefill_Facilities_FacilityId",
                table: "PrepMonthlyRefill",
                column: "FacilityId",
                principalTable: "Facilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
