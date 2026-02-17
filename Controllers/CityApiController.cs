using Microsoft.AspNetCore.Mvc;
using WebTestMVC.Dtos;
using WebTestMVC.Services;

namespace WebTestMVC.Controllers
{
    public class CityApiController : ControllerBase
    {
        private readonly CityService _cityService;
        public CityApiController(CityService cityService)
        {
            _cityService = cityService ?? throw new ArgumentNullException(nameof(cityService));
        }
        [HttpGet]
        [Route("api/city")]
        public IActionResult Get()
        {
            IEnumerable<CityDto> result = _cityService.GetAll();
            return Ok(result);
        }
        [HttpGet]
        [Route("api/state/{StateId:int}/city")]
        public IActionResult GetByState(int StateId)
        {
            IEnumerable<CityDto> res = _cityService.GetAllByState(StateId);
            return Ok(res);
        }
        [HttpPost]
        [Route("api/state/{StateId:int}/city")]
        public IActionResult Add(int StateId, [FromBody] CreateCityRequest request)
        {
            try
            {
                _cityService.AddCity(StateId, request);
                return Ok();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
