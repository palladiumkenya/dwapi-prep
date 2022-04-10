using System;
using System.Collections.Generic;
using System.Linq;
using Dwapi.Prep.Core.Domain;
using Dwapi.Prep.Core.Interfaces.Repository;
using Dwapi.Prep.SharedKernel.Infrastructure.Data;

namespace Dwapi.Prep.Infrastructure.Data.Repository
{
    public class PatientPrepRepository : BaseRepository<PatientPrep,Guid>, IPatientPrepRepository
    {
        public PatientPrepRepository(PrepContext context) : base(context)
        {
        }

        public void Process(Guid facilityId,IEnumerable<PatientPrep> clients)
        {
            var mpi = clients.ToList();

            if (mpi.Any())
            {
                mpi.ForEach(x => x.FacilityId = facilityId);
                CreateBulk(mpi);
            }
        }
    }
}
