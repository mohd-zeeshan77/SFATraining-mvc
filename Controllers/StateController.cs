using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebTestMVC.Data;
using WebTestMVC.Models;
using WebTestMVC.Services;

namespace WebTestMVC.Controllers
{
    public sealed class StateController : Controller
    {
        public IActionResult Index()
        {
            StateService stateService = new StateService();
            IEnumerable<StateViewModel> states = stateService.GetStates();
            return View(states);
        }
        [HttpGet]
        public IActionResult Create() { 
            return View();
        }
        [HttpPost]
        public IActionResult Create(StateViewModel state)
        {
            if (!ModelState.IsValid)
            {
                return View(state);
            }

            StateService stateService = new StateService();
            IEnumerable<StateViewModel> result  = stateService.CreateStates(state);
           
            return RedirectToAction("Index");
        }
    }
}
