
using Advert.Applications;
using Advert.Domain.Dtos;
using Advert.Domain.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Areas.cms
{
 
    public class LoginController : Controller
    {
        private readonly IUserService _service;
        public LoginController(IUserService service)
        {
            _service = service;

        }
        [Route("/Login/Login/")]
        public IActionResult Login(string? ReturnUrl = null)
        {
            LoginViewModel vm = new LoginViewModel();
            vm.Returnurl = ReturnUrl ?? "Index";
            return View(vm);
        }


        [HttpPost("LoginProc")]
        public async Task<IActionResult> LoginProc(LoginPostDto userModel, string? ReturnUrl = null)
        {
            ReturnUrl=ReturnUrl?? "/"; 



            var result = await _service.LoginProcess(userModel);
            if (!result.Status)
                return Ok(new OperationResultDto<string>(message: result.Message, result: ReturnUrl, status: false));

            var identity = new ClaimsIdentity(new Claim[]
            {
                    new Claim(ClaimTypes.Name, result.Result.CompanyName),
                    new Claim(ClaimTypes.Email,result.Result.Phone),
                    
            }, 
            CookieAuthenticationDefaults.AuthenticationScheme);  
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties
            {
                ExpiresUtc = DateTime.UtcNow.AddDays(1),
                IsPersistent = true,
                AllowRefresh = false
            });

            if (Url.IsLocalUrl(ReturnUrl))
            {
                return Ok(new OperationResultDto<string>(message: result.Message, result: ReturnUrl, status: true));
            }
            return Ok(new OperationResultDto<string>(message: result.Message, result: "/cms", status: true));



        }

        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}
