using System;
using Dwapi.Contracts.Prep;
using Dwapi.Prep.SharedKernel.Model;

namespace Dwapi.Prep.Core.Domain
{
    public class PrepBehaviourRisk : Entity<Guid>,IExtract,IPrepBehaviourRisk
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
        public string HtsNumber { get; set; }
        public DateTime? VisitDate { get; set; }
        public int? VisitID { get; set; }
        public string SexPartnerHIVStatus { get; set; }
        public string IsHIVPositivePartnerCurrentonART { get; set; }
        public string IsPartnerHighrisk { get; set; }
        public string PartnerARTRisk { get; set; }
        public string ClientAssessments { get; set; }
        public string ClientRisk { get; set; }
        public string ClientWillingToTakePrep { get; set; }
        public string PrEPDeclineReason { get; set; }
        public string RiskReductionEducationOffered { get; set; }
        public string ReferralToOtherPrevServices { get; set; }
        public DateTime? FirstEstablishPartnerStatus { get; set; }
        public DateTime? PartnerEnrolledtoCCC { get; set; }
        public string HIVPartnerCCCnumber { get; set; }
        public DateTime? HIVPartnerARTStartDate { get; set; }
        public string MonthsknownHIVSerodiscordant { get; set; }
        public string SexWithoutCondom { get; set; }
        public string NumberofchildrenWithPartner { get; set; }
        public DateTime? Date_Created { get; set; }
        public DateTime? Date_Last_Modified { get; set; }
        public string RecordUUID { get; set; }
        public bool? Voided { get; set; }
        
        public override void UpdateRefId()
        {
            RefId = Id;
            Id = Guid.NewGuid();
        }

    }
}
