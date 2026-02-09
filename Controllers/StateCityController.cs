using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebTestMVC.Data;
using WebTestMVC.Models;
using WebTestMVC.Services;

namespace WebTestMVC.Controllers
{
    public sealed class StateCityController : Controller
    {
        private readonly StateCityService _stateCityService;
        public StateCityController(StateCityService stateCityService)
        {
            _stateCityService = stateCityService ?? throw new ArgumentNullException(nameof(stateCityService));
        }
        public IActionResult Index()
        {
            
            IEnumerable<StateCityViewModel> view = _stateCityService.GetStateCity();
            return View(view);
        }
    }
}
