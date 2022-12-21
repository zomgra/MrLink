using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MrLink.IdentityServer.Models;
using System.IdentityModel.Tokens.Jwt;

namespace MrLink.IdentityServer.Controllers
{
    public class AuthController : Controller
    {
        private readonly SignInManager<AppUser> _singInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IIdentityServerInteractionService _interactionService;

        public AuthController(SignInManager<AppUser> singInManager, UserManager<AppUser> userManager, IIdentityServerInteractionService interactionService)
        {
            _singInManager = singInManager;
            _userManager = userManager;
            _interactionService = interactionService;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            var vm = new LoginViewModel { ReturnUrl = returnUrl };
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var user = await _userManager.FindByNameAsync(viewModel.Username);
            if(user == null)
            {
                ModelState.AddModelError(String.Empty, "User not found");
                return View(viewModel);
            }
            var res = await _singInManager.PasswordSignInAsync(viewModel.Username, viewModel.Password, false, false);
            if (res.Succeeded)
            {
                return Redirect(viewModel.ReturnUrl);
            }
            ModelState.AddModelError(string.Empty, "Login error");

            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Register(string returnUrl)
        {
            var viewModel = new RegisterViewModel()
            {
                ReturnUrl = returnUrl
            };
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel viewModel)
        {
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("sub");
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            var user = new AppUser()
            {
                UserName = viewModel.Username,
                
            };
            var result = await _userManager.CreateAsync(user, viewModel.Password);
            if (result.Succeeded)
            {
                await _singInManager.SignInAsync(user, false);
                return Redirect(viewModel.ReturnUrl);
            }
            ModelState.AddModelError("", "Error occurred");
            return View(viewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Logout(string logoutId)
        {
            await _singInManager.SignOutAsync();
            var logoutRequest = await _interactionService.GetLogoutContextAsync(logoutId);
            return Redirect(logoutRequest.PostLogoutRedirectUri);
        }
    }
}
