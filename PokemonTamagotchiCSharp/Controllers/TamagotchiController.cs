using PokemonTamagotchiCSharp.Models;
using PokemonTamagotchiCSharp.Services;

namespace PokemonTamagotchiCSharp.Controllers;

public class TamagotchiController
{
    public static User AppUser { get; set; } = default!;

    public TamagotchiController()
    {
        AppUser = new User();
    }

    public void Jogar() {
        Welcome();
        Menu();
    }

    public void Welcome()
    {
        Console.WriteLine("Boas vindas!");
        Console.Write("Para começar, digite seu nome: ");
        AppUser.Name = Console.ReadLine();
    }

    public void Menu()
    {
        int option;

        while (true)
        {
            Console.Clear();
            ShowMenu();

            while (!int.TryParse(Console.ReadLine(), out option)) { }

            switch (option)
            {
                case 1:
                    PokemonAdoption();
                    break;

                case 2:
                    ShowAdoptedPokemons();
                    break;

                case 0:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Aviso: Escolha uma opção válida!");
                    Console.ReadLine();
                    break;
            }
        }
    }

    public void ShowMenu()
    {
        Console.WriteLine("****** MENU ******");
        Console.WriteLine("[1] Adotar um Mascote");
        Console.WriteLine("[2] Ver mascotes adotados");
        Console.WriteLine("[0] Sair");
        Console.WriteLine();
        Console.WriteLine($"Olá novamente, {AppUser.Name}! Escolha uma opção do menu!");
    }

    public void PokemonAdoption()
    {
        var services = new PokemonServices();
        var pokemonsList = services.GetPokemons();

        services.ShowPokemons(pokemonsList);
        var pokemonResponse = services.GetPokemonById(services.ChoosePokemon(pokemonsList));

        var pokemon = services.GetPokemonDetails(pokemonResponse);

        int option = -1;
        while (option != 2)
        {
            Console.Clear();
            Console.WriteLine($"{AppUser.Name}, você deseja:");
            Console.WriteLine($"[1] Ver detalhes de {pokemon.Name}");
            Console.WriteLine($"[2] Adotar {pokemon.Name}");
            Console.WriteLine($"[3] Cancelar adoção");
            while (!int.TryParse(Console.ReadLine(), out option)){}
            
            switch (option)
            {
                case 1:
                    services.ShowPokemonDetails(pokemon);
                    Console.ReadLine();
                    break;

                case 2:
                    if (AppUser.Pokemons == null) AppUser.Pokemons = [];
                    AppUser.Pokemons.Add(pokemon);
                    break;

                case 3:
                    return;

                default:
                    Console.WriteLine("Aviso: Escolha uma opção válida!");
                    Console.ReadLine();
                    break;
            }
        }
    }

    public void ShowAdoptedPokemons()
    {
        if (AppUser.Pokemons != null)
        {
            var services = new PokemonServices();
            foreach (var pokemon in AppUser.Pokemons)
            {
                services.ShowPokemonDetails(pokemon);
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("Aviso: Ainda não há pokemons adotados!");
        }

        Console.ReadLine();
    }
}
