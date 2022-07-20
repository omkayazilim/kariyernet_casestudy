using Advert.Applications;
using Advert.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Advert.View.Controllers
{
    public class Register : Controller
    {
        private readonly IUserService _service;
        public Register(IUserService service)
        {
            _service = service; 
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("RegisterPost")]
        public string RegisterPost(string Phone, string CompanyName,string Adress,string Password) 
        {

            return "";
        
        }
    }
}
