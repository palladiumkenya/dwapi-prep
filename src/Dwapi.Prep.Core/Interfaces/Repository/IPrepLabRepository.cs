using System;
using System.Collections.Generic;
using Dwapi.Prep.Core.Domain;
using Dwapi.Prep.SharedKernel.Interfaces;

namespace Dwapi.Prep.Core.Interfaces.Repository
{
    public interface IPrepLabRepository : IRepository<PrepLab,Guid>{void Process(Guid facilityId,IEnumerable<PrepLab> clients);}
}
