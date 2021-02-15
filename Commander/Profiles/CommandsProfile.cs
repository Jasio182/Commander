using AutoMapper;
using Commander.Dtos;
using Commander.Models;

namespace Commander.Profiles
{
    // Profile object for every DTO
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            // It maps between source and destination object
            CreateMap<Command, CommandReadDto>();
        }
    }
}
