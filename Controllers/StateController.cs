using Microsoft.AspNetCore.Mvc;
using WebTestMVC.Models;
using WebTestMVC.Services;

namespace WebTestMVC.Controllers;

public sealed class StateController : Controller
{
    private readonly StateService _stateService;

    public StateController(StateService stateService)
    {
        _stateService = stateService ?? throw new ArgumentNullException(nameof(stateService));
    }

    public IActionResult Index()
    {
        var states = _stateService.GetStates();
        return View(states);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(StateViewModel state)
    {
        if (!ModelState.IsValid) return View(state);

        var result = _stateService.CreateStates(state);

        return RedirectToAction("Index");
    }
}