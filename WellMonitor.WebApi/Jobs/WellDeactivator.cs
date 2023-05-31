using Quartz;
using WellMonitor.Core.Interfaces;
using WellMonitor.Core.Specifications.Well;

namespace WellMonitor.WebApi.Jobs
{
    public class WellDeactivator : IJob
    {
        private readonly IUnitOfWork _unitOfWork;

        public WellDeactivator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            var spec = new WellWithDeadlinesSpecification();
            var wells = await _unitOfWork.WellRepository.FindWithSpecificationPatternAsync(spec, false);
            var today = DateTime.UtcNow.Date;

            foreach (var well in wells)
            {
                if (today >= well.Deadline.Deadline)
                {
                    well.Active = false;
                    _unitOfWork.WellActivityDeadlineRepository.Delete(well.Deadline);
                }
                _unitOfWork.WellRepository.Update(well);
            }

            await _unitOfWork.SaveChangesAsync();

            return;
        }
    }
}
