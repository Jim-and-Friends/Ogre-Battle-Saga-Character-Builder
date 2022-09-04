namespace UnitTests;
using OgreBattleSagaCharacterBuilder.Data.TacticsOgre;

public class UnitTest1
{
    [Fact]
    public void LoadJsonData()
    {
        // Arrange
        var tacticsOgreDataService = new TacticsOgreDataService();

        // Act
        var classes = tacticsOgreDataService.Classes;

        // Assert
        Assert.Equal(12, classes.Count);
    }
}