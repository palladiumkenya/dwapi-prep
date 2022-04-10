using System;
using System.Collections.Generic;
using Dwapi.Prep.Core.Domain;
using Dwapi.Prep.SharedKernel.Interfaces;

namespace Dwapi.Prep.Core.Interfaces.Repository
{
    public interface IPrepVisitRepository : IRepository<PrepVisit,Guid>{void Process(Guid facilityId,IEnumerable<PrepVisit> clients);}
}
