namespace PokemonTamagotchiCSharp.Models;

public class PokemonResponse
{
    public int count { get; set; }
    public string Next { get; set; } = default!;
    public string Previous { get; set; } = default!;
    public List<Pokemon> Results { get; set; } = default!;
}