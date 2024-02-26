namespace GameTheory.Logic.Entities;

[TestFixture]
public class RandomStrategyTest
{
    [Test]
    public void Next_()
    {
        //Arrange
        var sut = new RandomStrategy("RandomStrategy");

        //Act
        const int size = 10000;
        Choice[] actual = new Choice[size];
        for(var i = 0; i < size; i++)
        {
            actual[i] = sut.Next(Choice.Cooperate);
        }

        //Assert
        Assert.That(actual.All(c => (c | Choice.Defect) == Choice.Defect || (c | Choice.Cooperate) == Choice.Cooperate), Is.True);
        var absDiff = Math.Abs(actual.Count(c => c == Choice.Cooperate) - actual.Count(c => c == Choice.Defect));
        Assert.That(absDiff, Is.AtMost(size * 0.05), "This may fail if the randomisation is off or the size is \"too\" small, and one of the choices occurs more than 5% than the other");
    }
}