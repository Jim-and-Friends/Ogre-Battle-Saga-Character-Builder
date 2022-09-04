namespace OgreBattleSagaCharacterBuilder.Data.TacticsOgre;
using OgreBattleSagaCharacterBuilder.Domain.TacticsOgre;
using System.Security.Cryptography;

public class TacticsOgreDataService
{
    private List<Class>? _classes { get; set; }
    public List<Class> Classes
    {
        get
        {
            if (_classes == null)
            {
                string jsonString = File.ReadAllText("Data/TacticsOgre/Classes.json");
                _classes = System.Text.Json.JsonSerializer.Deserialize<List<Class>>(jsonString);
            }
            return _classes;
        }
    }

    public TacticsOgreDataService()
    {
    }

    public static Statistics GenerateBaseStats(Gender gender)
    {
        if (gender == Gender.Female)
        {
            return new Statistics
            {
                HP = RandomNumberGenerator.GetInt32(57, 59),
                MP = RandomNumberGenerator.GetInt32(0, 1),
                Strength = RandomNumberGenerator.GetInt32(19, 21),
                Vitality = RandomNumberGenerator.GetInt32(19, 21),
                Intelligence = RandomNumberGenerator.GetInt32(17, 19),
                Mentality = RandomNumberGenerator.GetInt32(16, 18),
                Agility = RandomNumberGenerator.GetInt32(19, 21),
                Dexterity = RandomNumberGenerator.GetInt32(21, 23),
                Luck = RandomNumberGenerator.GetInt32(49, 51)
            };
        }
        else
        {
            return new Statistics
            {
                HP = RandomNumberGenerator.GetInt32(59, 61),
                MP = RandomNumberGenerator.GetInt32(0, 2),
                Strength = RandomNumberGenerator.GetInt32(20, 22),
                Vitality = RandomNumberGenerator.GetInt32(20, 21),
                Intelligence = RandomNumberGenerator.GetInt32(17, 20),
                Mentality = RandomNumberGenerator.GetInt32(17, 20),
                Agility = RandomNumberGenerator.GetInt32(19, 21),
                Dexterity = RandomNumberGenerator.GetInt32(19, 22),
                Luck = RandomNumberGenerator.GetInt32(49, 51)
            };
        }
    }
}