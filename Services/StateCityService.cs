using WebTestMVC.Data;
using Microsoft.EntityFrameworkCore;
using WebTestMVC.Models;


namespace WebTestMVC.Services
{
    public sealed class StateCityService
    {
        public IEnumerable<StateCityViewModel> GetStateCity()
        {
            AppDbContext dbContext = new();
           var cityStateDetail= dbContext.city
                .Join(dbContext.state,
                city => city.StateId,
                state => state.Id,
                (city, state) => new StateCityViewModel
                {
                    CityName = city.Name,
                    StateName = state.Name,
                    StateCode = state.Code,
                }).ToList(); 
            return cityStateDetail;
        }
    }
}
