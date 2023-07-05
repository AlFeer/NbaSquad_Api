using AutoMapper;
using NbaSquad.Dto;
using NbaSquad.Models;

namespace NbaSquad.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Player, PlayerDto>();
            CreateMap<PlayerDto, Player>();
            CreateMap<Player, PlayerResponse>();
            CreateMap<PlayerResponse, Player>();
            CreateMap<Team, TeamDto>();
            CreateMap<TeamDto, Team>();
            CreateMap<Team, TeamResponse>();
            CreateMap<TeamResponse, Team>();
        }
    }
}