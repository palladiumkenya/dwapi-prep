﻿namespace Dwapi.Prep.SharedKernel.Enums
{
    public enum CargoType
    {
        Patient,
        Metrics,
        AppMetrics
    }

    public enum ManifestStatus
    {
        Staged,
        Processed
    }
    public enum EmrSetup
    {
        SingleFacility,
        MultiFacility,
        Community
    }
}
