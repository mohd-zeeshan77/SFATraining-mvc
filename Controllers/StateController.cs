using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebTestMVC.Data;

namespace WebTestMVC.Controllers
{
    public sealed class StateController : Controller
    {
        
        public IActionResult Index()
        {
            AppDbContext dbContext = new();
            //var view = dbContext.state.Select(s => new { s.Name, s.Code }).ToList();

            var view = dbContext.city.Join(dbContext.state, city => city.StateId, state => state.Id,
                (city, state) => new
                {
                    CityName = city.Name,
                    StateName = state.Name,
                    StateCode = state.Code
                }).ToList();
            return View(view);
        }
    }
}
