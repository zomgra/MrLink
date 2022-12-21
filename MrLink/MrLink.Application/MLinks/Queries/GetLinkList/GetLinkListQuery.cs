using MediatR;

namespace MrLink.Application.MLinks.Queries.GetLinkList
{
    public class GetLinkListQuery : IRequest<LinkListVm>
    {
        public Guid UserId { get; set; }
    }
}
