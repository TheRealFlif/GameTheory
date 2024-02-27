using GameTheory.Logic.Entities;

namespace GameTheory.Logic.Providers;

[TestFixture]
public class ArgsParserTest
{
    [Test]
    public void Parse_Empty_ReturnsDefaultValues() 
    {
        //Act
        var actual = ArgsParser.Parse([]);

        //Assert
        Assert.That(actual, Is.EqualTo(Settings.Default));
    }

    [Test]
    public void Parse_DefaultArgs_ReturnsDefaultValues()
    {
        //Act
        var actual = ArgsParser.Parse("-nr 100 -rl 100 -r 2 -t 3 -s 0 -p 1".Split(" "));

        //Assert
        Assert.That(actual, Is.EqualTo(Settings.Default));
    }

    [Test]
    public void Parse_Args_Returns()
    {
        //Act
        var actual = ArgsParser.Parse("-nr 50 -rl 10".Split(" "));
        var expected = new Settings(50, 10, RewardMatrix.Default);
        
        //Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Parse_MissingAValue_ThrowsIndexOutOfRangeException()
    {
        //Act
        var actual = Assert.Throws<IndexOutOfRangeException>(() => ArgsParser.Parse("-nr 100 -rl 100 -r 2 -t 3 -s 0 -p".Split(" ")));

        //Assert
        Assert.That(actual.Message, Is.EqualTo("Index was outside the bounds of the array."));
    }
}
