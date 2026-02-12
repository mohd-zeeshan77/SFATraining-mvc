using WebTestMVC.Data;
using WebTestMVC.Models;

namespace WebTestMVC.Services;

public sealed class StateService
{
    private readonly AppDbContext _dbContext;

    public StateService(AppDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public IEnumerable<StateViewModel> GetStates()
    {
        IReadOnlyList<StateViewModel> states = _dbContext.State
            .Select(s => new StateViewModel
            {
                Id = s.Id,
                Name = s.Name,
                Code = s.Code
            }).ToList();
        return states;
    }

    public IEnumerable<StateViewModel> CreateStates(StateViewModel model)
    {
        State state = new() { Name = model.Name, Code = model.Code };
        _dbContext.Add(state);
        _dbContext.SaveChanges();
        return GetStates();
    }
}