using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class DifficultyImplementor : IDifficulty
    {
        private readonly NZWalksDbContext _dBcontext;
        public DifficultyImplementor(NZWalksDbContext dbContext)
        {
            _dBcontext = dbContext;
        }
       async Task<Difficulty>  IDifficulty.CreateDifficultyAsync(Difficulty difficulty)
        {
            var NewDifficulty= new Difficulty()
            {
                Id = difficulty.Id,
                Name  = difficulty.Name,
            };

            await _dBcontext.Difficulties.AddAsync(NewDifficulty);
            await _dBcontext.SaveChangesAsync();
            return NewDifficulty;
            
        }
    }
}
