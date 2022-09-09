namespace OgreBattleSagaCharacterBuilder.Data.TacticsOgre;
using OgreBattleSagaCharacterBuilder.Domain.TacticsOgre;
using System.Text.Json;
using System.Net.Http.Json;
using Weighted_Randomizer;

public struct ValueWithWeight 
{
    public int Value { get; set; }
    public int Weight { get; set; }
}

public struct BaseStatProbabilityWeights
{
    public Gender Gender { get; set; }
    public List<ValueWithWeight> HP { get; set; }
    public List<ValueWithWeight> MP { get; set; }
    public List<ValueWithWeight> Strength { get; set; }
    public List<ValueWithWeight> Vitality { get; set; }
    public List<ValueWithWeight> Intelligence { get; set; }
    public List<ValueWithWeight> Mentality { get; set; }
    public List<ValueWithWeight> Agility { get; set; }
    public List<ValueWithWeight> Dexterity { get; set; }
    public List<ValueWithWeight> Luck { get; set; }
}

public class BaseStatsRandomizer
{
    private Dictionary<Gender, IWeightedRandomizer<int>> hp { get; set; }
    private Dictionary<Gender, IWeightedRandomizer<int>> mp { get; set; }
    private Dictionary<Gender, IWeightedRandomizer<int>> strength { get; set; }
    private Dictionary<Gender, IWeightedRandomizer<int>> vitality { get; set; }
    private Dictionary<Gender, IWeightedRandomizer<int>> intelligence { get; set; }
    private Dictionary<Gender, IWeightedRandomizer<int>> mentality { get; set; }
    private Dictionary<Gender, IWeightedRandomizer<int>> agility { get; set; }
    private Dictionary<Gender, IWeightedRandomizer<int>> dexterity { get; set; }
    private Dictionary<Gender, IWeightedRandomizer<int>> luck { get; set; }
    
    private DynamicWeightedRandomizer<int> extractValuesAndWeights (List<ValueWithWeight> valuesAndWeights)
    {
        var randToReturn = new DynamicWeightedRandomizer<int>();
        valuesAndWeights.ForEach(x => {
            randToReturn.Add(x.Value, x.Weight);
        });
        return randToReturn;
    }

    public BaseStatsRandomizer(List<BaseStatProbabilityWeights> statsAndWeights)
    {
        var femaleWeights = statsAndWeights.Single(x => x.Gender == Gender.Female);
        var maleWeights = statsAndWeights.Single(x => x.Gender == Gender.Male);
        
        hp = new Dictionary<Gender, IWeightedRandomizer<int>>{
            { Gender.Female, extractValuesAndWeights(femaleWeights.HP) },
            { Gender.Male, extractValuesAndWeights(maleWeights.HP) }
        };
        mp = new Dictionary<Gender, IWeightedRandomizer<int>>{
            { Gender.Female, extractValuesAndWeights(femaleWeights.MP) },
            { Gender.Male, extractValuesAndWeights(maleWeights.MP) }
        };
        strength = new Dictionary<Gender, IWeightedRandomizer<int>>{
            { Gender.Female, extractValuesAndWeights(femaleWeights.Strength) },
            { Gender.Male, extractValuesAndWeights(maleWeights.Strength) }
        };
        vitality = new Dictionary<Gender, IWeightedRandomizer<int>>{
            { Gender.Female, extractValuesAndWeights(femaleWeights.Vitality) },
            { Gender.Male, extractValuesAndWeights(maleWeights.Vitality) }
        };
        intelligence = new Dictionary<Gender, IWeightedRandomizer<int>>{
            { Gender.Female, extractValuesAndWeights(femaleWeights.Intelligence) },
            { Gender.Male, extractValuesAndWeights(maleWeights.Intelligence) }
        };
        mentality = new Dictionary<Gender, IWeightedRandomizer<int>>{
            { Gender.Female, extractValuesAndWeights(femaleWeights.Mentality) },
            { Gender.Male, extractValuesAndWeights(maleWeights.Mentality) }
        };
        agility = new Dictionary<Gender, IWeightedRandomizer<int>>{
            { Gender.Female, extractValuesAndWeights(femaleWeights.Agility) },
            { Gender.Male, extractValuesAndWeights(maleWeights.Agility) }
        };
        dexterity = new Dictionary<Gender, IWeightedRandomizer<int>>{
            { Gender.Female, extractValuesAndWeights(femaleWeights.Dexterity) },
            { Gender.Male, extractValuesAndWeights(maleWeights.Dexterity) }
        };
        luck = new Dictionary<Gender, IWeightedRandomizer<int>>{
            { Gender.Female, extractValuesAndWeights(femaleWeights.Luck) },
            { Gender.Male, extractValuesAndWeights(maleWeights.Luck) }
        };
    }

    public Statistics Generate(Gender gender)
    {
        return new Statistics() {
            HP = hp[gender].NextWithReplacement(),
            MP = mp[gender].NextWithReplacement(),
            Strength = strength[gender].NextWithReplacement(),
            Vitality = vitality[gender].NextWithReplacement(),
            Intelligence = intelligence[gender].NextWithReplacement(),
            Mentality = mentality[gender].NextWithReplacement(),
            Agility = agility[gender].NextWithReplacement(),
            Dexterity = dexterity[gender].NextWithReplacement(),
            Luck = luck[gender].NextWithReplacement()
        };
    }
}

public class TacticsOgreDataService
{
    public BaseStatsRandomizer baseStatsRandomizer { get; set; }
    
    private async void ReadBaseStatProbabilityWeights()
    {
        var client = new HttpClient();
        client.BaseAddress = new Uri("http://localhost:5177");
        _baseStatProbabilityWeights = await client.GetFromJsonAsync<List<BaseStatProbabilityWeights>>("Data/TacticsOgre/BaseStatProbabilityWeights.json");
    }
    private List<BaseStatProbabilityWeights>? _baseStatProbabilityWeights;
    public List<BaseStatProbabilityWeights> BaseStatProbabilityWeights
    {
        get
        {
            if (_baseStatProbabilityWeights == null)
            {                
                ReadBaseStatProbabilityWeights();
            }
            return _baseStatProbabilityWeights;
        }
    }

    private async void ReadClasses()
    {
        var client = new HttpClient();
        client.BaseAddress = new Uri("http://localhost:5177");
        _classes = await client.GetFromJsonAsync<List<Class>>("Data/TacticsOgre/Classes.json");
    }
    private List<Class>? _classes { get; set; }
    public List<Class> Classes
    {
        get
        {
            if (_classes == null)
            {
                ReadClasses();
            }
            return _classes;
        }
    }

    public Statistics GenerateBaseStats(Gender gender)
    {
        baseStatsRandomizer = new BaseStatsRandomizer(BaseStatProbabilityWeights);
        return baseStatsRandomizer.Generate(gender);
    }

    public TacticsOgreDataService()
    {
        ReadBaseStatProbabilityWeights();
        ReadClasses();
    }
}