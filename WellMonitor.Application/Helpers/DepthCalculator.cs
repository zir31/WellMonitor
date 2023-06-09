﻿using WellMonitor.Core.Entities;

namespace WellMonitor.Application.Helpers
{
    public static class DepthCalculator
    {
        public static float CalculatePassedDepth(this WellEntity well)
        {
            if (well.Telemetries.Any())
                return well.Telemetries.Max(w => w.Depth) - well.Telemetries.Min(w => w.Depth);
            
            return 0;
        }
    }
}
