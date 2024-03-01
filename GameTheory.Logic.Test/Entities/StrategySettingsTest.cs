using System.Reflection;

namespace GameTheory.Logic.Entities
{
    [TestFixture]
    internal class StrategySettingsTest
    {
        [Test]
        public void GetEnumerator_WithNoElements_ReturnsEmpty()
        {
            //Arrange
            var sut = new StrategySettings();

            //Act
            var actual = sut.GetEnumerator();

            //Assert
            Assert.That(actual.MoveNext(), Is.False);
        }

        [Test]
        public void Add_SameStrategySettingTwice_OnlyAddsTheFirstOne()
        {
            //Arrange
            var sut = new StrategySettings
            {
                //Act
                StrategySetting.CreateFromType(typeof(RandomStrategy), 2),
                StrategySetting.CreateFromType(typeof(RandomStrategy), 2)
            };
                        
            //Assert
            Assert.That(sut.Count(), Is.EqualTo(1));
        }

        [Test]
        public void Add_TwoDifferentStrategySetting_AddsBoth()
        {
            //Arrange
            var sut = new StrategySettings
            {
                //Act
                StrategySetting.CreateFromType(typeof(RandomStrategy), 2),
                StrategySetting.CreateFromType(typeof(RandomStrategy), 1)
            };

            //Assert
            Assert.That(sut.Count(), Is.EqualTo(2));
        }

        [Test]
        public void Equals_TwoEmptySettings_ReturnsTrue()
        {
            //Arrange
            var sut1 = new StrategySettings();
            var sut2 = new StrategySettings();

            //Act
            var actual = sut1.Equals(sut2);

            //Assert
            Assert.That(actual, Is.True);
        }

        [Test]
        public void Equals_TwoDifferentSettings_ReturnsFalse()
        {
            //Arrange
            var sut1 = new StrategySettings();
            var sut2 = new StrategySettings() { StrategySetting.CreateFromType(typeof(RandomStrategy))};

            //Act
            var actual = sut1.Equals(sut2);

            //Assert
            Assert.That(actual, Is.False);
        }
    }
}
