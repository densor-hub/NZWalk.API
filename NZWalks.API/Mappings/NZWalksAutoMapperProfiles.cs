using AutoMapper;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTOs;

namespace NZWalks.API.Mappings
{
    public class NZWalksAutoMapperProfiles : Profile
    {
        public NZWalksAutoMapperProfiles()
        {
            CreateMap<Region, RegionResponseDTO>().ReverseMap();
            CreateMap<Difficulty, CreateDifficultyDTO>().ReverseMap();
        }
    }
}
