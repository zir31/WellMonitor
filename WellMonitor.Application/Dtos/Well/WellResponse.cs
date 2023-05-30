namespace WellMonitor.Application.Dtos.Well
{
    public record WellResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CompanyName { get; set; }

        public bool Active { get; set; }
    }
}
