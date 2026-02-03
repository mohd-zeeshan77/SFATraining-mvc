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
            var view = dbContext.state.Select(s=> new {s.Name,s.Code}).ToList();
            return View(view);
        }
    }
}
