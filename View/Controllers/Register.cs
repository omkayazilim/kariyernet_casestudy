using Advert.Applications;
using Advert.Domain.Dtos;
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
        public async Task<OperationResultDto> RegisterPost(RegisterDto input) 
        {
            if (!ModelState.IsValid)
            {
                return new OperationResultDto(false,"Alan Boş Geçilemez !");
            }
            var resp=  await _service.RegisterProcess(input);
            return resp;
        
        }
    }
}
