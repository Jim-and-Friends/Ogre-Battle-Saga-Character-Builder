namespace OgreBattleSagaCharacterBuilder.Data.TacticsOgre;
using OgreBattleSagaCharacterBuilder.Domain.TacticsOgre;
using System.Security.Cryptography;
using Weighted_Randomizer;

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

    public BaseStatsRandomizer()
    {
        // Initialize Weighted Randomizers
        hp = new Dictionary<Gender, IWeightedRandomizer<int>> {
            {
                Gender.Female,
                new DynamicWeightedRandomizer<int>() {
                    {57, 20},
                    {58, 60},
                    {59, 20}
                }
            },
            {
                Gender.Male,
                new DynamicWeightedRandomizer<int>() {
                    {59, 15},
                    {60, 60},
                    {61, 20},
                    {62, 5}
                }
            }
        };

        mp = new Dictionary<Gender, IWeightedRandomizer<int>> {
            {
                Gender.Female,
                new DynamicWeightedRandomizer<int>() {
                    {0, 80},
                    {1, 20}
                }
            },
            {
                Gender.Male,
                new DynamicWeightedRandomizer<int>() {
                    {0, 80},
                    {1, 15},
                    {2, 5}
                }
            }
        };

        strength = new Dictionary<Gender, IWeightedRandomizer<int>> {
            {
                Gender.Female,
                new DynamicWeightedRandomizer<int>() {
                    {19, 25},
                    {20, 50},
                    {21, 25}
                }
            },
            {
                Gender.Male,
                new DynamicWeightedRandomizer<int>() {
                    {20, 25},
                    {21, 50},
                    {22, 50}
                }
            }
        };

        vitality = new Dictionary<Gender, IWeightedRandomizer<int>> {
            {
                Gender.Female,
                new DynamicWeightedRandomizer<int>() {
                    {19, 25},
                    {20, 50},
                    {21, 25}
                }
            },
            {
                Gender.Male,
                new DynamicWeightedRandomizer<int>() {
                    {20, 70},
                    {21, 30}
                }
            }
        };

        intelligence = new Dictionary<Gender, IWeightedRandomizer<int>> {
            {
                Gender.Female,
                new DynamicWeightedRandomizer<int>() {
                    {17, 25},
                    {18, 50},
                    {19, 25}
                }
            },
            {
                Gender.Male,
                new DynamicWeightedRandomizer<int>() {
                    {17, 10},
                    {18, 40},
                    {19, 40},
                    {20, 10}
                }
            }
        };

        mentality = new Dictionary<Gender, IWeightedRandomizer<int>> {
            {
                Gender.Female,
                new DynamicWeightedRandomizer<int>() {
                    {16, 25},
                    {17, 50},
                    {18, 25}
                }
            },
            {
                Gender.Male,
                new DynamicWeightedRandomizer<int>() {
                    {17, 10},
                    {18, 40},
                    {19, 40},
                    {20, 10}
                }
            }
        };

        agility = new Dictionary<Gender, IWeightedRandomizer<int>> {
            {
                Gender.Female,
                new DynamicWeightedRandomizer<int>() {
                    {19, 25},
                    {20, 50},
                    {21, 25}
                }
            },
            {
                Gender.Male,
                new DynamicWeightedRandomizer<int>() {
                    {19, 25},
                    {20, 50},
                    {21, 25}
                }
            }
        };

        dexterity = new Dictionary<Gender, IWeightedRandomizer<int>> {
            {
                Gender.Female,
                new DynamicWeightedRandomizer<int>() {
                    {21, 25},
                    {22, 50},
                    {23, 25}
                }
            },
            {
                Gender.Male,
                new DynamicWeightedRandomizer<int>() {
                    {19, 15},
                    {20, 40},
                    {21, 40},
                    {22, 5}
                }
            }
        };

        luck = new Dictionary<Gender, IWeightedRandomizer<int>> {
            {
                Gender.Female,
                new DynamicWeightedRandomizer<int>() {
                    {49, 15},
                    {50, 70},
                    {51, 15}
                }
            },
            {
                Gender.Male,
                new DynamicWeightedRandomizer<int>() {
                    {49, 15},
                    {50, 70},
                    {51, 15}
                }
            }
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
    private BaseStatsRandomizer baseStatsRandomizer = new BaseStatsRandomizer();
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

    public Statistics GenerateBaseStats(Gender gender)
    {
        return baseStatsRandomizer.Generate(gender);
    }
}