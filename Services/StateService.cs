using WebTestMVC.Data;
using WebTestMVC.Dtos;
using WebTestMVC.Models;

namespace WebTestMVC.Services;

public sealed class StateService
{
    private readonly AppDbContext _dbContext;
    private readonly ILogger<StateService> _logger;

    public StateService(AppDbContext dbContext, ILogger<StateService> logger)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _logger = logger;
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


    public IEnumerable<StateDto> GetAllStates()
    {
        IList<StateDto> states = _dbContext.State
                                    .Select(s => new StateDto(s.Id, s.Name, s.Code))
                                    .ToList();
        return states;
    }

    public bool CreateState(CreateStateRequest request)
    {
        try
        {
            State? state = _dbContext.State.FirstOrDefault(s => s.Code == request.Code);
            if(state is not null)
            {
                throw new Exception($"State with code {request.Code} already exists.");
            }
            state = new State { Name = request.Name, Code = request.Code };
            _dbContext.Add(state);
            _dbContext.SaveChanges();
            return true;
        }
        catch(Exception e)
        {
            // _logger.LogError(e, "Error while creating a state with name {stateName} {code}.", request.Name,
            //     request.Code);
            _logger.LogError(e, "Error while creating a state with name {@state}.", request);
            return false;
        }
    }
    public StateDto? UpdateState(int Id, CreateStateRequest request)
    {
        try
        {
            State? state = _dbContext.State.Find(Id);
            if (state is null)
            {
                return null;
            }
            if (state.Code != request.Code || state.Name != request.Name)
            {
                State? stateByName = _dbContext.State.FirstOrDefault(s => s.Name == request.Name);
                State? stateByCode = _dbContext.State.FirstOrDefault(s => s.Code == request.Code);

           
                if (stateByName != null)
                {
                    if (stateByCode != null) 
                    {
                        throw new Exception($"State with name '{request.Name}' or code '{request.Code}' already exists.");
                    } 
                }
            }
            state.Name = request.Name;
            state.Code = request.Code;
            _dbContext.SaveChanges();
            return new StateDto(state.Id, state.Name, state.Code);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error while updating a state with name {stateName} {code}.", request.Name, request.Code);
            return null;
        }
    }

    public StateDto? GetState(int Id)
    {
        State? state = _dbContext.State.Find(Id);
        if(state is null)
        {
            return null;
        }
        return new StateDto(state.Id, state.Name, state.Code);

    }
}