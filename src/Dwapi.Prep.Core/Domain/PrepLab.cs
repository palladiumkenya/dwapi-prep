using System;
using Dwapi.Contracts.Prep;
using Dwapi.Prep.SharedKernel.Model;

namespace Dwapi.Prep.Core.Domain
{
    public class PrepLab : Entity<Guid>,IExtract,IPrepLab
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
        public int? VisitID { get; set; }
        public string TestName { get; set; }
        public string TestResult { get; set; }
        public DateTime? SampleDate { get; set; }
        public DateTime? TestResultDate { get; set; }
        public string Reason { get; set; }
        public DateTime? Date_Created { get; set; }
        public DateTime? Date_Last_Modified { get; set; }

        public override void UpdateRefId()
        {
            RefId = Id;
            Id = Guid.NewGuid();
        }
    }
}
