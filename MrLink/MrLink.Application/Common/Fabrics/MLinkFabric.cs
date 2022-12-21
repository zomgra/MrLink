using MrLink.Domain;
using static System.Net.WebRequestMethods;

namespace MrLink.Application.Common.Fabrics
{
    public class MLinkFabric
    {
        private readonly string _link;

        public MLinkFabric(string link)
        {
            _link = link;
        }
        public MLink CreateLink(Guid userId)
        {
            var guid = Guid.NewGuid();
            var startUrl = "https://localhost:7202/api/Navigator/Go";
            var endUrl = $"{startUrl}?guid={guid}";

            return new MLink
            {
                UserId = userId,
                FullLink = endUrl,
                Link = _link,
                LinkId = guid,
                Transitions = new Dictionary<DateTime, int>(),
            };
        }
    }
}
