using MediatR;

namespace MrLink.Application.MLinks.Commands.DeleteLink
{
    public class DeleteLinkCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid LinkId { get; set; }
    }
}
