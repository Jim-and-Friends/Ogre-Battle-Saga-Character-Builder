namespace UnitTests;
using OgreBattleSagaCharacterBuilder.Data.TacticsOgre;
using OgreBattleSagaCharacterBuilder.Domain.TacticsOgre;

public class UnitTest1
{
    [Fact]
    public void LoadJsonDataTest()
    {
        // Arrange
        var tacticsOgreDataService = new TacticsOgreDataService();

        // Act
        var classes = tacticsOgreDataService.Classes;

        // Assert
        Assert.Equal(12, classes.Count);
    }

    [Fact]
    public void RandomizeBaseStatsTest()
    {
        // Arrange
        var tacticsOgreDataService = new TacticsOgreDataService();        
        var baseStatsGenerationsFemale = new List<Statistics>();
        var baseStatsGenerationsMale = new List<Statistics>();
        var numOfGenerations = 10000M;

        // Act
        for(var x = 0; x < numOfGenerations; x++)
        {
            baseStatsGenerationsFemale.Add(tacticsOgreDataService.GenerateBaseStats(Gender.Female));
            baseStatsGenerationsMale.Add(tacticsOgreDataService.GenerateBaseStats(Gender.Male));
        }
                
        // Assert        
        Assert.InRange<decimal>(baseStatsGenerationsFemale.Count(x => x.HP == 57) / numOfGenerations, .175M, .225M);
        Assert.InRange<decimal>(baseStatsGenerationsFemale.Count(x => x.HP == 58) / numOfGenerations, .55M, .65M);
        Assert.InRange<decimal>(baseStatsGenerationsFemale.Count(x => x.HP == 59) / numOfGenerations, .175M, .225M);
        Assert.InRange<decimal>(baseStatsGenerationsMale.Count(x => x.HP == 59) / numOfGenerations, .125M, .1725M);
        Assert.InRange<decimal>(baseStatsGenerationsMale.Count(x => x.HP == 60) / numOfGenerations, .55M, .65M);
        Assert.InRange<decimal>(baseStatsGenerationsMale.Count(x => x.HP == 61) / numOfGenerations, .175M, .225M);
        Assert.InRange<decimal>(baseStatsGenerationsMale.Count(x => x.HP == 62) / numOfGenerations, .0375M, .0725M);
    }
}