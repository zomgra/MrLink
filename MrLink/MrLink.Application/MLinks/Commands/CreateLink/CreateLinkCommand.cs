using MediatR;

namespace MrLink.Application.MLinks.Commands.CreateLink
{
    public class CreateLinkCommand : IRequest<string>
    {
        public Guid UserId { get; set; }
        public string Link { get; set; }
    }
}
