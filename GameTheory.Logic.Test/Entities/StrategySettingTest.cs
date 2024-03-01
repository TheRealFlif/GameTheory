using NUnit.Framework;

namespace GameTheory.Logic.Entities;

[TestFixture]
internal class StrategySettingTest
{
    [Test]
    public void CreateFromType_Null_ThrowsException()
    {
        //Act
        Type? type = null;
        var actual = Assert.Throws<ArgumentNullException>(() => StrategySetting.CreateFromType(type));

        //Assert
        Assert.That(actual.Message, Is.EqualTo("Value cannot be null. (Parameter 'type')"));
    }

    [Test]
    public void CreateFromType_Defect_10_ReturnsTenDefect()
    {
        //Act
        var actual = StrategySetting.CreateFromType(typeof(AlwaysDefectStrategy), 10);

        //Assert
        Assert.Multiple(() =>
        {
            Assert.That(actual!.NumberOfStrategies, Is.EqualTo(10));
            Assert.That(actual!.Name, Is.EqualTo("AlwaysDefectStrategy"));
            Assert.That(actual!.TypeName, Is.EqualTo("GameTheory.Logic.Entities.AlwaysDefectStrategy"));
        });
    }

    [Test]
    public void CreateFromType_AlwaysCooperate_ReturnsOneCooperate()
    {
        //Act
        var actual = StrategySetting.CreateFromType(typeof(AlwaysCooperateStrategy));

        //Assert
        Assert.Multiple(() =>
        {
            Assert.That(actual!.NumberOfStrategies, Is.EqualTo(1));
            Assert.That(actual!.Name, Is.EqualTo("AlwaysCooperateStrategy"));
            Assert.That(actual!.TypeName, Is.EqualTo("GameTheory.Logic.Entities.AlwaysCooperateStrategy"));
        });
    }

    [Test]
    public void CreateFromType_Kalle_RandomStrategy_20_ReturnsThat()
    {
        //Act
        var actual = new StrategySetting("Kalle", "GameTheory.Logic.Entities.RandomStrategy", 20);

        //Assert
        Assert.Multiple(() =>
        {
            Assert.That(actual.NumberOfStrategies, Is.EqualTo(20));
            Assert.That(actual.Name, Is.EqualTo("Kalle"));
            Assert.That(actual.TypeName, Is.EqualTo("GameTheory.Logic.Entities.RandomStrategy"));
        });
    }

    [Test]
    public void Equals_SameParameters_ReturnsTrue()
    {
        //Arrange
        var sut1 = StrategySetting.CreateFromType(typeof(RandomStrategy), 10);
        var sut2 = StrategySetting.CreateFromType(typeof(RandomStrategy), 10);
        
        //Act
        var actual = sut1!.Equals(sut2);

        //Assert
        Assert.That(actual, Is.True);
    }

    [Test]
    public void Equals_DifferentTypes_ReturnsFalse()
    {
        //Arrange
        var sut1 = StrategySetting.CreateFromType(typeof(AlwaysDefectStrategy), 10);
        var sut2 = StrategySetting.CreateFromType(typeof(AlwaysCooperateStrategy), 10);

        //Act
        var actual = sut1!.Equals(sut2);

        //Assert
        Assert.That(actual, Is.False);
    }

    [Test]
    public void Equals_DifferentNumberOfStrategies_ReturnsFalse()
    {
        //Arrange
        var sut1 = StrategySetting.CreateFromType(typeof(AlwaysDefectStrategy), 1);
        var sut2 = StrategySetting.CreateFromType(typeof(AlwaysDefectStrategy), 2);

        //Act
        var actual = sut1!.Equals(sut2);

        //Assert
        Assert.That(actual, Is.False);
    }

    [Test]
    public void Equals_DifferentNames_ReturnsFalse()
    {
        //Arrange
        var sut1 = new StrategySetting("sut1", typeof(AlwaysCooperateStrategy).FullName, 1);
        var sut2 = StrategySetting.CreateFromType(typeof(AlwaysDefectStrategy), 2);

        //Act
        var actual = sut1.Equals(sut2);

        //Assert
        Assert.That(actual, Is.False);
    }

    [Test]
    public void CreateFromType_NotAIStrategy_ReturnsNull()
    {
        //Act
        var actual = StrategySetting.CreateFromType(typeof(string));

        //Assert
        Assert.That(actual, Is.Null);
    }
}
