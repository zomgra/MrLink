namespace MrLink.Client.Models
{
    public class MLinkLookupDto
    {
        public Guid LinkId { get; set; }
        public string Link { get; set; }
        public string FullLink { get; set; }
        public Dictionary<DateTime, int> Transitions { get; set; }
    }
}