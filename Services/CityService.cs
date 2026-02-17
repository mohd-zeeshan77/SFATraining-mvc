using Microsoft.EntityFrameworkCore;
using WebTestMVC.Data;
using WebTestMVC.Dtos;
using WebTestMVC.Models;

namespace WebTestMVC.Services;

public class CityService
{
    private readonly AppDbContext _dbContext;

    public CityService(AppDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public IEnumerable<CityViewModel> GetCities()
    {
        IReadOnlyList<CityViewModel> cities = _dbContext.City
            .Include(c => c.State)
            .Select(c => new CityViewModel
            {
                Id = c.Id,
                Name = c.Name,
                StateId = c.StateId,
                States = null
            }).ToList();
        return cities;
    }

    public IEnumerable<CityViewModel> CreateCities(CityViewModel model)
    {
        if (!model.StateId.HasValue) throw new ArgumentException("State is required");
        City city = new() { Name = model.Name, StateId = model.StateId.Value };
        _dbContext.Add(city);
        _dbContext.SaveChanges();
        return GetCities();
    }

    public IEnumerable<CityDto> GetAll()
    {
        return _dbContext.City.Select(city => new CityDto(city.Id, city.Name, city.StateId))
            .ToList();
    }
    public IEnumerable<CityDto> GetAllByState(int StateId)
    {
        return _dbContext.City
            .Where(city => city.StateId == StateId)
            .Select(city => new CityDto(city.Id, city.Name, city.StateId))
            .ToList();
    }
    public void AddCity(int StateId, CreateCityRequest request)
    {
        State? state = _dbContext.State.Find(StateId);
        if (state == null) throw new KeyNotFoundException($"state id {StateId} not found in");
        City city = new() { Name = request.Name, StateId = StateId };
        _dbContext.Add(city);
        _dbContext.SaveChanges();

    }

}