namespace UnitTests;
using OgreBattleSagaCharacterBuilder.Data.TacticsOgre;
using OgreBattleSagaCharacterBuilder.Domain.TacticsOgre;

public class TacticsOgreTests
{
    [Fact]
    public void LoadJsonDataTest()
    {
        // Arrange
        var tacticsOgreDataService = new TacticsOgreDataService();

        // Act
        var classes = tacticsOgreDataService.Classes;

        // Assert
        Assert.Equal(10, classes.Count(x => x.Requirements.Gender == Gender.Female));
        Assert.Equal(13, classes.Count(x => x.Requirements.Gender == Gender.Male));
    }

    [Fact]
    public void RandomizeBaseStatsTest()
    {
        // Arrange
        var tacticsOgreDataService = new TacticsOgreDataService();                
        var baseStatsGenerationsFemale = new List<Statistics>();
        var baseStatsGenerationsMale = new List<Statistics>();        
        var numOfGenerations = 10000M;
        BaseStatProbabilityWeights femaleWeights;
        BaseStatProbabilityWeights maleWeights;

        // Act
        femaleWeights = tacticsOgreDataService.BaseStatProbabilityWeights.Single(x => x.Gender == Gender.Female);
        maleWeights = tacticsOgreDataService.BaseStatProbabilityWeights.Single(x => x.Gender == Gender.Male);
        
        for(var x = 0; x < numOfGenerations; x++)
        {
            baseStatsGenerationsFemale.Add(tacticsOgreDataService.GenerateBaseStats(Gender.Female));
            baseStatsGenerationsMale.Add(tacticsOgreDataService.GenerateBaseStats(Gender.Male));
        }
                
        // Assert
        foreach(var vwpair in femaleWeights.HP)             { Assert.InRange<decimal>(baseStatsGenerationsFemale.Count(x => x.HP == vwpair.Value)           / numOfGenerations, (vwpair.Weight * 0.0085M), (vwpair.Weight * 0.0115M)); }
        foreach(var vwpair in femaleWeights.MP)             { Assert.InRange<decimal>(baseStatsGenerationsFemale.Count(x => x.MP == vwpair.Value)           / numOfGenerations, (vwpair.Weight * 0.0085M), (vwpair.Weight * 0.0115M)); }
        foreach(var vwpair in femaleWeights.Strength)       { Assert.InRange<decimal>(baseStatsGenerationsFemale.Count(x => x.Strength == vwpair.Value)     / numOfGenerations, (vwpair.Weight * 0.0085M), (vwpair.Weight * 0.0115M)); }
        foreach(var vwpair in femaleWeights.Vitality)       { Assert.InRange<decimal>(baseStatsGenerationsFemale.Count(x => x.Vitality == vwpair.Value)     / numOfGenerations, (vwpair.Weight * 0.0085M), (vwpair.Weight * 0.0115M)); }
        foreach(var vwpair in femaleWeights.Intelligence)   { Assert.InRange<decimal>(baseStatsGenerationsFemale.Count(x => x.Intelligence == vwpair.Value) / numOfGenerations, (vwpair.Weight * 0.0085M), (vwpair.Weight * 0.0115M)); }
        foreach(var vwpair in femaleWeights.Mentality)      { Assert.InRange<decimal>(baseStatsGenerationsFemale.Count(x => x.Mentality == vwpair.Value)    / numOfGenerations, (vwpair.Weight * 0.0085M), (vwpair.Weight * 0.0115M)); }
        foreach(var vwpair in femaleWeights.Agility)        { Assert.InRange<decimal>(baseStatsGenerationsFemale.Count(x => x.Agility == vwpair.Value)      / numOfGenerations, (vwpair.Weight * 0.0085M), (vwpair.Weight * 0.0115M)); }
        foreach(var vwpair in femaleWeights.Dexterity)      { Assert.InRange<decimal>(baseStatsGenerationsFemale.Count(x => x.Dexterity == vwpair.Value)    / numOfGenerations, (vwpair.Weight * 0.0085M), (vwpair.Weight * 0.0115M)); }
        foreach(var vwpair in femaleWeights.Luck)           { Assert.InRange<decimal>(baseStatsGenerationsFemale.Count(x => x.Luck == vwpair.Value)         / numOfGenerations, (vwpair.Weight * 0.0085M), (vwpair.Weight * 0.0115M)); }
        foreach(var vwpair in maleWeights.HP)               { Assert.InRange<decimal>(baseStatsGenerationsMale.Count(x => x.HP == vwpair.Value)             / numOfGenerations, (vwpair.Weight * 0.0085M), (vwpair.Weight * 0.0115M)); }
        foreach(var vwpair in maleWeights.MP)               { Assert.InRange<decimal>(baseStatsGenerationsMale.Count(x => x.MP == vwpair.Value)             / numOfGenerations, (vwpair.Weight * 0.0085M), (vwpair.Weight * 0.0115M)); }
        foreach(var vwpair in maleWeights.Strength)         { Assert.InRange<decimal>(baseStatsGenerationsMale.Count(x => x.Strength == vwpair.Value)       / numOfGenerations, (vwpair.Weight * 0.0085M), (vwpair.Weight * 0.0115M)); }
        foreach(var vwpair in maleWeights.Vitality)         { Assert.InRange<decimal>(baseStatsGenerationsMale.Count(x => x.Vitality == vwpair.Value)       / numOfGenerations, (vwpair.Weight * 0.0085M), (vwpair.Weight * 0.0115M)); }
        foreach(var vwpair in maleWeights.Intelligence)     { Assert.InRange<decimal>(baseStatsGenerationsMale.Count(x => x.Intelligence == vwpair.Value)   / numOfGenerations, (vwpair.Weight * 0.0085M), (vwpair.Weight * 0.0115M)); }
        foreach(var vwpair in maleWeights.Mentality)        { Assert.InRange<decimal>(baseStatsGenerationsMale.Count(x => x.Mentality == vwpair.Value)      / numOfGenerations, (vwpair.Weight * 0.0085M), (vwpair.Weight * 0.0115M)); }
        foreach(var vwpair in maleWeights.Agility)          { Assert.InRange<decimal>(baseStatsGenerationsMale.Count(x => x.Agility == vwpair.Value)        / numOfGenerations, (vwpair.Weight * 0.0085M), (vwpair.Weight * 0.0115M)); }
        foreach(var vwpair in maleWeights.Dexterity)        { Assert.InRange<decimal>(baseStatsGenerationsMale.Count(x => x.Dexterity == vwpair.Value)      / numOfGenerations, (vwpair.Weight * 0.0085M), (vwpair.Weight * 0.0115M)); }
        foreach(var vwpair in maleWeights.Luck)             { Assert.InRange<decimal>(baseStatsGenerationsMale.Count(x => x.Luck == vwpair.Value)           / numOfGenerations, (vwpair.Weight * 0.0085M), (vwpair.Weight * 0.0115M)); }
    }
}