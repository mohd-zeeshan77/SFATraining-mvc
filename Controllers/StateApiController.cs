using Microsoft.AspNetCore.Mvc;
using WebTestMVC.Services;

namespace WebTestMVC.Controllers;

public class StateApiController : Controller
{
    private readonly StateApiService _stateApiService;

    public StateApiController(StateApiService stateApiService)
    {
        _stateApiService = stateApiService ?? throw new ArgumentNullException(nameof(stateApiService));
    }

    [HttpGet]
    [Route("api/state")]
    public IActionResult Get()
    {
        var states = _stateApiService.GetAllStates();

        return Ok(states);
    }

    [HttpGet]
    [Route("api/state/{Id:int}")]
    public IActionResult Get(int Id)
    {
        try
        {
            var state = _stateApiService.getStateById(Id);
            return Ok(state);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
}