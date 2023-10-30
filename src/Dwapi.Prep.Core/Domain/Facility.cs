﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Dwapi.Prep.SharedKernel.Model;
using Dwapi.Prep.SharedKernel.Utils;

namespace Dwapi.Prep.Core.Domain
{
    public class Facility : Entity<Guid>
    {
        public int SiteCode { get; set; }
        [MaxLength(120)] public string Name { get; set; }
        public int? MasterFacilityId { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public string Emr { get; set; }
        public DateTime? SnapshotDate { get; set; }
        public int? SnapshotSiteCode { get; set; }
        public int? SnapshotVersion { get; set; }

        public ICollection<PatientPrep> PrepPatients { get; set; }=new List<PatientPrep>();
        public ICollection<PrepAdverseEvent> PrepAdverseEvents { get; set; }=new List<PrepAdverseEvent>();
        public virtual ICollection<PrepBehaviourRisk> PrepBehaviourRisks { get; set; } = new List<PrepBehaviourRisk>();
        public virtual ICollection<PrepCareTermination> PrepCareTerminations { get; set; } = new List<PrepCareTermination>();
        public virtual ICollection<PrepLab> PrepLabs { get; set; } = new List<PrepLab>();
        public virtual ICollection<PrepPharmacy> PrepPharmacys { get; set; } = new List<PrepPharmacy>();
        public virtual ICollection<PrepVisit> PrepVisits { get; set; } = new List<PrepVisit>();
        public virtual ICollection<PrepMonthlyRefill> PrepMonthlyRefill { get; set; } = new List<PrepMonthlyRefill>();


        public ICollection<Manifest> Manifests { get; set; }=new List<Manifest>();

        public Facility()
        {
        }

        public Facility(int siteCode, string name)
        {
            SiteCode = siteCode;
            Name = name;
        }

        public Facility(int siteCode, string name, int? masterFacilityId):this(siteCode,name)
        {
            MasterFacilityId = masterFacilityId;
        }

        public bool EmrChanged(string requestEmr)
        {
            if (string.IsNullOrWhiteSpace(requestEmr))
                return false;

            if (string.IsNullOrWhiteSpace(Emr))
                return false;

            if (requestEmr.IsSameAs("CHAK"))
                requestEmr = "IQCare";

            if (requestEmr.IsSameAs("IQCare") || requestEmr.IsSameAs("KenyaEMR"))
                return !Emr.IsSameAs(requestEmr);

            return false;
        }

        public Facility TakeSnapFrom(MasterFacility snapMfl)
        {
            var fac = this;

            fac.SnapshotDate = DateTime.Now;
            fac.SiteCode = snapMfl.Id;
            fac.SnapshotSiteCode = snapMfl.SnapshotSiteCode;
            fac.SnapshotVersion = snapMfl.SnapshotVersion;

            return fac;
        }

        public override string ToString()
        {
            return $"{Name} - {SiteCode}";
        }
    }
}
