namespace PokemonTamagotchiCSharp.Models;

public class User
{
    public string? Name { get; set; } = default!;
    public List<PokemonDetails> Pokemons { get; set; } = default!;
}
