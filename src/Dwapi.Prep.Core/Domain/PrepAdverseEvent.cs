using System;
using Dwapi.Contracts.Prep;
using Dwapi.Prep.SharedKernel.Model;

namespace Dwapi.Prep.Core.Domain
{
    public class PrepAdverseEvent : Entity<Guid>,IExtract, IPrepAdverseEvent
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
        public string AdverseEvent { get; set; }
        public DateTime? AdverseEventStartDate { get; set; }
        public DateTime? AdverseEventEndDate { get; set; }
        public string Severity { get; set; }
        public DateTime? VisitDate { get; set; }
        public string AdverseEventActionTaken { get; set; }
        public string AdverseEventClinicalOutcome { get; set; }
        public string AdverseEventIsPregnant { get; set; }
        public string AdverseEventCause { get; set; }
        public string AdverseEventRegimen { get; set; }
        public DateTime? Date_Created { get; set; }
        public DateTime? Date_Last_Modified { get; set; }
        public override void UpdateRefId()
        {
            RefId = Id;
            Id = Guid.NewGuid();
        }
    }
}
