using System;
using System.Collections.Generic;
using System.Linq;
using Dwapi.Prep.Core.Domain;
using Dwapi.Prep.Core.Interfaces.Repository;
using Dwapi.Prep.SharedKernel.Infrastructure.Data;

namespace Dwapi.Prep.Infrastructure.Data.Repository
{
    public class PrepPharmacyRepository : BaseRepository<PrepPharmacy,Guid>, IPrepPharmacyRepository{public PrepPharmacyRepository(PrepContext context) : base(context){}public void Process(Guid facilityId,IEnumerable<PrepPharmacy> extracts){var mpi = extracts.ToList();if (mpi.Any()){mpi.ForEach(x => x.FacilityId = facilityId);CreateBulk(mpi);}}}
}
