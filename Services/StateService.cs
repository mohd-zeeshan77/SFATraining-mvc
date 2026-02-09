using WebTestMVC.Data;
using WebTestMVC.Models;

namespace WebTestMVC.Services
{
    public sealed class StateService
    {
        public IEnumerable<StateViewModel> GetStates()
        {
            AppDbContext dbContext = new();
            IReadOnlyList<StateViewModel> states = dbContext.state
                                                .Select(s => new StateViewModel
                                                {
                                                    Id = s.Id,
                                                    Name = s.Name,
                                                    Code = s.Code
                                                }).ToArray();
            return states;
        }
        public IEnumerable<StateViewModel> CreateStates(StateViewModel model) {
            AppDbContext dbContext = new();
            State state = new() { Name =  model.Name, Code = model.Code };
            dbContext.Add(state);
            dbContext.SaveChanges();
            return GetStates();
        }
    }
}
