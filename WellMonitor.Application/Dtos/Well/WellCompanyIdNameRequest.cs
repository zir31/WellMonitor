namespace WellMonitor.Application.Dtos.Well
{
    public record WellCompanyIdNameRequest
    {
        public int? Id { get; init; }

        public string? Name { get; init; }
    }
}
