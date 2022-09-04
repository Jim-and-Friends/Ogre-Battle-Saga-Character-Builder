namespace OgreBattleSagaCharacterBuilder.Data.TacticsOgre;
using OgreBattleSagaCharacterBuilder.Domain.TacticsOgre;

public class TacticsOgreDataService
{
    private List<Class> _classes { get; set; }
    public List<Class> Classes { 
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
}