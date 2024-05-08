using Newtonsoft.Json;
using PokemonTamagotchiCSharp;
using RestSharp;

var pokemons = GetPokemons();

ShowPokemons(pokemons);

var pokemon = GetPokemonById(ChoosePokemon(pokemons));

ShowPokemonDetails(pokemon);

static PokemonResponse GetPokemons()
{
    var client = new RestClient($"https://pokeapi.co/api/v2/pokemon/");
    var request = new RestRequest("", Method.Get);

    var pokemons = client.Get<PokemonResponse>(request);

    return pokemons!;
}

static RestResponse GetPokemonById(int id)
{
    var client = new RestClient($"https://pokeapi.co/api/v2/pokemon/{id}");
    var request = new RestRequest("", Method.Get);

    var pokemon = client.Execute(request);

    return pokemon!;
}

static void ShowPokemons(PokemonResponse pokemons)
{
    Console.WriteLine("Pokémons disponíveis:");
    for (int i = 0; i < pokemons.Results.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {pokemons.Results[i].Name}");
    }
}

static int ChoosePokemon(PokemonResponse pokemons)
{
    int escolha = -1;
    while (true)
    {
        Console.WriteLine();
        Console.Write("Escolha um pokémon(digite o número): ");

        if (int.TryParse(Console.ReadLine(), out escolha))
        {
            if (escolha > 0 && escolha <= pokemons.Results.Count)
            {
                break;
            }
            else
            {
                Console.WriteLine($"Aviso: O valor deve ser entre 1 e {pokemons.Results.Count}.");
            }
        }
        else
        {
            Console.WriteLine("Aviso: Digite um valor númerico válido!");
        }
    }

    return escolha;
}

static void ShowPokemonDetails(RestResponse pokemon)
{
    PokemonDetails? mascote = default!;
    try
    {
        mascote = JsonConvert.DeserializeObject<PokemonDetails>(pokemon.Content!);

    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        return;
    }

    Console.WriteLine("***** POKEMON *****");
    Console.WriteLine($"Nome: {mascote!.Name}");
    Console.WriteLine($"Altura: {mascote.Height}");
    Console.WriteLine($"Peso: {mascote.Weight}");

    Console.WriteLine("Habilidades:");
    foreach (var ability in mascote.Abilities)
    {
        Console.WriteLine(ability.Ability.Name.ToUpper());
    }
}