using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MrLink.Application.MLinks.Commands.CreateLink;
using MrLink.Application.MLinks.Queries.GetLinkInfo;
using MrLink.Application.MLinks.Queries.GetLinkList;

namespace MrLink.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MLinkController : BaseController
    {
        private readonly IMapper _mapper;

        public MLinkController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        [ResponseCache( Duration = 30)]
        public async Task<ActionResult<LinkListVm>> GetAll()
        {
            var query = new GetLinkListQuery()
            {
                UserId = UserId
            };
            var list = await Mediator.Send(query);
            return list;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<LinkInfoVm>> Get(Guid id)
        {
            var query = new GetLinkInfoQuery() { LinkId = id, UserId = UserId };
            var info = await Mediator.Send(query);
            return info;
        }

        [HttpPost]
        public async Task<ActionResult<string>> Create([FromBody]string link)
        {
            var command = new CreateLinkCommand()
            {
                UserId = UserId,
                Link = link,
            };
            var readyLink = await Mediator.Send(command);
            return Ok(readyLink);
        }
    }
}
