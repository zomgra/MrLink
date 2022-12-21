using MediatR;
using Microsoft.EntityFrameworkCore;
using MrLink.Application.Interfaces;

namespace MrLink.Application.MLinks.Commands.ViewLink
{
    public class ViewLinkCommandHandler : IRequestHandler<ViewLinkCommand, string>
    {
        private readonly ILinkDbContext _context;

        public ViewLinkCommandHandler(ILinkDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(ViewLinkCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Links.FirstOrDefaultAsync(c => c.LinkId == request.LinkId, cancellationToken);
            if (entity == null) throw new Exception("Entitity not found");

            if(entity.Transitions.TryGetValue(DateTime.Today, out int value))
            {
                entity.Transitions[DateTime.Today] = value+1;
            }
            else
            {
                entity.Transitions[DateTime.Today] = 1;
            }
            _context.Links.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Link;
        }
    }
}
