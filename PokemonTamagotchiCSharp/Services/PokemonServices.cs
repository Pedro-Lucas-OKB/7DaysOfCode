using Newtonsoft.Json;
using PokemonTamagotchiCSharp.Models;
using RestSharp;

namespace PokemonTamagotchiCSharp.Services;

public class PokemonServices
{
    public PokemonResponse GetPokemons()
    {
        var client = new RestClient($"https://pokeapi.co/api/v2/pokemon/");
        var request = new RestRequest("", Method.Get);

        var pokemons = client.Get<PokemonResponse>(request);

        return pokemons!;
    }

    public RestResponse GetPokemonById(int id)
    {
        var client = new RestClient($"https://pokeapi.co/api/v2/pokemon/{id}");
        var request = new RestRequest("", Method.Get);

        var pokemon = client.Execute(request);

        return pokemon!;
    }

    public void ShowPokemons(PokemonResponse pokemons)
    {
        Console.WriteLine("Pokémons disponíveis:");
        for (int i = 0; i < pokemons.Results.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {pokemons.Results[i].Name}");
        }
    }

    public int ChoosePokemon(PokemonResponse pokemons)
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

    public PokemonDetails? GetPokemonDetails(RestResponse pokemon)
    {
        PokemonDetails? pokemonDetails = default!;
        try
        {
            pokemonDetails = JsonConvert.DeserializeObject<PokemonDetails>(pokemon.Content!);

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return pokemonDetails;
    }

    public void ShowPokemonDetails(MascotDto? pokemon)
    {
        Console.WriteLine("***** POKEMON *****");
        Console.WriteLine($"Nome: {pokemon.Name}");
        Console.WriteLine($"Altura: {pokemon.Height}");
        Console.WriteLine($"Peso: {pokemon.Weight}");

        Console.WriteLine("Habilidades:");
        foreach (var ability in pokemon.Abilities)
        {
            Console.WriteLine(ability.Name.ToUpper());
        }

        Console.WriteLine($"{pokemon.Name.ToUpper()} {pokemon.HungryStatus()}");
        Console.WriteLine($"{pokemon.Name.ToUpper()} {pokemon.HumorStatus()}");
        Console.WriteLine($"{pokemon.Name.ToUpper()} {pokemon.SleepStatus()}");
    }

    

    public void PokemonInteraction(MascotDto? pokemon)
    {
        int option = -1;

        while (option != 5)
        {
            Console.Clear();
            Console.WriteLine($"------ Opções para {pokemon.Name.ToUpper()} ------");
            Console.WriteLine($"[1] Ver como {pokemon.Name.ToUpper()} está");
            Console.WriteLine($"[2] Alimentar");
            Console.WriteLine($"[3] Brincar");
            Console.WriteLine($"[4] Colocar {pokemon.Name.ToUpper()} para dormir");
            Console.WriteLine($"[5] Voltar");
            while (!int.TryParse(Console.ReadLine(), out option)) { }

            switch (option)
            {
                case 1:
                    ShowPokemonDetails(pokemon);
                    Console.ReadLine();
                    break;

                case 2:
                    pokemon.Feed();
                    Console.WriteLine($"{pokemon.Name} foi alimentado! :)");
                    Console.ReadLine();
                    break;

                case 3:
                    pokemon.PlayWith();
                    Console.WriteLine($"{pokemon.Name} adorou brincar! :)");
                    Console.ReadLine();
                    break;

                case 4:
                    pokemon.BedTime();
                    Console.WriteLine($"{pokemon.Name} tirou uma soneca! :)");
                    Console.ReadLine();
                    break;

                case 5: break;

                default:
                    Console.WriteLine("Aviso: Escolha uma opção válida!");
                    Console.ReadLine();
                    break;
            }
        }
    }
}

