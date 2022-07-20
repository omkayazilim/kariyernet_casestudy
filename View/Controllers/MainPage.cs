


using Advert.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Advert.View.Controllers
{
    [Authorize]
    public class MainPage : Controller
    {

       
        public MainPage(IAppBussiness apbussiness)
        {
        }
        public async Task<IActionResult> Index()
        {
            
            return View();
        }

      




    }
}
