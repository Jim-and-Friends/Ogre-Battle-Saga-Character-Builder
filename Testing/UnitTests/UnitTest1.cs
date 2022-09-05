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
        var baseStatsGenerations = new List<Statistics>();

        // Act
        for(var x = 0; x < 1000; x++)
        {
            baseStatsGenerations.Add(tacticsOgreDataService.GenerateBaseStats(Gender.Female));        
        }
                
        // Assert        
        Assert.InRange<decimal>(baseStatsGenerations.Count(x => x.HP == 57) / 1000M, .175M, .225M);
        Assert.InRange<decimal>(baseStatsGenerations.Count(x => x.HP == 58) / 1000M, .55M, .65M);
        Assert.InRange<decimal>(baseStatsGenerations.Count(x => x.HP == 59) / 1000M, .175M, .225M);
    }
}