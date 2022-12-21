using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MrLink.Application.Interfaces;

namespace MrLink.Application.MLinks.Queries.GetLinkList
{
    public class GetLinkListQueryHandler : IRequestHandler<GetLinkListQuery, LinkListVm>
    {
        private readonly IMapper _mapper;
        private readonly ILinkDbContext _context;

        public GetLinkListQueryHandler(IMapper mapper, ILinkDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<LinkListVm> Handle(GetLinkListQuery request, CancellationToken cancellationToken)
        {
            var links =  await _context.Links.Where(l => l.UserId == request.UserId)
                .ProjectTo<MLinkLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return new LinkListVm { Links = links };
        }
    }
}
