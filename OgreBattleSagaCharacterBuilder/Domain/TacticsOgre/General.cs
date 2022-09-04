namespace OgreBattleSagaCharacterBuilder.Domain.TacticsOgre;

public enum Alignment
{
    Lawful,
    Neutral,
    Chaotic
}

public record struct Attributes
{
    public int HP { get; init; }

    public int MP { get; init; }

    public int Strength { get; init; }

    public int Vitality { get; init; }
    
    public int Intelligence { get; init; }

    public int Mentality { get; init; }    

    public int Agility { get; init; }

    public int Dexterity { get; init; }
}

public enum Element
{
    Fire,
    Water,
    Wind,
    Earth,
    Light,
    Dark
}

public enum Gender
{
    Female,
    Male
}