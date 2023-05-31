using Microsoft.AspNetCore.Mvc;
using WellMonitor.Application.Dtos.Telemetry;
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
        /// Добавляет показания телеметрии
        /// </summary>
        /// <response code="200">Запрос был успешно обработан сервером</response>
        /// <response code="500">На стороне сервера возникла внутренняя ошибка</response>
        [HttpPost]
        public async Task<IActionResult> AddTelemetries([FromBody]IEnumerable<TelemetryAddRequest> requests)
        {
            await _telemetryService.AddTelemetries(requests);

            return Ok();
        }
    }
}