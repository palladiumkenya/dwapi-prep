using System;
using System.Collections.Generic;
using System.Linq;
using Dwapi.Prep.Core.Domain;
using Dwapi.Prep.Core.Interfaces.Repository;
using Dwapi.Prep.Core.Interfaces.Service;
using Dwapi.Prep.SharedKernel.Exceptions;
using Dwapi.Prep.SharedKernel.Model;
using Serilog;

namespace Dwapi.Prep.Core.Service
{
    public class PrepService : IPrepService
    {
        private readonly ILiveSyncService _syncService;
        private readonly IFacilityRepository _facilityRepository;
        private readonly IPatientPrepRepository _patientPrepRepository;
        private readonly IPrepAdverseEventRepository _prepAdverseEventRepository;
        private readonly IPrepBehaviourRiskRepository _prepBehaviourRiskRepository;
        private readonly IPrepCareTerminationRepository _prepCareTerminationRepository;
        private readonly IPrepLabRepository _prepLabRepository;
        private readonly IPrepPharmacyRepository _prepPharmacyRepository;
        private readonly IPrepVisitRepository _prepVisitRepository;
        private List<SiteProfile> _siteProfiles = new List<SiteProfile>();

        public PrepService(ILiveSyncService syncService, IFacilityRepository facilityRepository,
            IPatientPrepRepository patientPrepRepository, IPrepAdverseEventRepository prepAdverseEventRepository,
            IPrepBehaviourRiskRepository prepBehaviourRiskRepository,
            IPrepCareTerminationRepository prepCareTerminationRepository, IPrepLabRepository prepLabRepository,
            IPrepPharmacyRepository prepPharmacyRepository, IPrepVisitRepository prepVisitRepository)
        {
            _syncService = syncService;
            _facilityRepository = facilityRepository;
            _patientPrepRepository = patientPrepRepository;
            _prepAdverseEventRepository = prepAdverseEventRepository;
            _prepBehaviourRiskRepository = prepBehaviourRiskRepository;
            _prepCareTerminationRepository = prepCareTerminationRepository;
            _prepLabRepository = prepLabRepository;
            _prepPharmacyRepository = prepPharmacyRepository;
            _prepVisitRepository = prepVisitRepository;
        }

        public void Process(IEnumerable<PatientPrep> patients)
        {
            List<Guid> facilityIds = new List<Guid>();

            if (null == patients)
                return;
            if (!patients.Any())
                return;

            _siteProfiles = _facilityRepository.GetSiteProfiles().ToList();

            var batch = new List<PatientPrep>();
            int count = 0;

            foreach (var patient in patients)
            {
                count++;
                try
                {
                    patient.FacilityId = GetFacilityId(patient.SiteCode);
                    patient.UpdateRefId();
                    batch.Add(patient);

                    facilityIds.Add(patient.FacilityId);
                }
                catch (Exception e)
                {
                    Log.Error(e, $"Facility Id missing {patient.SiteCode}");
                }


                if (count == 1000)
                {
                    _patientPrepRepository.CreateBulk(batch);
                    count = 0;
                    batch = new List<PatientPrep>();
                }

            }

            if (batch.Any())
                _patientPrepRepository.CreateBulk(batch);

            SyncClients(facilityIds);

        }

        public void Process(IEnumerable<PrepAdverseEvent> extracts)
        {
            List<Guid> facilityIds = new List<Guid>();
            if (null == extracts)
                return;
            if (!extracts.Any())
                return;
            _siteProfiles = _facilityRepository.GetSiteProfiles().ToList();
            var batch = new List<PrepAdverseEvent>();
            int count = 0;
            foreach (var extract in extracts)
            {
                count++;
                try
                {
                    extract.FacilityId = GetFacilityId(extract.SiteCode);
                    extract.UpdateRefId();
                    batch.Add(extract);
                    facilityIds.Add(extract.FacilityId);
                }
                catch (Exception e)
                {
                    Log.Error(e, $"Facility Id missing {extract.SiteCode}");
                }


                if (count == 1000)
                {
                    _prepAdverseEventRepository.CreateBulk(batch);
                    count = 0;
                    batch = new List<PrepAdverseEvent>();
                }
            }

            if (batch.Any())
                _prepAdverseEventRepository.CreateBulk(batch);
            SyncClients(facilityIds);
        }

        public void Process(IEnumerable<PrepBehaviourRisk> extracts)
        {
            List<Guid> facilityIds = new List<Guid>();
            if (null == extracts)
                return;
            if (!extracts.Any())
                return;
            _siteProfiles = _facilityRepository.GetSiteProfiles().ToList();
            var batch = new List<PrepBehaviourRisk>();
            int count = 0;
            foreach (var extract in extracts)
            {
                count++;
                try
                {
                    extract.FacilityId = GetFacilityId(extract.SiteCode);
                    extract.UpdateRefId();
                    batch.Add(extract);
                    facilityIds.Add(extract.FacilityId);
                }
                catch (Exception e)
                {
                    Log.Error(e, $"Facility Id missing {extract.SiteCode}");
                }


                if (count == 1000)
                {
                    _prepBehaviourRiskRepository.CreateBulk(batch);
                    count = 0;
                    batch = new List<PrepBehaviourRisk>();
                }
            }

            if (batch.Any())
                _prepBehaviourRiskRepository.CreateBulk(batch);
            SyncClients(facilityIds);
        }

