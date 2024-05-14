using AutoMapper;
using PokemonTamagotchiCSharp.Models;

namespace PokemonTamagotchiCSharp.Services;

public class AutoMapperService : Profile
{
    public AutoMapperService()
    {
        CreateMap<PokemonDetails, MascotDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Height, opt => opt.MapFrom(src => src.Height))
            .ForMember(dest => dest.Weight, opt => opt.MapFrom(src => src.Weight))
            .ForMember(dest => dest.Abilities, opt => opt.MapFrom(src => src.Abilities.Select(a => new Ability {Name = a.Ability.Name})));
    }
}

public class MascotService
{
    private readonly IMapper _mapper;

    public MascotService(IMapper mapper)
    {
        _mapper = mapper;
    }

    public MascotDto CreateMascot(PokemonDetails pokemon) 
    {
        return _mapper.Map<MascotDto>(pokemon);
    }
}
