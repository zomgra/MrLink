using System.ComponentModel.DataAnnotations.Schema;

namespace MrLink.Domain
{
    public class MLink
    {
        public Guid LinkId { get; set; }
        public Guid UserId { get; set; } = Guid.Empty;
        public string Link { get; set; } = string.Empty;

        [NotMapped]
        public Dictionary<DateTime, int> Transitions { get; set; }
        public string FullLink { get; set; }
    }
}
