namespace WellMonitor.Application.Dtos.Well
{
    public record WellCompanyIdTimePeriodRequest
    {
        public int CompanyId { get; init; }

        public DateTime DateStart { get; init; }

        public DateTime DateEnd { get; init; }
    }
}
