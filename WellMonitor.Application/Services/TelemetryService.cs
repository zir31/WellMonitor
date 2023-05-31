using AutoMapper;
using WellMonitor.Application.Dtos.Telemetry;
using WellMonitor.Application.Interfaces;
using WellMonitor.Core.Entities;
using WellMonitor.Core.Exceptions;
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
            foreach (var request in requests)
            {
                var spec = new WellByIdSpecification(request.WellId);
                var wells = await _unitOfWork.WellRepository.FindWithSpecificationPatternAsync(spec, false);

                var well = wells.SingleOrDefault() ?? throw new EntityNotFoundException(nameof(WellEntity), $"id = {request.WellId}");

                if (!well.Telemetries.Any() || request.Depth >= well.Telemetries.Max(t => t.Depth))
                {
                    well.Deadline = new WellActivityDeadlineEntity()
                    {
                        WellId = well.Id,
                        Deadline = DateTime.UtcNow.Date.AddDays(5)
                    };
                    well.Active = true;

                    _unitOfWork.WellRepository.Update(well);
                    _unitOfWork.TelemetryRepository.Create(_mapper.Map<TelemetryEntity>(request));
                }
            }
            
            await _unitOfWork.SaveChangesAsync();
        }

        private async Task GenerateRandomTelemetries()
        {
            var spec = new WellWithDeadlinesSpecification();
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
