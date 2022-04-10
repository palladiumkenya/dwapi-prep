using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Dwapi.Prep.Core.Domain;
using Dwapi.Prep.Core.Exchange;
using Dwapi.Prep.Core.Interfaces.Repository;
using Dwapi.Prep.SharedKernel.Infrastructure.Data;
using Dwapi.Prep.SharedKernel.Model;
using Serilog;

namespace Dwapi.Prep.Infrastructure.Data.Repository
{
    public class FacilityRepository : BaseRepository<Facility, Guid>, IFacilityRepository
    {
        public FacilityRepository(PrepContext context) : base(context)
        {
        }

        public IEnumerable<SiteProfile> GetSiteProfiles()
        {
            return GetAll().Select(x => new SiteProfile(x.SiteCode, x.Id));
        }

        public IEnumerable<SiteProfile> GetSiteProfiles(List<int> siteCodes)
        {
            return GetAll(x=>siteCodes.Contains(x.SiteCode)).Select(x => new SiteProfile(x.SiteCode, x.Id));
        }

        public IEnumerable<StatsDto> GetFacStats(IEnumerable<Guid> facilityIds)
        {
            var list = new List<StatsDto>();
            foreach (var facilityId in facilityIds)
            {
                try
                {
                    var stat = GetFacStats(facilityId);
                    if(null!=stat)
                        list.Add(stat);
                }
                catch (Exception e)
                {
                    Log.Error(e.Message);
                }


            }
            return list;
        }

        public StatsDto GetFacStats(Guid facilityId)
        {
            string sql = $@"
select
(select top 1 {nameof(Facility.SiteCode)} from {nameof(PrepContext.Facilities)} where {nameof(Facility.Id)}='{facilityId}') FacilityCode,
(select ISNULL(max({nameof(PatientPrep.Created)}),GETDATE()) from {nameof(PrepContext.PrepPatients)} where {nameof(PatientPrep.FacilityId)}='{facilityId}') Updated,
(select count(id) from {nameof(PrepContext.PrepPatients)} where facilityid='{facilityId}') {nameof(PatientPrep)},
(select count(id) from {nameof(PrepContext.PrepAdverseEvents)} where facilityid='{facilityId}') {nameof(PrepAdverseEvent)},
(select count(id) from {nameof(PrepContext.PrepBehaviourRisks)} where facilityid='{facilityId}') {nameof(PrepBehaviourRisk)},
(select count(id) from {nameof(PrepContext.PrepCareTerminations)} where facilityid='{facilityId}') {nameof(PrepCareTermination)},
(select count(id) from {nameof(PrepContext.PrepLabs)} where facilityid='{facilityId}') {nameof(PrepLab)},
(select count(id) from {nameof(PrepContext.PrepPharmacys)} where facilityid='{facilityId}') {nameof(PrepPharmacy)},
(select count(id) from {nameof(PrepContext.PrepVisits)} where facilityid='{facilityId}') {nameof(PrepVisit)}
";

            var result = GetDbConnection().Query<dynamic>(sql).FirstOrDefault();

            if (null != result)
            {
                var stats=new StatsDto(result.FacilityCode,result.Updated);
                stats.AddStats($"{nameof(PatientPrep)}",result.PatientPrep);
                stats.AddStats($"{nameof(PrepAdverseEvent)}",result.PrepAdverseEvent);
                stats.AddStats($"{nameof(PrepBehaviourRisk)}",result.PrepBehaviourRisk);
                stats.AddStats($"{nameof(PrepCareTermination)}",result.PrepCareTermination);
                stats.AddStats($"{nameof(PrepLab)}",result.PrepLab);
                stats.AddStats($"{nameof(PrepPharmacy)}",result.PrepPharmacy);
                stats.AddStats($"{nameof(PrepVisit)}",result.PrepVisit);
                return stats;
            }

            return null;
        }

        public Facility GetBySiteCode(int siteCode)
        {
            return DbSet.FirstOrDefault(x=>x.SiteCode==siteCode);
        }
    }
}
