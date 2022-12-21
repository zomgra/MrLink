using MediatR;
using Microsoft.EntityFrameworkCore;
using MrLink.Application.Interfaces;

namespace MrLink.Application.MLinks.Commands.DeleteLink
{
    public class DeleteLinkCommandHandler : IRequestHandler<DeleteLinkCommand>
    {
        private readonly ILinkDbContext _context;

        public DeleteLinkCommandHandler(ILinkDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteLinkCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Links
               .FindAsync(new object[] { request.LinkId }, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new Exception("Entity Not found");
            }
            _context.Links.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
