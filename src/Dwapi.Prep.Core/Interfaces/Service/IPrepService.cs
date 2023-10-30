using System.Collections.Generic;
using Dwapi.Prep.Core.Domain;

namespace Dwapi.Prep.Core.Interfaces.Service
{
    public interface IPrepService
    {
        void Process(IEnumerable<PatientPrep> patients);
        void Process(IEnumerable<PrepAdverseEvent> extracts);
        void Process(IEnumerable<PrepBehaviourRisk> extracts);
        void Process(IEnumerable<PrepCareTermination> extracts);
        void Process(IEnumerable<PrepLab> extracts);
        void Process(IEnumerable<PrepPharmacy> extracts);
        void Process(IEnumerable<PrepVisit> extracts);
        void Process(IEnumerable<PrepMonthlyRefill> extracts);

    }
}
