using Advert.Applications;
using Advert.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Advert.View.Controllers
{
    public class AdvertController : Controller
    {
        private readonly IAdvertService _service;
        public AdvertController(IAdvertService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAdvertsViewModel());
        }

        [HttpGet]
        public IActionResult Create()
        {
            var result = new AdvertListDto();
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(AdvertListDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            var result = await _service.Create(dto);
            if (result.Status)
            { TempData["Success"] = result.Message; }
            else
            { TempData["Error"] = result.Message; }

            return Redirect($"/Advert/Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            return View(await _service.GetAdvertsById(Id));
        }
        [HttpGet]
        public async Task<IActionResult> Delete(long id)
        {
          
            var result = await _service.Delete(id);
            if (result.Status)
            { TempData["Success"] = result.Message; }
            else
            { TempData["Error"] = result.Message; }

            return Redirect($"/Advert/Index");


        }
        [HttpPost]
        public async Task<IActionResult> Edit(AdvertListDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            var result = await _service.Edit(dto);
            if (result.Status)
            { TempData["Success"] = result.Message; }
            else
            { TempData["Error"] = result.Message; }

            return Redirect($"/Advert/Index");


        }

    }
}
