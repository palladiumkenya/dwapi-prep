using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dwapi.Prep.Core.Domain;
using Dwapi.Prep.Core.Domain.Dto;
using Dwapi.Prep.SharedKernel.Interfaces;

namespace Dwapi.Prep.Core.Interfaces.Repository
{
    public interface IManifestRepository : IRepository<Manifest, Guid>
    {
        void ClearFacility(IEnumerable<Manifest> manifests);
        void ClearFacility(IEnumerable<Manifest> manifests,string project);
        int GetPatientCount(Guid id);
        IEnumerable<Manifest> GetStaged(int siteCode);
        Task EndSession(Guid session);
        IEnumerable<HandshakeDto> GetSessionHandshakes(Guid session);
        string GetDWAPIversionSending(int siteCode);

    }
}
