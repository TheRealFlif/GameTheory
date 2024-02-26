namespace GameTheory.Logic.Entities;

[TestFixture]
internal class AlwaysCooperateStrategyTest
{
    [Test]
    public void Next_Defect_ReturnsCooperate()
    {
        //Arrange
        var sut = new AlwaysCooperateStrategy("AlwaysCooperateStrategy");
        var res = new Result(Choice.Defect, Choice.Cooperate);

        //Act
        var actual = sut.Next(Choice.Defect);

        //Assert
        Assert.That(actual, Is.EqualTo(Choice.Cooperate));
    }

    [Test]
    public void Next_Cooperate_ReturnsCooperate()
    {
        //Arrange
        var sut = new AlwaysCooperateStrategy("AlwaysCooperateStrategy");

        //Act
        var actual = sut.Next(Choice.Cooperate);

        //Assert
        Assert.That(actual, Is.EqualTo(Choice.Cooperate));
    }
}

