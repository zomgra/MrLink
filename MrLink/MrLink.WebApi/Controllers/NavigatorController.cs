using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MrLink.Application.Interfaces;
using MrLink.Application.MLinks.Commands.ViewLink;

namespace MrLink.WebApi.Controllers
{
    public class NavigatorController : BaseController
    {
        private readonly ILinkDbContext _context;
        private readonly IMapper _mapper;


        public NavigatorController(ILinkDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Go(Guid guid)
        {
            var command = new ViewLinkCommand()
            {
                LinkId = guid,
            };
            var url = await Mediator.Send(command);
            
            return Redirect(url);
        }
       // public IActionResult NoFound()
        //{
        //    return View();
        //}
    }
}
