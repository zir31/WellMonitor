using AutoMapper;
using WellMonitor.Application.Dtos.Telemetry;
using WellMonitor.Core.Entities;

namespace WellMonitor.Application.Mappings
{
    public class TelemetryMapper : Profile
    {
        public TelemetryMapper()
        {
            CreateMap<TelemetryAddRequest, TelemetryEntity>();
        }
    }
}
