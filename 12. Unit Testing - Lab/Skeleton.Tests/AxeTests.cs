using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        [TestCase(100, 100, 100, 100, 99)]
        [TestCase(45, 45, 50, 31, 30)]
        public void WeaponShoudLosesDurabilityAfterAttack
            (
        int health,
        int exp,
        int attack,
        int durability,
        int expResult
            )
        {
            Dummy dummy = new Dummy(health, exp);
            Axe axe = new Axe(attack, durability);

            axe.Attack(dummy);

            var actualResult = axe.DurabilityPoints;

            Assert.AreEqual(expResult, actualResult);
        }

        [Test]
        public void AttackShouldThrowInvalidOperationExceptionWhenAxeDurabilityIsBelowZero()
        {
            Dummy dummy = new Dummy(10, 10);
            Axe axe = new Axe(20, 0);

            Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
        }
    }
}