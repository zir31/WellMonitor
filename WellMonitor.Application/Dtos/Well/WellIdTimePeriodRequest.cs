namespace WellMonitor.Application.Dtos.Well
{
    public record WellIdTimePeriodRequest
    {
        public int Id { get; init; }

        public DateTime DateStart { get; init; }

        public DateTime DateEnd { get; init; }
    }
}
