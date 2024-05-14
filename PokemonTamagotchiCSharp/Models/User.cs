namespace PokemonTamagotchiCSharp.Models;

public class User
{
    public string? Name { get; set; } = default!;
    public List<MascotDto> Pokemons { get; set; } = default!;
}
