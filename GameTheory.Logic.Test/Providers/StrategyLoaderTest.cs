namespace GameTheory.Logic.Providers;

[TestFixture]
internal class StrategyLoaderTest
{
    [Test]
    public void Load_Logic_Returns1Instance()
    {
        //Arrange
        var sut = new StrategyLoader();

        //Act
        var actual = sut.Load("GameTheory.Logic");

        //Assert
        Assert.That(actual, Has.Length.Not.EqualTo(0));
    }
}
