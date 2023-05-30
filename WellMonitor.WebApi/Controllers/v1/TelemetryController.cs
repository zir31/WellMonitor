using Microsoft.AspNetCore.Mvc;
using WellMonitor.Application.Dtos.Telemetry;
using WellMonitor.Application.Dtos.Well;
using WellMonitor.Application.Interfaces;

namespace WellMonitor.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/telemetry")]
    public class TelemetryController : BaseController
    {
        private readonly ILogger<WellController> _logger;
        private readonly ITelemetryService _telemetryService;

        public TelemetryController(ILogger<WellController> logger, ITelemetryService telemetryService)
        {
            _logger = logger;
            _telemetryService = telemetryService;
        }

        /// <summary>
        /// Best endpoint ever
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddTelemetries([FromBody]IEnumerable<TelemetryAddRequest> requests)
        {
            await _telemetryService.AddTelemetries(requests);

            return Ok();
        }

        /// <summary>
        /// Best endpoint ever
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("random")]
        public async Task<IActionResult> GenerateRandomTelemetries()
        {
            await _telemetryService.GenerateRandomTelemetries();

            return Ok();
        }
    }
}