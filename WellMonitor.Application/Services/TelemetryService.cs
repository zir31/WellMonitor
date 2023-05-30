using AutoMapper;
using WellMonitor.Application.Dtos.Telemetry;
using WellMonitor.Application.Interfaces;
using WellMonitor.Core.Entities;
using WellMonitor.Core.Interfaces;
using WellMonitor.Core.Specifications.Well;

namespace WellMonitor.Application.Services
{
    public class TelemetryService : ITelemetryService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public TelemetryService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task AddTelemetries(IEnumerable<TelemetryAddRequest> requests)
        {
            var entities = _mapper.Map<IEnumerable<TelemetryEntity>>(requests);

            _unitOfWork.TelemetryRepository.CreateRange(entities);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task GenerateRandomTelemetries()
        {
            var spec = new WellWithTelemetriesSpecification();
            var wells = await _unitOfWork.WellRepository.FindWithSpecificationPatternAsync(spec);

            var random = new Random();

            foreach (var well in wells)
            {
                if(random.Next(0,2) == 1)
                {
                    _unitOfWork.TelemetryRepository.Create(
                        new TelemetryEntity
                        {
                            WellId = well.Id,
                            Date_time = DateTime.UtcNow,
                            Depth = (well.Telemetries.Any() ? well.Telemetries.Max(w => w.Depth) : 0) + random.Next(0, 10)
                        });
                    well.Active = true;
                    _unitOfWork.WellRepository.Update(well);
                }
            }

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
