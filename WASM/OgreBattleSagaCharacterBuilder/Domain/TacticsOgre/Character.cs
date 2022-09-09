namespace OgreBattleSagaCharacterBuilder.Domain.TacticsOgre;

public record struct Character
{
    public string Name { get; init; }

    public Gender Gender { get; init; }

    public Alignment Alignment { get; init; }

    public Element Element { get; init; }

    public List<Class> ClassLevelHistory { get; init; }

    public int Level { get { return ClassLevelHistory.Count + 1; } }

    public Statistics BaseStatistics { get; init; }

    public Statistics Statistics { get 
        {
            return new Statistics { 
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