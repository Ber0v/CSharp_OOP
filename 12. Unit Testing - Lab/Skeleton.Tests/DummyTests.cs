using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void DummyLosesHealthIfAttacked()
        {
            Dummy dummy = new Dummy(100, 100);

            dummy.TakeAttack(10);

            var expectedResult = 90;
            var actualResult = dummy.Health;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void DeadDummyThrowsExceptionIfAttacked()
        {
            Dummy dummy = new Dummy(0, 100);

            Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(10));
        }

        [Test]
        public void DeadDummyCanGiveXP()
        {
            Dummy dummy = new Dummy(0, 100);

            var expectedResult = 100;

            var actualResult = dummy.GiveExperience();

            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public void AliveDummyCantGiveXP()
        {
            Dummy dummy = new Dummy(100, 100);

            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
        }
    }
}