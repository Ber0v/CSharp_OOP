namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class ArenaTests
    {
        private List<Warrior> warriorsList = new List<Warrior>
        {
            new Warrior("Ivan", 10, 100),
            new Warrior("Tina", 20, 200),
            new Warrior("Goro", 15, 150),
            new Warrior("Lilly", 22, 220)
        };


        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void EnrollMethodShouldEnrollWarriors()
        {
            var arena = new Arena();

            foreach (var warrior in warriorsList)
            {
                arena.Enroll(warrior);
            }

            Assert.That(arena.Warriors.Count, Is.EqualTo(warriorsList.Count));
            Assert.That(arena.Warriors.Count, Is.EqualTo(arena.Count));
        }

        [Test]
        public void EnrollMethodShouldThrowExceptionIfWarriorWithSameNameIsAdded()
        {
            var arena = new Arena();
            var warriorToEnroll = new Warrior("Test", 10, 100);

            arena.Enroll(warriorToEnroll);

            Assert
                .Throws<InvalidOperationException>(() => arena.Enroll(warriorToEnroll))
                .Message.Equals("Warrior is already enrolled for the fights!");
        }

        [Test]
        [TestCase("Miro", "Tina")]
        public void FightMethodShouldThrowExceptionIfWarriorsDoNotExist(string attackerName, string defenderName)
        {
            var arena = new Arena();

            foreach (var warrior in warriorsList)
            {
                arena.Enroll(warrior);
            }

            Assert.Throws<InvalidOperationException>(
                () => arena.Fight(attackerName, defenderName))
                .Message.Equals($"There is no fighter with name {attackerName} enrolled for the fights!");
        }

        [Test]
        [TestCase("Goro", "Tina")]
        [TestCase("Goro", "Ivan")]
        [TestCase("Tina", "Lilly")]
        [TestCase("Lilly", "Ivan")]
        public void FightMethodShouldSuccessfullyExecute(string attackerName, string defenderName)
        {
            // Arrange
            var arena = new Arena();
            foreach (var warrior in warriorsList)
            {
                arena.Enroll(warrior);
            }

            Warrior attacker = arena.Warriors
                .FirstOrDefault(w => w.Name == attackerName);
            Warrior defender = arena.Warriors
                .FirstOrDefault(w => w.Name == defenderName);

            int defenderInitialHP = defender.HP;

            arena.Fight(attackerName, defenderName);

            Assert.That(defender.HP, Is.EqualTo(defenderInitialHP - attacker.Damage));
        }
    }
}
