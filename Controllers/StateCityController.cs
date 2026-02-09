using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebTestMVC.Data;
using WebTestMVC.Services;

namespace WebTestMVC.Controllers
{
    public sealed class StateCityController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            StateCityService stateCityService = new();
            var view = stateCityService.GetStateCity();
            return View(view);
        }
    }
}