        public void Process(IEnumerable<PrepCareTermination> extracts)
        {
            List<Guid> facilityIds = new List<Guid>();
            if (null == extracts)
                return;
            if (!extracts.Any())
                return;
            _siteProfiles = _facilityRepository.GetSiteProfiles().ToList();
            var batch = new List<PrepCareTermination>();
            int count = 0;
            foreach (var extract in extracts)
            {
                count++;
                try
                {
                    extract.FacilityId = GetFacilityId(extract.SiteCode);
                    extract.UpdateRefId();
                    batch.Add(extract);
                    facilityIds.Add(extract.FacilityId);
                }
                catch (Exception e)
                {
                    Log.Error(e, $"Facility Id missing {extract.SiteCode}");
                }


                if (count == 1000)
                {
                    _prepCareTerminationRepository.CreateBulk(batch);
                    count = 0;
                    batch = new List<PrepCareTermination>();
                }
            }

            if (batch.Any())
                _prepCareTerminationRepository.CreateBulk(batch);
            SyncClients(facilityIds);
        }

        public void Process(IEnumerable<PrepLab> extracts)
        {
            List<Guid> facilityIds = new List<Guid>();
            if (null == extracts)
                return;
            if (!extracts.Any())
                return;
            _siteProfiles = _facilityRepository.GetSiteProfiles().ToList();
            var batch = new List<PrepLab>();
            int count = 0;
            foreach (var extract in extracts)
            {
                count++;
                try
                {
                    extract.FacilityId = GetFacilityId(extract.SiteCode);
                    extract.UpdateRefId();
                    batch.Add(extract);
                    facilityIds.Add(extract.FacilityId);
                }
                catch (Exception e)
                {
                    Log.Error(e, $"Facility Id missing {extract.SiteCode}");
                }


                if (count == 1000)
                {
                    _prepLabRepository.CreateBulk(batch);
                    count = 0;
                    batch = new List<PrepLab>();
                }
            }

            if (batch.Any())
                _prepLabRepository.CreateBulk(batch);
            SyncClients(facilityIds);
        }

        public void Process(IEnumerable<PrepPharmacy> extracts)
        {
            List<Guid> facilityIds = new List<Guid>();
            if (null == extracts)
                return;
            if (!extracts.Any())
                return;
            _siteProfiles = _facilityRepository.GetSiteProfiles().ToList();
            var batch = new List<PrepPharmacy>();
            int count = 0;
            foreach (var extract in extracts)
            {
                count++;
                try
                {
                    extract.FacilityId = GetFacilityId(extract.SiteCode);
                    extract.UpdateRefId();
                    batch.Add(extract);
                    facilityIds.Add(extract.FacilityId);
                }
                catch (Exception e)
                {
                    Log.Error(e, $"Facility Id missing {extract.SiteCode}");
                }


                if (count == 1000)
                {
                    _prepPharmacyRepository.CreateBulk(batch);
                    count = 0;
                    batch = new List<PrepPharmacy>();
                }
            }

            if (batch.Any())
                _prepPharmacyRepository.CreateBulk(batch);
            SyncClients(facilityIds);
        }

        public void Process(IEnumerable<PrepVisit> extracts)
        {
            List<Guid> facilityIds = new List<Guid>();
            if (null == extracts)
                return;
            if (!extracts.Any())
                return;
            _siteProfiles = _facilityRepository.GetSiteProfiles().ToList();
            var batch = new List<PrepVisit>();
            int count = 0;
            foreach (var extract in extracts)
            {
                count++;
                try
                {
                    extract.FacilityId = GetFacilityId(extract.SiteCode);
                    extract.UpdateRefId();
                    batch.Add(extract);
                    facilityIds.Add(extract.FacilityId);
                }
                catch (Exception e)
                {
                    Log.Error(e, $"Facility Id missing {extract.SiteCode}");
                }


                if (count == 1000)
                {
                    _prepVisitRepository.CreateBulk(batch);
                    count = 0;
                    batch = new List<PrepVisit>();
                }
            }

            if (batch.Any())
                _prepVisitRepository.CreateBulk(batch);
            SyncClients(facilityIds);
        }

        public Guid GetFacilityId(int siteCode)
        {
            var profile = _siteProfiles.FirstOrDefault(x => x.SiteCode == siteCode);
            if (null == profile)
                throw new FacilityNotFoundException(siteCode);

            return profile.FacilityId;
        }

        private void SyncClients(List<Guid> facIlds)
        {
            if (facIlds.Any())
            {
                _syncService.SyncStats(facIlds.Distinct().ToList());
            }
        }
    }
}
