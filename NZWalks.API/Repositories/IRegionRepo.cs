using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTOs;

namespace NZWalks.API.Repositories
{
    public interface IRegionRepo
    {
        Task<List<Region>> GetAllRegionsAsync();

        Task<Region?> GetByIdAsync(Guid id);

        Task<Region > CreateRegionAsync(Region region);

       
       Task<Region?> UpdateRegionAsync(Guid id, CreateRegionDTO
region);

       Task<Region?
           > DeleteRegionAsync(Guid id);
    }
}
