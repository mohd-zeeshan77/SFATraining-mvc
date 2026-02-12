using WebTestMVC.Data;
using WebTestMVC.Models;

namespace WebTestMVC.Services;

public sealed class StateCityService
{
    private readonly AppDbContext _dbContext;

    public StateCityService(AppDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public IEnumerable<StateCityViewModel> GetStateCity()
    {
        IReadOnlyList<StateCityViewModel> cityStateDetail = _dbContext.City
            .Join(_dbContext.State,
                city => city.StateId,
                state => state.Id,
                (city, state) => new StateCityViewModel
                {
                    CityName = city.Name,
                    StateName = state.Name,
                    StateCode = state.Code
                }).ToList();
        return cityStateDetail;
    }
}