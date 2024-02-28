namespace GameTheory.Logic.Entities;

[TestFixture]
internal class RunnerTest
{
    [Test]
    public void Go_RandomAndAlwaysCooperate_RandomAlwaysWinOrTies()
    {
        //Arrange
        var settings = new Settings(10, 10, Settings.Default.NumberOfEachStrategyType, RewardMatrix.Default);
        var sut = new Runner(settings);

        //Act
        var actual = sut.Go(new RandomStrategy("Alice"), new AlwaysCooperateStrategy("Bob"));

        //Assert
        Assert.That(actual.Results.All(r => r.StrategyOneScore >= r.StrategyTwoScore), Is.True);
    }

    [Test]
    public void Go_AlwaysDefectAndAlwaysCooperate_DefectScores300AndCooperateScores0()
    {
        //Arrange
        var settings = new Settings(10, 10, Settings.Default.NumberOfEachStrategyType, RewardMatrix.Default);
        var sut = new Runner(settings);

        //Act
        var actual = sut.Go(new AlwaysDefectStrategy("Alice"), new AlwaysCooperateStrategy("Bob"));

        //Assert
        Assert.Multiple(() =>
        {
            Assert.That(actual.Results.Sum(r => r.StrategyOneScore), Is.EqualTo(300));
            Assert.That(actual.Results.Sum(r => r.StrategyTwoScore), Is.EqualTo(0));
        });
    }
}
