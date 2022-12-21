using MediatR;

namespace MrLink.Application.MLinks.Queries.GetLinkInfo
{
    public class GetLinkInfoQuery : IRequest<LinkInfoVm>
    {
        public Guid LinkId { get; set; }
        public Guid UserId { get; set; }
    }
}
