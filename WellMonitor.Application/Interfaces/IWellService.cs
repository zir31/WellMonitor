using WellMonitor.Application.Dtos.Well;

namespace WellMonitor.Application.Interfaces
{
    public interface IWellService
    {
        Task<IEnumerable<WellResponse>> GetWellByCompanyIdOrCompanyNameAsync(int? id, string name);

        Task<IEnumerable<WellResponse>> GetActiveWellByCompanyIdOrCompanyNameAsync(int? id, string name);

        Task<IEnumerable<WellResponse>> GetAllActiveWellsAsync();

        Task<WellDepthResponse> GetWellWithDepthByIdBetweenDatesAsync(int id, DateTime startDate, DateTime endDate);

        Task<IEnumerable<WellDepthResponse>> GetActiveWellWithDepthByCompanyIdBetweenDatesAsync(int companyId, DateTime startDate, DateTime endDate);
    }
}
