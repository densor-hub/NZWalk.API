using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTOs;

namespace NZWalks.API.Repositories
{
    public class RegionRepoImplementor : IRegionRepo
    {
        private readonly NZWalksDbContext _dbContext;

        public RegionRepoImplementor(NZWalksDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async  Task<List<Region>> GetAllRegionsAsync()
        {
          var regions = await  _dbContext.Regions.ToListAsync();
           return regions;
        }

        public async Task<Region?> GetByIdAsync(Guid id)
        {
            var region= await _dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);  
            return region;
        }

        public async Task<Region> CreateRegionAsync(Region region)
        {
          await  _dbContext.Regions.AddAsync(region);
          await  _dbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region?> UpdateRegionAsync(Guid id, RegionResponseDTO
            region)
        {
            var isExistingRegion = await _dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (isExistingRegion == null)
            {
                return null;
            }

            isExistingRegion.RegionImageUrl = region.RegionImageUrl;
            isExistingRegion.Name = region.Name;
            isExistingRegion.Code = region.Code;

            return isExistingRegion;
        }

        public async Task<Region?> DeleteRegionAsync(Guid id)
        {
            var isExistingRegion = _dbContext.Regions.FirstOrDefault(x => x.Id == id);

            if(isExistingRegion == null)
            {
                return null;
            }

            _dbContext.Remove(isExistingRegion);
            await _dbContext.SaveChangesAsync();

            return isExistingRegion; ;
        }
    }
}
