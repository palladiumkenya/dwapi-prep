using System.Collections.Generic;
using Dwapi.Prep.Core.Domain;
using Dwapi.Prep.SharedKernel.Interfaces;

namespace Dwapi.Prep.Core.Interfaces.Repository
{
    public interface IMasterFacilityRepository:IRepository<MasterFacility,int>
    {
        MasterFacility GetBySiteCode(int siteCode);
        List<MasterFacility> GetLastSnapshots(int siteCode);
    }
}
