using AutoMapper;
using WellMonitor.Application.Dtos.Well;
using WellMonitor.Application.Interfaces;
using WellMonitor.Core.Entities;
using WellMonitor.Core.Exceptions;
using WellMonitor.Core.Interfaces;
using WellMonitor.Core.Specifications.Well;

namespace WellMonitor.Application.Services
{
    public class WellService : IWellService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public WellService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<WellResponse>> GetActiveWellByCompanyIdOrCompanyNameAsync(int? id, string name)
        {
            var spec = new WellActiveByCompanyIdOrNameSpecification(id, name);

            var wells = await _unitOfWork.WellRepository.FindWithSpecificationPatternAsync(spec, true);

            return _mapper.Map<IEnumerable<WellResponse>>(wells);
        }

        public async Task<IEnumerable<WellResponse>> GetWellByCompanyIdOrCompanyNameAsync(int? id, string name)
        {
            var spec = new WellByCompanyIdOrNameSpecification(id, name);

            var wells = await _unitOfWork.WellRepository.FindWithSpecificationPatternAsync(spec);

            return _mapper.Map<IEnumerable<WellResponse>>(wells);
        }

        public async Task<IEnumerable<WellResponse>> GetAllActiveWellsAsync()
        {
            var spec = new WellActiveSpecification();

            var wells = await _unitOfWork.WellRepository.FindWithSpecificationPatternAsync(spec);

            return _mapper.Map<IEnumerable<WellResponse>>(wells);
        }

        public async Task<WellDepthResponse> GetWellWithDepthByIdBetweenDatesAsync(int id, DateTime startDate, DateTime endDate)
        {
            var spec = new WellByIdBetweenDatesSpecification(id, startDate.Date, endDate.Date.AddDays(1));

            var wells = await _unitOfWork.WellRepository.FindWithSpecificationPatternAsync(spec);
            var well = wells.SingleOrDefault() ?? throw new EntityNotFoundException(nameof(WellEntity), $"id = {id}");

            return _mapper.Map<WellDepthResponse>(well);
        }

        public async Task<IEnumerable<WellDepthResponse>> GetActiveWellWithDepthByCompanyIdBetweenDatesAsync(int companyId, DateTime startDate, DateTime endDate)
        {
            var spec = new WellActiveByCompanyIdBetweenDatesSpecification(companyId, startDate.Date, endDate.Date.AddDays(1));

            var wells = await _unitOfWork.WellRepository.FindWithSpecificationPatternAsync(spec);       

            return _mapper.Map<IEnumerable<WellDepthResponse>>(wells);
        }
    }
}
