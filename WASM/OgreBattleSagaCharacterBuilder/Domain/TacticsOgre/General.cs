namespace OgreBattleSagaCharacterBuilder.Domain.TacticsOgre;
using System.Text.Json.Serialization;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Alignment
{
    Lawful,
    Neutral,
    Chaotic
}

public record struct Statistics
{
    public int HP { get; init; }

    public int MP { get; init; }

    public int Strength { get; init; }

    public int Vitality { get; init; }
    
    public int Intelligence { get; init; }

    public int Mentality { get; init; }    

    public int Agility { get; init; }

    public int Dexterity { get; init; }

    public int Luck { get; init; }
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Element
{
    Earth,
    Fire,
    Water,
    Wind,    
    Light,
    Dark
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Gender
{
    Female,
    Male
}