using System;
using System.Collections.Generic;
using System.Linq;
using Dwapi.Prep.Core.Domain;
using Dwapi.Prep.Core.Interfaces.Repository;
using Dwapi.Prep.SharedKernel.Infrastructure.Data;

namespace Dwapi.Prep.Infrastructure.Data.Repository
{
    public class PrepBehaviourRiskRepository : BaseRepository<PrepBehaviourRisk,Guid>, IPrepBehaviourRiskRepository{public PrepBehaviourRiskRepository(PrepContext context) : base(context){}public void Process(Guid facilityId,IEnumerable<PrepBehaviourRisk> extracts){var mpi = extracts.ToList();if (mpi.Any()){mpi.ForEach(x => x.FacilityId = facilityId);CreateBulk(mpi);}}}
}
