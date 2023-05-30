using Microsoft.AspNetCore.Mvc;
using WellMonitor.Application.Dtos.Well;
using WellMonitor.Application.Interfaces;

namespace WellMonitor.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/well")]
    public class WellController : BaseController
    {
        private readonly ILogger<WellController> _logger;
        private readonly IWellService _wellService;

        public WellController(ILogger<WellController> logger, IWellService wellService)
        {
            _logger = logger;
            _wellService = wellService;
        }

        /// <summary>
        /// Best endpoint ever
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetWellByIdOrCompanyNameAsync([FromQuery]WellCompanyIdNameRequest request)
        {
            var entities = await _wellService.GetWellByCompanyIdOrCompanyNameAsync(request.Id, request.Name);

            return Ok(entities);
        }

        /// <summary>
        /// Best endpoint ever
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("active")]
        public async Task<IActionResult> GetActiveWellByIdOrCompanyNameAsync([FromQuery] WellCompanyIdNameRequest request)
        {
            var entities = await _wellService.GetActiveWellByCompanyIdOrCompanyNameAsync(request.Id, request.Name);

            return Ok(entities);
        }

        /// <summary>
        /// Best endpoint ever
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("all/active")]
        public async Task<IActionResult> GetAllActiveWellsAsync()
        {
            var entities = await _wellService.GetAllActiveWells();

            return Ok(entities);
        }

        /// <summary>
        /// Best endpoint ever
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("date-period")]
        public async Task<IActionResult> GetWellByIdBetweenDates([FromQuery]WellIdTimePeriodRequest request)
        {
            var entity = await _wellService.GetWellWithDepthByIdBetweenDates(request.Id, request.DateStart, request.DateEnd);

            return Ok(entity);
        }

        /// <summary>
        /// Best endpoint ever
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("active-date-period")]
        public async Task<IActionResult> GetActiveWellsByCompanyIdBetweenDates([FromQuery] WellCompanyIdTimePeriodRequest request)
        {
            var entity = await _wellService.GetActiveWellWithDepthByCompanyIdBetweenDates(request.CompanyId, request.DateStart, request.DateEnd);

            return Ok(entity);
        }
    }
}