using System;
using System.Collections.Generic;
using Dwapi.Prep.Core.Domain;
using Dwapi.Prep.SharedKernel.Interfaces;

namespace Dwapi.Prep.Core.Interfaces.Repository
{
    public interface IPrepMonthlyRefillRepository : IRepository<PrepMonthlyRefill,Guid>{void Process(Guid facilityId,IEnumerable<PrepMonthlyRefill> clients);}
}
