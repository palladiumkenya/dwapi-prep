using System;
using Dwapi.Contracts.Prep;
using Dwapi.Prep.SharedKernel.Model;

namespace Dwapi.Prep.Core.Domain
{
    public class PrepCareTermination : Entity<Guid>,IExtract,IPrepCareTermination
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
        public DateTime? ExitDate { get; set; }
        public string ExitReason { get; set; }
        public DateTime? DateOfLastPrepDose { get; set; }
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
