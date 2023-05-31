namespace WellMonitor.Application.Dtos.Well
{
    public record WellCompanyIdTimePeriodRequest
    {
        public int CompanyId { get; init; }

        public DateTime DateStart { get; init; } = DateTime.UtcNow.AddDays(-10);

        public DateTime DateEnd { get; init; } = DateTime.UtcNow;
    }
}
