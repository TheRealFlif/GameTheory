using GameTheory.Logic.Entities;

namespace GameTheory.Logic.Providers;

[TestFixture]
internal class StrategyLoaderTest
{
    [Test]
    public void Load_Logic_ReturnsMoreThan1Instance()
    {
        //Arrange
        var sut = new StrategyLoader();

        //Act
        var actual = sut.Load("GameTheory.Logic");

        //Assert
        Assert.That(actual, Has.Length.GreaterThan(1));
    }

    [Test]
    public void Load_LogicAndSettings_Returns1Instance()
    {
        //Arrange
        var sut = new StrategyLoader();
        var settings = new Settings(10, 10, 10, RewardMatrix.Default);
        //Act
        var actual = sut.Load("GameTheory.Logic", settings);

        //Assert
        Assert.That(actual, Has.Length.GreaterThan(10));
    }
}
