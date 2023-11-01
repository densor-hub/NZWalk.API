using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTOs;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext _context;
        private readonly IRegionRepo _regionRepo;
        public RegionsController(NZWalksDbContext dbContext, IRegionRepo regionRepo)
        {
            _context = dbContext;
            _regionRepo = regionRepo;
        }


        //GET ALL REGIONS
        [HttpGet]
        public async Task<IActionResult> GetAllRegions() {
           var AllRegions = await _regionRepo.GetAllRegionsAsync();

            var RegionDTO = new List<RegionDTO>();

            foreach(var region in AllRegions)
            {
                RegionDTO.Add(new Models.DTOs.RegionDTO
                {
                    Id = region.Id,
                    Name = region.Name,
                    Code = region.Code,
                    RegionImageUrl= region.RegionImageUrl,
                });
            }


            return Ok(RegionDTO);
            
        }


        //GET SPECIFIC REGION BY ID
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id) {
           var specifiedRegion = await _regionRepo.GetByIdAsync(id);

            if (specifiedRegion== null)
            {
                return NotFound();
            }

            var RegionDTO = new RegionDTO();
            RegionDTO.Id = specifiedRegion.Id;
            RegionDTO.Name = specifiedRegion.Name;
            RegionDTO.Code = specifiedRegion.Code;
            RegionDTO.RegionImageUrl = specifiedRegion.RegionImageUrl;
            return Ok(RegionDTO);
        }


        //CREATE NEW REGION --POST
        [HttpPost]
        public async Task<IActionResult> CreateRegion([FromBody]CreateRegionDTO requestBody) {

            var regionModel = new Region
            {
                RegionImageUrl = requestBody.RegionImageUrl,
                Code = requestBody.Code,
                Name = requestBody.Name,
            };

            regionModel = await _regionRepo.CreateRegionAsync(regionModel);

            var regionDTO = new RegionDTO{
                Id = regionModel.Id,
                Name = regionModel.Name,
                Code = regionModel.Code,
                RegionImageUrl = regionModel.RegionImageUrl,
            };

            return CreatedAtAction(nameof(GetById), new {id
            = regionModel.Id}, regionDTO);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateRegion([FromRoute]Guid id, [FromBody]CreateRegionDTO regionRequestDTO)
        {
            var IsExistingRegion = await _regionRepo.UpdateRegionAsync(id, regionRequestDTO);

            if (IsExistingRegion == null)
            {
                return NotFound();
            }

            IsExistingRegion.Name = regionRequestDTO.Name;
            IsExistingRegion.Code = regionRequestDTO.Code;
            IsExistingRegion.RegionImageUrl = regionRequestDTO.RegionImageUrl;

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteRegion([FromRoute] Guid id)
        {
            var isExistingRegion = await _regionRepo.DeleteRegion(id);
            if(isExistingRegion == null) { 
                return NotFound();
            }

            return Ok();
        }
    }
}
