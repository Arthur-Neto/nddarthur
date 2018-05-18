using NUnit.Framework;

namespace IntroToNUnit.Tests
{
    public enum TestTypes
    {
        None,
        UnitTesting,
        IntegrationTesting,
        FlyByTheSeatOfYourPantsTesting
    }

    [TestFixture]
    public class EnumToStringConverterTests
    {
        [Test]
        public void CanConvertEnumIntoMultipleWords()
        {
            // Arrange/Act
            var actual = TestTypes.UnitTesting.ToFriendlyString();

            // Assert
            Assert.That(actual, Is.EqualTo("Unit Testing"));
        }
    }
}