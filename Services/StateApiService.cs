using Microsoft.AspNetCore.Http.HttpResults;
using WebTestMVC.Data;
using WebTestMVC.Dtos;

namespace WebTestMVC.Services
{
    public class StateApiService
    {
        private readonly AppDbContext _dbContext;
        public StateApiService(AppDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public IEnumerable<StateDto> GetAllStates() 
        {
            IReadOnlyList<StateDto> states = _dbContext.State
                                            .Select(s => new StateDto(s.Id, s.Name, s.Code))
                                            .ToList();
            return states;
        }
        public StateDto getStateById(int Id)
        {
            State? state = _dbContext.State.Find(Id);
            if(state == null)
            {
                throw new KeyNotFoundException("State Not Found");
            }
            return new StateDto(state.Id, state.Name, state.Code);
                                                
        }
    }
}
