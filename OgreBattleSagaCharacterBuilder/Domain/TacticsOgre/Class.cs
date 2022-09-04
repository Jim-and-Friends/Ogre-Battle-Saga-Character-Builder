namespace OgreBattleSagaCharacterBuilder.Domain.TacticsOgre;

public record struct Requirements
{
    public Gender Gender { get; init; }
    public List<Alignment> Alignment { get; init; }
    public Statistics Statistics { get; init; }
}

public record struct Class
{
    public string Name { get; init; }

    public Requirements Requirements { get; init; }

    public Statistics StatsGrowth { get; init; }
}