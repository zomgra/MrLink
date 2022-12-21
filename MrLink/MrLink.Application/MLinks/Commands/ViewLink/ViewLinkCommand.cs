using MediatR;

namespace MrLink.Application.MLinks.Commands.ViewLink
{
    public class ViewLinkCommand : IRequest<string>
    {
        public Guid LinkId { get; set; }
    }
}
