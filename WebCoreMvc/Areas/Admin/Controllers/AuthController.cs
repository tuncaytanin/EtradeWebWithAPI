using Entities.Dtos.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using WebCoreMvc.ApiServices;
using WebCoreMvc.ApiServices.Interfaces;

namespace WebCoreMvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthController : Controller
    {

        private IAuthApiService _authApiService;
        private IHttpContextAccessor _httpContextAccessor;
        public AuthController(IAuthApiService authApiService,IHttpContextAccessor httpContextAccessor)
        {
            _authApiService = authApiService;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var user = await _authApiService.LoginAsync(loginDto);
            if (user.Success) {
                _httpContextAccessor.HttpContext.Session.SetString("token", user.Data.Token);
                var userClaims = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                userClaims.AddClaim(new Claim(ClaimTypes.NameIdentifier,user.Data.Id.ToString()));
                userClaims.AddClaim(new Claim(ClaimTypes.Name,user.Data.UserName));
                var claimPrincipal = new ClaimsPrincipal(userClaims);
                var authProperties = new AuthenticationProperties() { IsPersistent = loginDto.IsRememberMe };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,claimPrincipal,authProperties);
                return RedirectToAction("Index","User",new {area="Admin"});
            }
            else
            {
                ModelState.AddModelError("","Kullanıcı Adı veya Şifre Hatalı");
            }
            return View("Index",loginDto);
        }
    }
}
