using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dwapi.Prep.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dockets",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    RefId = table.Column<Guid>(nullable: true),
                    Created = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Instance = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dockets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MasterFacilities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    RefId = table.Column<Guid>(nullable: true),
                    Created = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 120, nullable: true),
                    County = table.Column<string>(maxLength: 120, nullable: true),
                    SnapshotDate = table.Column<DateTime>(nullable: true),
                    SnapshotSiteCode = table.Column<int>(nullable: true),
                    SnapshotVersion = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterFacilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subscribers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RefId = table.Column<Guid>(nullable: true),
                    Created = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    AuthCode = table.Column<string>(nullable: true),
                    DocketId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscribers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscribers_Dockets_DocketId",
                        column: x => x.DocketId,
                        principalTable: "Dockets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Facilities",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RefId = table.Column<Guid>(nullable: true),
                    Created = table.Column<DateTime>(nullable: true),
                    SiteCode = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 120, nullable: true),
                    MasterFacilityId = table.Column<int>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Emr = table.Column<string>(nullable: true),
                    SnapshotDate = table.Column<DateTime>(nullable: true),
                    SnapshotSiteCode = table.Column<int>(nullable: true),
                    SnapshotVersion = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Facilities_MasterFacilities_MasterFacilityId",
                        column: x => x.MasterFacilityId,
                        principalTable: "MasterFacilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Manifests",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RefId = table.Column<Guid>(nullable: true),
                    Created = table.Column<DateTime>(nullable: true),
                    SiteCode = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Sent = table.Column<int>(nullable: false),
                    Recieved = table.Column<int>(nullable: false),
                    DateLogged = table.Column<DateTime>(nullable: false),
                    DateArrived = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    StatusDate = table.Column<DateTime>(nullable: false),
                    FacilityId = table.Column<Guid>(nullable: false),
                    EmrId = table.Column<Guid>(nullable: true),
                    EmrName = table.Column<string>(nullable: true),
                    EmrSetup = table.Column<int>(nullable: false),
                    Session = table.Column<Guid>(nullable: true),
                    Start = table.Column<DateTime>(nullable: true),
                    End = table.Column<DateTime>(nullable: true),
                    Tag = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manifests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Manifests_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrepAdverseEvents",
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
                    AdverseEvent = table.Column<string>(nullable: true),
                    AdverseEventStartDate = table.Column<DateTime>(nullable: true),
                    AdverseEventEndDate = table.Column<DateTime>(nullable: true),
                    Severity = table.Column<string>(nullable: true),
                    VisitDate = table.Column<DateTime>(nullable: true),
                    AdverseEventActionTaken = table.Column<string>(nullable: true),
                    AdverseEventClinicalOutcome = table.Column<string>(nullable: true),
                    AdverseEventIsPregnant = table.Column<string>(nullable: true),
                    AdverseEventCause = table.Column<string>(nullable: true),
                    AdverseEventRegimen = table.Column<string>(nullable: true),
                    Date_Created = table.Column<DateTime>(nullable: true),
                    Date_Last_Modified = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrepAdverseEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrepAdverseEvents_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrepBehaviourRisks",
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
                    HtsNumber = table.Column<string>(nullable: true),
                    VisitDate = table.Column<DateTime>(nullable: true),
                    VisitID = table.Column<int>(nullable: true),
                    SexPartnerHIVStatus = table.Column<string>(nullable: true),
                    IsHIVPositivePartnerCurrentonART = table.Column<string>(nullable: true),
                    IsPartnerHighrisk = table.Column<string>(nullable: true),
                    PartnerARTRisk = table.Column<string>(nullable: true),
                    ClientAssessments = table.Column<string>(nullable: true),
                    ClientRisk = table.Column<string>(nullable: true),
                    ClientWillingToTakePrep = table.Column<string>(nullable: true),
                    PrEPDeclineReason = table.Column<string>(nullable: true),
                    RiskReductionEducationOffered = table.Column<string>(nullable: true),
                    ReferralToOtherPrevServices = table.Column<string>(nullable: true),
                    FirstEstablishPartnerStatus = table.Column<DateTime>(nullable: true),
                    PartnerEnrolledtoCCC = table.Column<DateTime>(nullable: true),
                    HIVPartnerCCCnumber = table.Column<string>(nullable: true),
                    HIVPartnerARTStartDate = table.Column<DateTime>(nullable: true),
                    MonthsknownHIVSerodiscordant = table.Column<string>(nullable: true),
                    SexWithoutCondom = table.Column<string>(nullable: true),
                    NumberofchildrenWithPartner = table.Column<string>(nullable: true),
                    Date_Created = table.Column<DateTime>(nullable: true),
                    Date_Last_Modified = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrepBehaviourRisks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrepBehaviourRisks_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrepCareTerminations",
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
                    HtsNumber = table.Column<string>(nullable: true),
                    ExitDate = table.Column<DateTime>(nullable: true),
                    ExitReason = table.Column<string>(nullable: true),
                    DateOfLastPrepDose = table.Column<DateTime>(nullable: true),
                    Date_Created = table.Column<DateTime>(nullable: true),
                    Date_Last_Modified = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrepCareTerminations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrepCareTerminations_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrepLabs",
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
                    HtsNumber = table.Column<string>(nullable: true),
                    VisitID = table.Column<int>(nullable: true),
                    TestName = table.Column<string>(nullable: true),
                    TestResult = table.Column<string>(nullable: true),
                    SampleDate = table.Column<DateTime>(nullable: true),
                    TestResultDate = table.Column<DateTime>(nullable: true),
                    Reason = table.Column<string>(nullable: true),
                    Date_Created = table.Column<DateTime>(nullable: true),
                    Date_Last_Modified = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrepLabs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrepLabs_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrepPatients",
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
                    HtsNumber = table.Column<string>(nullable: true),
                    PrepEnrollmentDate = table.Column<DateTime>(nullable: true),
                    Sex = table.Column<string>(nullable: true),
                    DateofBirth = table.Column<DateTime>(nullable: true),
                    CountyofBirth = table.Column<string>(nullable: true),
                    County = table.Column<string>(nullable: true),
                    SubCounty = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    LandMark = table.Column<string>(nullable: true),
                    Ward = table.Column<string>(nullable: true),
                    ClientType = table.Column<string>(nullable: true),
                    ReferralPoint = table.Column<string>(nullable: true),
                    MaritalStatus = table.Column<string>(nullable: true),
                    Inschool = table.Column<string>(nullable: true),
                    PopulationType = table.Column<string>(nullable: true),
                    KeyPopulationType = table.Column<string>(nullable: true),
                    Refferedfrom = table.Column<string>(nullable: true),
                    TransferIn = table.Column<string>(nullable: true),
                    TransferInDate = table.Column<DateTime>(nullable: true),
                    TransferFromFacility = table.Column<string>(nullable: true),
                    DatefirstinitiatedinPrepCare = table.Column<DateTime>(nullable: true),
                    DateStartedPrEPattransferringfacility = table.Column<DateTime>(nullable: true),
                    ClientPreviouslyonPrep = table.Column<string>(nullable: true),
                    PrevPrepReg = table.Column<string>(nullable: true),
                    DateLastUsedPrev = table.Column<DateTime>(nullable: true),
                    Date_Created = table.Column<DateTime>(nullable: true),
                    Date_Last_Modified = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrepPatients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrepPatients_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrepPharmacys",
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
                    HtsNumber = table.Column<string>(nullable: true),
                    VisitID = table.Column<int>(nullable: true),
                    RegimenPrescribed = table.Column<string>(nullable: true),
                    DispenseDate = table.Column<DateTime>(nullable: true),
                    Duration = table.Column<decimal>(nullable: true),
                    Date_Created = table.Column<DateTime>(nullable: true),
                    Date_Last_Modified = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrepPharmacys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrepPharmacys_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrepVisits",
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
                    HtsNumber = table.Column<string>(nullable: true),
                    EncounterId = table.Column<string>(nullable: true),
                    VisitID = table.Column<string>(nullable: true),
                    VisitDate = table.Column<DateTime>(nullable: true),
                    BloodPressure = table.Column<string>(nullable: true),
                    Temperature = table.Column<string>(nullable: true),
                    Weight = table.Column<decimal>(nullable: true),
                    Height = table.Column<decimal>(nullable: true),
                    BMI = table.Column<decimal>(nullable: true),
                    STIScreening = table.Column<string>(nullable: true),
                    STISymptoms = table.Column<string>(nullable: true),
                    STITreated = table.Column<string>(nullable: true),
                    Circumcised = table.Column<string>(nullable: true),
                    VMMCReferral = table.Column<string>(nullable: true),
                    LMP = table.Column<DateTime>(nullable: true),
                    MenopausalStatus = table.Column<string>(nullable: true),
                    PregnantAtThisVisit = table.Column<string>(nullable: true),
                    EDD = table.Column<DateTime>(nullable: true),
                    PlanningToGetPregnant = table.Column<string>(nullable: true),
                    PregnancyPlanned = table.Column<string>(nullable: true),
                    PregnancyEnded = table.Column<string>(nullable: true),
                    PregnancyEndDate = table.Column<DateTime>(nullable: true),
                    PregnancyOutcome = table.Column<string>(nullable: true),
                    BirthDefects = table.Column<string>(nullable: true),
                    Breastfeeding = table.Column<string>(nullable: true),
                    FamilyPlanningStatus = table.Column<string>(nullable: true),
                    FPMethods = table.Column<string>(nullable: true),
                    AdherenceDone = table.Column<string>(nullable: true),
                    AdherenceOutcome = table.Column<string>(nullable: true),
                    AdherenceReasons = table.Column<string>(nullable: true),
                    SymptomsAcuteHIV = table.Column<string>(nullable: true),
                    ContraindicationsPrep = table.Column<string>(nullable: true),
                    PrepTreatmentPlan = table.Column<string>(nullable: true),
                    PrepPrescribed = table.Column<string>(nullable: true),
                    RegimenPrescribed = table.Column<string>(nullable: true),
                    MonthsPrescribed = table.Column<string>(nullable: true),
                    CondomsIssued = table.Column<string>(nullable: true),
                    Tobegivennextappointment = table.Column<string>(nullable: true),
                    Reasonfornotgivingnextappointment = table.Column<string>(nullable: true),
                    HepatitisBPositiveResult = table.Column<string>(nullable: true),
                    HepatitisCPositiveResult = table.Column<string>(nullable: true),
                    VaccinationForHepBStarted = table.Column<string>(nullable: true),
                    TreatedForHepB = table.Column<string>(nullable: true),
                    VaccinationForHepCStarted = table.Column<string>(nullable: true),
                    TreatedForHepC = table.Column<string>(nullable: true),
                    NextAppointment = table.Column<DateTime>(nullable: true),
                    ClinicalNotes = table.Column<string>(nullable: true),
                    Date_Created = table.Column<DateTime>(nullable: true),
                    Date_Last_Modified = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrepVisits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrepVisits_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cargoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RefId = table.Column<Guid>(nullable: true),
                    Created = table.Column<DateTime>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Items = table.Column<string>(nullable: true),
                    ManifestId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cargoes_Manifests_ManifestId",
                        column: x => x.ManifestId,
                        principalTable: "Manifests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cargoes_ManifestId",
                table: "Cargoes",
                column: "ManifestId");

            migrationBuilder.CreateIndex(
                name: "IX_Facilities_MasterFacilityId",
                table: "Facilities",
                column: "MasterFacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Manifests_FacilityId",
                table: "Manifests",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_PrepAdverseEvents_FacilityId",
                table: "PrepAdverseEvents",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_PrepBehaviourRisks_FacilityId",
                table: "PrepBehaviourRisks",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_PrepCareTerminations_FacilityId",
                table: "PrepCareTerminations",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_PrepLabs_FacilityId",
                table: "PrepLabs",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_PrepPatients_FacilityId",
                table: "PrepPatients",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_PrepPharmacys_FacilityId",
                table: "PrepPharmacys",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_PrepVisits_FacilityId",
                table: "PrepVisits",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscribers_DocketId",
                table: "Subscribers",
                column: "DocketId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cargoes");

            migrationBuilder.DropTable(
                name: "PrepAdverseEvents");

            migrationBuilder.DropTable(
                name: "PrepBehaviourRisks");

            migrationBuilder.DropTable(
                name: "PrepCareTerminations");

            migrationBuilder.DropTable(
                name: "PrepLabs");

            migrationBuilder.DropTable(
                name: "PrepPatients");

            migrationBuilder.DropTable(
                name: "PrepPharmacys");

            migrationBuilder.DropTable(
                name: "PrepVisits");

            migrationBuilder.DropTable(
                name: "Subscribers");

            migrationBuilder.DropTable(
                name: "Manifests");

            migrationBuilder.DropTable(
                name: "Dockets");

            migrationBuilder.DropTable(
                name: "Facilities");

            migrationBuilder.DropTable(
                name: "MasterFacilities");
        }
    }
}
