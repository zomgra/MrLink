using MediatR;
using MrLink.Application.Common.Fabrics;
using MrLink.Application.Interfaces;
using MrLink.Domain;

namespace MrLink.Application.MLinks.Commands.CreateLink
{
    public class CreateLinkCommandHandler : IRequestHandler<CreateLinkCommand, string>
    {
        private readonly ILinkDbContext _context;

        public CreateLinkCommandHandler(ILinkDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(CreateLinkCommand request, CancellationToken cancellationToken)
        {
            var fabric = new MLinkFabric(request.Link);
            var entity = fabric.CreateLink(request.UserId);
            await _context.Links.AddAsync(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.FullLink;
        }
    }
}
