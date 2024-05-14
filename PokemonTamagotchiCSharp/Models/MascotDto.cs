namespace PokemonTamagotchiCSharp;

public class MascotDto
{
    public List<Ability> Abilities { get; set; } = default!;
    public string? Name { get; set; } = default!;
    public int Height { get; set; } = default!;
    public int Weight { get; set; } = default!;

    public int Hungry { get; set; } = new Random().Next(1, 11);
    public int Humor { get; set; } = new Random().Next(1, 11);
    public int Sleep { get; set; } = new Random().Next(1, 11);

    public string HungryStatus()
    {
        if (Hungry > 6) return "Está alimentado!";
        else if (Hungry > 3) return "Está levemente com fome!";
        else return "Está com MUITA fome!";
    }

    public string HumorStatus()
    {
        if (Humor > 6) return "Está feliz!";
        else if (Humor > 3) return "Está um pouco triste!";
        else return "Está MUITO triste! :(";
    }

    public string SleepStatus()
    {
        if (Sleep > 6) return "Está bem descansado!";
        else if (Sleep > 3) return "Está levemente com sono!";
        else return "Está com MUITO sono! Precisa dormir!";
    }

    public void Feed()
    {
        if (Hungry < 10) Hungry += 1;

        if (Humor < 10) Humor += 1;

        if (Sleep > 0) Sleep -= 1;
    }

    public void PlayWith()
    {
        if (Hungry > 0) Hungry -= 1;

        if (Humor < 10) Humor += 1;

        if (Sleep > 0) Sleep -= 1;
    }
    
    public void BedTime()
    {
        if (Hungry > 0) Hungry -= 1;

        if (Humor < 10) Humor += 1;

        if (Sleep < 10) Sleep += 1;
    }
}


public class Ability
{
    public string Name { get; set; }
}