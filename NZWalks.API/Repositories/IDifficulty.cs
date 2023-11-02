using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTOs;

namespace NZWalks.API.Repositories
{
    public interface IDifficulty
    {
        Task<Difficulty> CreateDifficultyAsync(Difficulty   difficulty);
    }
}
