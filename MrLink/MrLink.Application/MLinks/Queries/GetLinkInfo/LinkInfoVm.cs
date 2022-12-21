using AutoMapper;
using MrLink.Application.Common.Mapping;
using MrLink.Domain;

namespace MrLink.Application.MLinks.Queries.GetLinkInfo
{
    public class LinkInfoVm : IMapWith<MLink>
    {
        public Guid LinkId { get; set; }
        public string Link { get; set; }
        public Dictionary<DateTime, int> Transitions { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<MLink, LinkInfoVm>()
                .ForMember(l=>l.Transitions, l=>l.MapFrom(l=>l.Transitions))
                .ForMember(l => l.Link, l => l.MapFrom(l => l.Link))
                .ForMember(l => l.LinkId, l => l.MapFrom(l => l.LinkId));
        }
    }
}