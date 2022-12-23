using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MrLink.Client.Models;
using Newtonsoft.Json;
using System.Diagnostics;

namespace MrLink.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly HttpClient client = new();

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                client.SetBearerToken(accessToken);
                var url = _configuration.GetValue<string>("GetListUrl");

                var responce = await client.GetStringAsync(url);
                if (responce == null)
                {
                    return View(new LinkListViewModel());
                }
                var links = JsonConvert.DeserializeObject<LinkListViewModel>(responce);
                return View(links);
            }
            catch
            {
                return View(new LinkListViewModel() { Links = new List<MLinkLookupDto>()});
            }
        }
        [HttpGet]
        [Authorize]
        public IActionResult CreateLink()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public async Task<string> CreateLink(string link)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            client.SetBearerToken(accessToken);

            var url = _configuration.GetValue<string>("CreateLinkUrl");
            var responce = await client.PostAsJsonAsync(url, link);
            if (responce.IsSuccessStatusCode)
            {
                var result = await responce.Content.ReadAsStringAsync();
                return $"Your link: <a href=\"{result}\">{result}</a>";
            }
            return $"ERROR: {responce.StatusCode}, please write me: /..../";
        }
        [Authorize]
        public async Task<ActionResult<MLinkInfoViewModel>> GetInfo(Guid guid)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            client.SetBearerToken(accessToken);

            var url = _configuration.GetValue<string>("GetInfoUrl");
            var responce = await client.GetStringAsync(url + $"{guid}");

            var vm = JsonConvert.DeserializeObject<MLinkInfoViewModel>(responce);

            return View(vm);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}