namespace GameTheory.Logic.Entities;

[TestFixture]
internal class RunnerTest
{
    [Test]
    public void Go_RandomAndAlwaysCooperate_RandomAlwaysWinOrTies()
    {
        //Arrange
        var settings = new Settings(10, 10);
        var sut = new Runner(settings);

        //Act
        var actual = sut.Go(new RandomStrategy("Alice"), new AlwaysCooperateStrategy("Bob"));

        //Assert
        Assert.That(actual.Results.All(r => r.StrategyOneScore >= r.StrategyTwoScore), Is.True);
    }
}
