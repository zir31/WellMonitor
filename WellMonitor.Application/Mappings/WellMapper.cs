using AutoMapper;
using WellMonitor.Application.Dtos.Well;
using WellMonitor.Application.Helpers;
using WellMonitor.Core.Entities;

namespace WellMonitor.Application.Mappings
{
    public class WellMapper : Profile
    {
        public WellMapper()
        {
            CreateMap<WellEntity, WellResponse>()
                .ForMember(response => response.CompanyName,
                opt => opt.MapFrom(well => well.Company.Name));

            CreateMap<WellEntity, WellDepthResponse>()
                .ForMember(response => response.CompanyName,
                opt => opt.MapFrom(well => well.Company.Name))
                .ForMember(response => response.PassedDepth,
                opt => opt.MapFrom(well => well.CalculatePassedDepth()));
        }
    }
}
