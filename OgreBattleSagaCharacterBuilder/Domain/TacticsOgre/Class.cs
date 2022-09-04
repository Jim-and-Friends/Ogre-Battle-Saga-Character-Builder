namespace OgreBattleSagaCharacterBuilder.Domain.TacticsOgre;

public record struct Requirements
{
    public Gender Gender { get; init; }
    public List<Alignment> Alignment { get; init; }
    public Attributes Attributes { get; init; }
}

public record struct Class
{
    public string Name { get; init; }

    public Requirements Requirements { get; init; }

    public Attributes AttributeGrowth { get; init; }
}