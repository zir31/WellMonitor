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
        /// Предоставляет скважины по id подрядчика или по названию подрядчика
        /// </summary>
        /// <response code="200">Запрос был успешно обработан сервером</response>
        /// <response code="500">На стороне сервера возникла внутренняя ошибка</response>
        [HttpGet]
        public async Task<IActionResult> GetWellByCompanyIdOrCompanyNameAsync([FromQuery]WellCompanyIdNameRequest request)
        {
            var entities = await _wellService.GetWellByCompanyIdOrCompanyNameAsync(request.Id, request.Name);

            return Ok(entities);
        }

        /// <summary>
        /// Предоставляет активные скважины по id подрядчика или по названию подрядчика
        /// </summary>
        /// <response code="200">Запрос был успешно обработан сервером</response>
        /// <response code="500">На стороне сервера возникла внутренняя ошибка</response>
        [HttpGet]
        [Route("active")]
        public async Task<IActionResult> GetActiveWellByIdOrCompanyNameAsync([FromQuery] WellCompanyIdNameRequest request)
        {
            var entities = await _wellService.GetActiveWellByCompanyIdOrCompanyNameAsync(request.Id, request.Name);

            return Ok(entities);
        }

        /// <summary>
        /// Предоставляет активные скважины с работающими на них подрядчиками
        /// </summary>
        /// <response code="200">Запрос был успешно обработан сервером</response>
        /// <response code="500">На стороне сервера возникла внутренняя ошибка</response>
        [HttpGet]
        [Route("all/active")]
        public async Task<IActionResult> GetAllActiveWellsAsync()
        {
            var entities = await _wellService.GetAllActiveWellsAsync();

            return Ok(entities);
        }

        /// <summary>
        /// Предоставляет прохождение суммарной глубины скважины по id скважины и периоду
        /// </summary>
        /// <response code="200">Запрос был успешно обработан сервером</response>
        /// <response code="404">Скважина с данным id была не найдена</response>
        /// <response code="500">На стороне сервера возникла внутренняя ошибка</response>
        [HttpGet]
        [Route("date-period")]
        public async Task<IActionResult> GetWellByIdBetweenDates([FromQuery]WellIdTimePeriodRequest request)
        {
            var entity = await _wellService.GetWellWithDepthByIdBetweenDatesAsync(request.Id, request.DateStart, request.DateEnd);

            return Ok(entity);
        }

        /// <summary>
        /// Предоставляет активные скважины с прохождением суммарной глубины по id компании
        /// </summary>
        /// <response code="200">Запрос был успешно обработан сервером</response>
        /// <response code="500">На стороне сервера возникла внутренняя ошибка</response>
        [HttpGet]
        [Route("active-date-period")]
        public async Task<IActionResult> GetActiveWellsByCompanyIdBetweenDates([FromQuery] WellCompanyIdTimePeriodRequest request)
        {
            var entity = await _wellService.GetActiveWellWithDepthByCompanyIdBetweenDatesAsync(request.CompanyId, request.DateStart, request.DateEnd);

            return Ok(entity);
        }
    }
}