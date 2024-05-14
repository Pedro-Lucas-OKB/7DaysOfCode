namespace PokemonTamagotchiCSharp.Models;

public class PokemonDetails
{
    public List<PokemonAbilities> Abilities { get; set; } = default!;
    public string? Name { get; set; } = default!;
    public int Order { get; set; } = default!;
    public int Height { get; set; } = default!;
    public int Weight { get; set; } = default!;
}

public class PokemonAbilities
{
    public Ability Ability { get; set; } = default!;
    public bool IsHidden { get; set; } = default!;
    public int Slot { get; set; } = default!;
}

public class Ability
{
    public string Name { get; set; } = default!;
    public string Url { get; set; } = default!;
}