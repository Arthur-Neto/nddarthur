using System;
using NUnit.Framework;
using FluentAssertions;

namespace NDDTwitter.Infra.Tests
{
    [TestFixture]
    public class PostUtilTests
    {
        DateTime creationDate;

        [OneTimeSetUp]
        public void TestSetup()
        {
        }

        [Test]
        public void PostsUtil_ShouldReturnOneMinute()
        {
            creationDate = DateTime.Now.AddMinutes(-1);
            string expectedResult = PostUtil.GetTimeAgoFromDateTime(creationDate);
            expectedResult.Should().Be("1 minuto atrás");
        }

        [Test]
        public void PostsUtil_ShouldReturnTwolMinutes()
        {
            creationDate = DateTime.Now.AddMinutes(-2);
            string expectedResult = PostUtil.GetTimeAgoFromDateTime(creationDate);
            expectedResult.Should().Be("2 minutos atrás");
        }

        [Test]
        public void PostsUtil_ShouldReturnTwoHours()
        {
            creationDate = DateTime.Now.AddHours(-2);
            string expectedResult = PostUtil.GetTimeAgoFromDateTime(creationDate);
            expectedResult.Should().Be("2 horas atrás");
        }

        [Test]
        public void PostsUtil_ShouldReturnOneHour()
        {
            creationDate = DateTime.Now.AddHours(-1);
            string expectedResult = PostUtil.GetTimeAgoFromDateTime(creationDate);
            expectedResult.Should().Be("1 hora atrás");
        }

        [Test]
        public void PostsUtil_ShouldReturnThirtylMinutes()
        {
            creationDate = DateTime.Now.AddMinutes(-30);
            string expectedResult = PostUtil.GetTimeAgoFromDateTime(creationDate);
            expectedResult.Should().Be("30 minutos atrás");
        }

        [Test]
        public void PostsUtil_ShouldReturnOneDay()
        {
            creationDate = DateTime.Now.AddDays(-1);
            string expectedResult = PostUtil.GetTimeAgoFromDateTime(creationDate);
            expectedResult.Should().Be("1 dia atrás");
        }

        [Test]
        public void PostsUtil_ShouldReturnTwoDays()
        {
            creationDate = DateTime.Now.AddDays(-2);
            string expectedResult = PostUtil.GetTimeAgoFromDateTime(creationDate);
            expectedResult.Should().Be("2 dias atrás");
        }

        [Test]
        public void PostsUtil_ShouldReturnTwoWeeks()
        {
            creationDate = DateTime.Now.AddDays(-8);
            string expectedResult = PostUtil.GetTimeAgoFromDateTime(creationDate);
            expectedResult.Should().Be("2 semanas atrás");
        }

        [Test]
        public void PostsUtil_ShouldReturnOneWeek()
        {
            creationDate = DateTime.Now.AddDays(-7);
            string expectedResult = PostUtil.GetTimeAgoFromDateTime(creationDate);
            expectedResult.Should().Be("1 semana atrás");
        }

        [Test]
        public void PostsUtil_ShouldReturnOneMonth()
        {
            creationDate = DateTime.Now.AddMonths(-1);
            string expectedResult = PostUtil.GetTimeAgoFromDateTime(creationDate);
            expectedResult.Should().Be("1 mês atrás");
        }

        [Test]
        public void PostsUtil_ShouldReturnTwoMonths()
        {
            creationDate = DateTime.Now.AddMonths(-2);
            string expectedResult = PostUtil.GetTimeAgoFromDateTime(creationDate);
            expectedResult.Should().Be("2 meses atrás");
        }

        [Test]
        public void PostsUtil_ShouldReturnElevenMonths()
        {
            creationDate = DateTime.Now.AddMonths(-11);
            string expectedResult = PostUtil.GetTimeAgoFromDateTime(creationDate);
            expectedResult.Should().Be("11 meses atrás");
        }

        [Test]
        public void PostsUtil_ShouldReturnOneYear()
        {
            creationDate = DateTime.Now.AddYears(-1);
            string expectedResult = PostUtil.GetTimeAgoFromDateTime(creationDate);
            expectedResult.Should().Be("1 ano atrás");
        }

        [Test]
        public void PostsUtil_ShouldReturnTwoYears()
        {
            creationDate = DateTime.Now.AddYears(-2);
            string expectedResult = PostUtil.GetTimeAgoFromDateTime(creationDate);
            expectedResult.Should().Be("2 anos atrás");
        }
    }
}
