using Microsoft.AspNetCore.Mvc;
using WellMonitor.Core.Specifications.Well;
using WellMonitor.Infrastructure.Interfaces;

namespace WellMonitor.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/well")]
    public class WellController : BaseController
    {
        private readonly ILogger<WellController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public WellController(ILogger<WellController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Best endpoint ever
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public async Task<IActionResult> GetWellByIdAsync(int id)
        {
            var spec = new WellByIdSpecification(id);
            var wellEntity = await _unitOfWork.WellRepository.FindWithSpecificationPatternAsync(spec);

            return Ok(wellEntity.SingleOrDefault());
        }
    }
}