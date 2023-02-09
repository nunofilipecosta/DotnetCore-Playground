using AutoMapper;
using CostaSoftware.MinimalApi.Sample.Dtos;
using CostaSoftware.MinimalApi.Sample.Models;

namespace CostaSoftware.MinimalApi.Sample.Mappings;

public class CommandsProfile : Profile
{
    public CommandsProfile()
    {
        // Source -> Target
        CreateMap<Command, CommandReadDto>();
        CreateMap<CommandCreateDto, Command>();
        CreateMap<CommandUpdateDto, Command>();
    }
}
