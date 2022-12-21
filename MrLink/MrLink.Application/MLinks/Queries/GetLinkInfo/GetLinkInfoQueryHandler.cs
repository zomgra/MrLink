using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MrLink.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrLink.Application.MLinks.Queries.GetLinkInfo
{
    public class GetLinkInfoQueryHandler : IRequestHandler<GetLinkInfoQuery, LinkInfoVm>
    {
        private readonly IMapper _mapper;
        private readonly ILinkDbContext _context;

        public GetLinkInfoQueryHandler(IMapper mapper, ILinkDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<LinkInfoVm> Handle(GetLinkInfoQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Links.FirstOrDefaultAsync(l=>l.LinkId == request.LinkId, cancellationToken);

            if(entity == null || entity.UserId != request.UserId || entity.LinkId != request.LinkId)
            {
                throw new Exception("Entity not found or you don`t have permision");
            }
            return _mapper.Map<LinkInfoVm>(entity);
        }
    }
}
