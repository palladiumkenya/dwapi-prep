using System;
using Dwapi.Contracts.Prep;
using Dwapi.Prep.SharedKernel.Model;

namespace Dwapi.Prep.Core.Domain
{
    public class PrepMonthlyRefill : Entity<Guid>,IExtract,IPrepMonthlyRefill
    {
        public int PatientPk { get; set; }
        public int SiteCode { get; set; }
        public string Emr { get; set; }
        public string Project { get; set; }
        public bool? Processed { get; set; }
        public string QueueId { get; set; }
        public string Status { get; set; }
        public DateTime? StatusDate { get; set; }
        public DateTime? DateExtracted { get; set; }
        public Guid FacilityId { get; set; }
        public string FacilityName { get; set; }
        public string PrepNumber { get; set; }
        public string VisitDate { get; set; }
        public string BehaviorRiskAssessment { get; set; }
        public string SexPartnerHIVStatus { get; set; }
        public string SymptomsAcuteHIV { get; set; }
        public string AdherenceCounsellingDone { get; set; }
        public string ContraIndicationForPrEP { get; set; }
        public string PrescribedPrepToday { get; set; }
        public string RegimenPrescribed { get; set; }
        public string NumberOfMonths { get; set; }
        public string CondomsIssued { get; set; }
        public int NumberOfCondomsIssued { get; set; }
        public string ClientGivenNextAppointment { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public string ReasonForFailureToGiveAppointment { get; set; }
        public DateTime? DateOfLastPrepDose { get; set; }
        
        public string RecordUUID { get; set; }
        public bool? Voided { get; set; }
        public DateTime? Date_Created { get; set; }
        public DateTime? Date_Last_Modified { get; set; }
        
        public override void UpdateRefId()
        {
            RefId = Id;
            Id = Guid.NewGuid();
        }
    }
}
