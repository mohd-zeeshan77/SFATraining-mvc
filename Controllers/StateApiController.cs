using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebTestMVC.Dtos;
using WebTestMVC.Services;

namespace WebTestMVC.Controllers;

[Route("api/state")]
public class StateApiController : ControllerBase
{
    private readonly StateService _stateService;

    public StateApiController(StateService stateService)
    {
        _stateService = stateService ?? throw new ArgumentNullException(nameof(stateService));
    }

    [HttpGet]
    [Route("")]
    public IActionResult Get()
    {
        IEnumerable<StateDto> states = _stateService.GetAllStates();

        return Ok(states);
    }

    [HttpGet]
    [Route("{Id:int}")]
    public IActionResult Get(int Id)
    {
        StateDto? state = _stateService.GetState(Id);
        return state is null ? NotFound() : Ok(state);
    }

    [HttpPost]
    [Route("")]
    public IActionResult Create([FromBody] CreateStateRequest request) {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        bool result = _stateService.CreateState(request);
        return Ok(result);
    }
    [HttpPut]
    [Route("{Id:int}")]
    public IActionResult Create([FromBody] CreateStateRequest request, int Id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        StateDto? state = _stateService.UpdateState(Id,request);
        return state is null ? Conflict() : Ok(state);
    }
}