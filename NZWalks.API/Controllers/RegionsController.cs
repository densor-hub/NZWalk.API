using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTOs;
using NZWalks.API.Repositories;
using System.Collections.Generic;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext _context;
        private readonly IRegionRepo _regionRepo;
        private readonly IMapper _mapper;
        public RegionsController(NZWalksDbContext dbContext, IRegionRepo regionRepo, IMapper mapper
            )
        {
            _context = dbContext;
            _regionRepo = regionRepo;
            _mapper = mapper;
        }


        //GET ALL REGIONS
        [HttpGet]
        public async Task<IActionResult> GetAllRegions() {
           var AllRegions = await _regionRepo.GetAllRegionsAsync();

            var RegionDTO = new List<RegionResponseDTO>();

            var mapDomainToDTO = _mapper.Map<List<RegionResponseDTO>>(AllRegions);

            //foreach (var region in AllRegions)
            //{
            //    RegionDTO.Add(new Models.DTOs.RegionResponseDTO
            //    {
            //       // Id = region.Id,
            //        Name = region.Name,
            //        Code = region.Code,
            //        RegionImageUrl= region.RegionImageUrl,
            //    });
            //}


            return Ok(mapDomainToDTO);
            
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
        public async Task<IActionResult> CreateRegion([FromBody]RegionResponseDTO requestBody) {

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
        public async Task<IActionResult> UpdateRegion([FromRoute]Guid id, [FromBody]RegionResponseDTO regionRequestDTO)
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
            var isExistingRegion = await _regionRepo.DeleteRegionAsync(id);
            if(isExistingRegion == null) { 
                return NotFound();
            }

            return Ok();
        }
    }
}
