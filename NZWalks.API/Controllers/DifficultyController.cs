using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTOs;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DifficultyController : ControllerBase
    {
        private readonly IDifficulty _difficulty;
        private readonly IMapper _mapper;
        public DifficultyController(IDifficulty difficulty, IMapper mapper)
        {
            _difficulty = difficulty;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDifficulty(CreateDifficultyDTO difficultyRequestDTO)
        {
            // map dto to Domain 
            var mapDTO_to_Domain = _mapper.Map<Difficulty>(difficultyRequestDTO);
            await _difficulty.CreateDifficultyAsync(mapDTO_to_Domain);

            return Ok();
            //operate on data in the impplementor 

        }
    }
}
