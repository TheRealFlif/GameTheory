namespace GameTheory.Logic.Entities;

[TestFixture]
internal class AlwaysDefectStrategyTest
{
    [Test]
    public void Next_Cooperate_ReturnsDefect()
    {
        //Arrange
        var sut = new AlwaysDefectStrategy();

        //Act
        var actual = sut.Next(Choice.Cooperate);

        //Assert
        Assert.That(actual, Is.EqualTo(Choice.Defect));
    }

    [Test]
    public void Next_Defect_ReturnsDefect()
    {
        //Arrange
        var sut = new AlwaysDefectStrategy();

        //Act
        var actual = sut.Next(Choice.Defect);

        //Assert
        Assert.That(actual, Is.EqualTo(Choice.Defect));
    }
}
