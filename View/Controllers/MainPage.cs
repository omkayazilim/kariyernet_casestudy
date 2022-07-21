


using Advert.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Advert.View.Controllers
{
    [Authorize]
    public class MainPage : Controller
    {

       
        public MainPage()
        {
        }
        public async Task<IActionResult> Index()
        {
            
            return View();
        }

      




    }
}
