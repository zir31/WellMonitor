namespace WellMonitor.Application.Dtos.Well
{
    public record WellDepthResponse
    {
        public string Name { get; set; }

        public string CompanyName { get; set; }

        public bool Active { get; set; }

        public float PassedDepth { get; set; }
    }
}
