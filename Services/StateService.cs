using Microsoft.EntityFrameworkCore;
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
                Code = s.Code,
                IsActive = s.IsActive
            }).ToList();
        return states;
    }

    public IEnumerable<StateViewModel> CreateStates(StateViewModel model)
    {
        State state = new() { Name = model.Name, Code = model.Code, IsActive = model.IsActive };
        _dbContext.Add(state);
        _dbContext.SaveChanges();
        return GetStates();
    }


    public IEnumerable<StateDto> GetAllStates()
    {
        IList<StateDto> states = _dbContext.State
            .Select(s => new StateDto(s.Id, s.Name, s.Code, s.IsActive))
            .ToList();
        return states;
    }

    public StateDto? CreateState(CreateStateRequest request)
    {
        try
        {
            var state = _dbContext.State.FirstOrDefault(s => s.Code == request.Code);
            if (state is not null) return null;
            state = new State { Name = request.Name, Code = request.Code, IsActive = request.IsActive };
            _dbContext.Add(state);
            _dbContext.SaveChanges();
            return new StateDto(state.Id, state.Name, state.Code, state.IsActive);
        }
        catch (ConflictException ex)
        {
            _logger.LogError(ex, "Error while creating a state with name {stateName}. Some conflicts occured.",
                request.Name);
        }
        catch (DbUpdateException ex)
        {
            _logger.LogError(ex,
                "Error while creating a state with name {stateName}. Problem in execution of sql query.",
                request.Name);
        }

        catch (Exception e)
        {
            // _logger.LogError(e, "Error while creating a state with name {stateName} {code}.", request.Name,
            //     request.Code);
            _logger.LogError(e, "Error while creating a state with name {@state}.", request);
        }

        return null;
    }

    public StateDto? UpdateState(int Id, CreateStateRequest request)
    {
        try
        {
            var state = _dbContext.State.Find(Id);
            if (state is null) return null;
            if (state.Code != request.Code || state.Name != request.Name)
            {
                var stateByName = _dbContext.State.FirstOrDefault(s => s.Name == request.Name);
                var stateByCode = _dbContext.State.FirstOrDefault(s => s.Code == request.Code);


                if (stateByName != null)
                    if (stateByCode != null)
                        return null;
            }

            state.Name = request.Name;
            state.Code = request.Code;
            state.IsActive = request.IsActive;
            _dbContext.SaveChanges();
            return new StateDto(state.Id, state.Name, state.Code, state.IsActive);
        }
        catch (ConflictException ex)
        {
            _logger.LogError(ex, "Error while updating a state with name {Name}{code}. Some conflicts occured.",
                request.Name, request.Code);
        }
        catch (DbUpdateException ex)
        {
            _logger.LogError(ex,
                "Error while updating a state with name {Name}{code}. Problem in execution of sql query.",
                request.Name, request.Code);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error while updating a state with name {Name} {code}.", request.Name, request.Code);
        }

        return null;
    }

    public StateDto? GetState(int Id)
    {
        var state = _dbContext.State.Find(Id);
        if (state is null) return null;
        return new StateDto(state.Id, state.Name, state.Code, state.IsActive);
    }

    public StateDto? DeleteState(int Id)
    {
        try
        {
            var state = _dbContext.State.Find(Id);
            if (state is null) return null;
            _dbContext.Remove(state);
            _dbContext.SaveChanges();
            return new StateDto(state.Id, state.Name, state.Code, state.IsActive);
        }
        catch (DbUpdateException ex)
        {
            _logger.LogError(ex,
                "Error while Deleting a state. Problem in execution of sql query.");
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error while deleting a state");
        }

        return null;
    }

    public StateDto? UpdateActive(int Id, ActiveReaquest request)
    {
        try
        {
            var state = _dbContext.State.Find(Id);
            if (state is null) return null;

            state.IsActive = request.IsActive;
            _dbContext.SaveChanges();
            return new StateDto(state.Id, state.Name, state.Code, state.IsActive);
        }
        catch (DbUpdateException ex)
        {
            _logger.LogError(ex,
                "Error while Changing Active of state. Problem in execution of sql query.");
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error while Changing Active of  state");
        }

        return null;
    }
}