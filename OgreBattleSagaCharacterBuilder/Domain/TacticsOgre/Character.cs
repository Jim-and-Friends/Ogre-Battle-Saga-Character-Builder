namespace OgreBattleSagaCharacterBuilder.Domain.TacticsOgre;

public record struct Character
{
    public string Name { get; init; }

    public Gender Gender { get; init; }

    public Alignment Alignment { get; init; }

    public Element Element { get; init; }

    public List<Class> ClassLevelHistory { get; init; }

    public int Level { get { return ClassLevelHistory.Count; } }

    public Attributes Attributes { get 
        {
            return new Attributes { 
                Agility = 0,
                Dexterity = 0,
                Intelligence = 0,
                Mentality = 0,
                Strength = 0,
                Vitality = 0
            };
        //   ClassLevelHistory.Aggregate(
        //     () => new Attributes(
        //         Strength = 1;

        //     )
        //   )
        }
    }
}