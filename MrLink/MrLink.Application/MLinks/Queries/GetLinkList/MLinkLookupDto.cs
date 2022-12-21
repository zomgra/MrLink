using AutoMapper;
using MrLink.Application.Common.Mapping;
using MrLink.Domain;

namespace MrLink.Application.MLinks.Queries.GetLinkList
{
    public class MLinkLookupDto : IMapWith<MLink>
    {
        public Guid LinkId { get; set; }
        public string Link { get; set; }

        public string FullLink { get; set; }
        public Dictionary<DateTime, int> Transitions { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<MLink, MLinkLookupDto>()
                .ForMember(l=>l.Transitions, o=>o.MapFrom(o=>o.Transitions))
                .ForMember(l=>l.LinkId, o=>o.MapFrom(o=>o.LinkId))
                .ForMember(l => l.FullLink, o => o.MapFrom(o => o.FullLink))
                .ForMember(l=>l.FullLink,o=>o.MapFrom(o=>o.FullLink));
        }
    }
}