namespace MrLink.Client.Models
{
    public class MLinkInfoViewModel
    {
        public Guid LinkId { get; set; }
        public string Link { get; set; }
        public Dictionary<DateTime, int> Transitions { get; set; }
    }
}
