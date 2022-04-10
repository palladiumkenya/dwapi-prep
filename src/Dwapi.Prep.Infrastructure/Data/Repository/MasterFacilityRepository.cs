using System.Collections.Generic;
using System.Linq;
using Dwapi.Prep.Core.Domain;
using Dwapi.Prep.Core.Interfaces.Repository;
using Dwapi.Prep.SharedKernel.Infrastructure.Data;

namespace Dwapi.Prep.Infrastructure.Data.Repository
{
    public class MasterFacilityRepository:BaseRepository<MasterFacility,int>, IMasterFacilityRepository
    {
        public MasterFacilityRepository(PrepContext context) : base(context)
        {
        }

        public MasterFacility GetBySiteCode(int siteCode)
        {
            return DbSet.Find(siteCode);
        }

        public List<MasterFacility> GetLastSnapshots(int siteCode)
        {
            return DbSet.Where(x =>  x.SnapshotSiteCode == siteCode)
                .ToList();
        }
    }
}
