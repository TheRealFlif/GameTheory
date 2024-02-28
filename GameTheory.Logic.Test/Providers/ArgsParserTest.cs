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
        var expected = new Settings(50, 10, 1, RewardMatrix.Default);
        
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

    [Test]
    public void Parse_MissingAValue_ThrowsArgumentOutOfRangeException()
    {
        //Act
        var actual = Assert.Throws<ArgumentOutOfRangeException>(() => ArgsParser.Parse("-nr 100 -rl 100 -r 2 -t 3 -s 0 -p -1".Split(" ")));

        //Assert
        Assert.That(actual.Message, Is.EqualTo("Specified argument was out of the range of valid values. (Parameter '-p')"));
    }

    [Test]
    public void Parse_WithWrongType_ThrowsFormatException()
    {
        //Act
        var actual = Assert.Throws<FormatException>(() => ArgsParser.Parse("-nr ten -rl 100 -r 2 -t 3 -s 0 -p -1".Split(" ")));

        //Assert
        Assert.That(actual.Message, Is.EqualTo("The input string 'ten' was not in a correct format."));
    }

    [Test]
    public void Parse_WrongParameterName_ReturnsNull()
    {
        //Act
        var actual = ArgsParser.Parse("-x 100 -rl 100 -r 2 -t 3 -s 0 -p -1".Split(" "));

        //Assert
        Assert.That(actual, Is.Null);
    }

    [Test]
    public void Parse_NumberOfStrategies3_ReturnsSettingsWithNumberOfStrategies3()
    {
        //Act
        var actual = ArgsParser.Parse("-ns 3".Split(" "));
        var expected = new Settings(Settings.Default.NumberOfRuns, Settings.Default.LengthOfRun, 3, RewardMatrix.Default);

        //Assert
        Assert.That(actual, Is.EqualTo(expected));
    }
}
