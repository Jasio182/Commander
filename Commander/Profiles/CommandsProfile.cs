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
            // From Command, creates CommandReadDto
            CreateMap<Command, CommandReadDto>();
            // From CommandCreateDto, creates Command
            CreateMap<CommandCreateDto, Command>();
            CreateMap<CommandUpdateDto, Command>();
            CreateMap<Command, CommandUpdateDto>();
        }
    }
}
