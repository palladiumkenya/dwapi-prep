using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Dwapi.Prep.Core.Domain;
using Dwapi.Prep.Core.Domain.Dto;
using Dwapi.Prep.Core.Interfaces.Repository;
using Dwapi.Prep.SharedKernel.Enums;
using Dwapi.Prep.SharedKernel.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Dwapi.Prep.Infrastructure.Data.Repository
{
    public class ManifestRepository : BaseRepository<Manifest, Guid>, IManifestRepository
    {
        public ManifestRepository(PrepContext context) : base(context)
        {
        }

        public void ClearFacility(IEnumerable<Manifest> manifests)
        {
            var ids = string.Join(',', manifests.Select(x =>$"'{x.FacilityId}'"));
            ExecSql(
                $@"
                    DELETE FROM {nameof(PrepContext.PrepPatients)} WHERE {nameof(PatientPrep.FacilityId)} in ({ids}) AND {nameof(PatientPrep.Project)} <> 'IRDO';
                    DELETE FROM {nameof(PrepContext.PrepAdverseEvents)} WHERE {nameof(PrepAdverseEvent.FacilityId)} in ({ids}) AND {nameof(PrepAdverseEvent.Project)} <> 'IRDO';
                    DELETE FROM {nameof(PrepContext.PrepBehaviourRisks)} WHERE {nameof(PrepBehaviourRisk.FacilityId)} in ({ids}) AND {nameof(PrepBehaviourRisk.Project)} <> 'IRDO';
                    DELETE FROM {nameof(PrepContext.PrepCareTerminations)} WHERE {nameof(PrepCareTermination.FacilityId)} in ({ids}) AND {nameof(PrepCareTermination.Project)} <> 'IRDO';
                    DELETE FROM {nameof(PrepContext.PrepLabs)} WHERE {nameof(PrepLab.FacilityId)} in ({ids}) AND {nameof(PrepLab.Project)} <> 'IRDO';
                    DELETE FROM {nameof(PrepContext.PrepPharmacys)} WHERE {nameof(PrepPharmacy.FacilityId)} in ({ids}) AND {nameof(PrepPharmacy.Project)} <> 'IRDO';
                    DELETE FROM {nameof(PrepContext.PrepVisits)} WHERE {nameof(PrepVisit.FacilityId)} in ({ids}) AND {nameof(PrepVisit.Project)} <> 'IRDO';
                    DELETE FROM {nameof(PrepContext.PrepMonthlyRefills)} WHERE {nameof(PrepMonthlyRefill.FacilityId)} in ({ids}) AND {nameof(PrepMonthlyRefill.Project)} <> 'IRDO';

                 "
                );

            var mids = string.Join(',', manifests.Select(x => $"'{x.Id}'"));
            ExecSql(
                $@"
                    UPDATE
                        {nameof(PrepContext.Manifests)}
                    SET
                        {nameof(Manifest.Status)}={(int)ManifestStatus.Processed},
                        {nameof(Manifest.StatusDate)}=GETDATE()
                    WHERE
                        {nameof(Manifest.Id)} in ({mids})");
        }

        public void ClearFacility(IEnumerable<Manifest> manifests, string project)
        {
            var ids = string.Join(',', manifests.Select(x =>$"'{x.FacilityId}'"));
            ExecSql(
                $@"
                    DELETE FROM {nameof(PrepContext.PrepPatients)} WHERE {nameof(PatientPrep.FacilityId)} in ({ids}) AND {nameof(PatientPrep.Project)}='{project}';                   
                    DELETE FROM {nameof(PrepContext.PrepAdverseEvents)} WHERE {nameof(PrepAdverseEvent.FacilityId)} in ({ids}) AND {nameof(PrepAdverseEvent.Project)}='{project}';
                    DELETE FROM {nameof(PrepContext.PrepBehaviourRisks)} WHERE {nameof(PrepBehaviourRisk.FacilityId)} in ({ids}) AND {nameof(PrepBehaviourRisk.Project)}='{project}';
                    DELETE FROM {nameof(PrepContext.PrepCareTerminations)} WHERE {nameof(PrepCareTermination.FacilityId)} in ({ids}) AND {nameof(PrepCareTermination.Project)}='{project}';
                    DELETE FROM {nameof(PrepContext.PrepLabs)} WHERE {nameof(PrepLab.FacilityId)} in ({ids}) AND {nameof(PrepLab.Project)}='{project}';
                    DELETE FROM {nameof(PrepContext.PrepPharmacys)} WHERE {nameof(PrepPharmacy.FacilityId)} in ({ids}) AND {nameof(PrepPharmacy.Project)}='{project}';
                    DELETE FROM {nameof(PrepContext.PrepVisits)} WHERE {nameof(PrepVisit.FacilityId)} in ({ids}) AND {nameof(PrepVisit.Project)}='{project}';
                    DELETE FROM {nameof(PrepContext.PrepMonthlyRefills)} WHERE {nameof(PrepMonthlyRefill.FacilityId)} in ({ids}) AND {nameof(PrepMonthlyRefill.Project)} <> 'IRDO';
                 
"
            );

            var mids = string.Join(',', manifests.Select(x => $"'{x.Id}'"));
            ExecSql(
                $@"
                    UPDATE
                        {nameof(PrepContext.Manifests)}
                    SET
                        {nameof(Manifest.Status)}={(int)ManifestStatus.Processed},
                        {nameof(Manifest.StatusDate)}=GETDATE()
                    WHERE
                        {nameof(Manifest.Id)} in ({mids})");
        }

        public int GetPatientCount(Guid id)
        {
            var ctt = Context as PrepContext;
            var cargo = ctt.Cargoes.FirstOrDefault(x => x.ManifestId == id && x.Type == CargoType.Patient);
            if (null != cargo)
                return cargo.Items.Split(",").Length;

            return 0;
        }

        public IEnumerable<Manifest> GetStaged(int siteCode)
        {
            var ctt = Context as PrepContext;
            var manifests = DbSet.AsNoTracking().Where(x => x.Status == ManifestStatus.Staged && x.SiteCode == siteCode)
                .ToList();

            foreach (var manifest in manifests)
            {
                manifest.Cargoes = ctt.Cargoes.AsNoTracking()
                    .Where(x => x.Type != CargoType.Patient && x.ManifestId == manifest.Id).ToList();
            }

            return manifests;
        }

        public async Task EndSession(Guid session)
        {
            var end = DateTime.Now;
            var sql = $"UPDATE {nameof(PrepContext.Manifests)} SET [{nameof(Manifest.End)}]=@end WHERE [{nameof(Manifest.Session)}]=@session";
            await Context.Database.GetDbConnection().ExecuteAsync(sql, new {session, end});
        }

        public IEnumerable<HandshakeDto> GetSessionHandshakes(Guid session)
        {
            var sql = $"SELECT * FROM {nameof(PrepContext.Manifests)} WHERE [{nameof(Manifest.Session)}]=@session";
            var manifests = Context.Database.GetDbConnection().Query<Manifest>(sql,new{session}).ToList();
            return manifests.Select(x => new HandshakeDto()
            {
                Id = x.Id, End = x.End, Session = x.Session, Start = x.Start
            });
        }
    }
}
