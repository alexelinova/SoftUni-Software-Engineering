using FightingArena;
using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void Setup()
        {
            arena = new Arena();
        }

        [Test]
        public void Count_ReturnsZero_WhenArenaIsEmpty()
        {
            int expectedResult = 0;

            Assert.That(arena.Count, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Ctor_InitializesWarriors()
        {
            Assert.That(arena.Warriors, Is.Not.Null);
        }

        [Test]
        public void Enroll_EcreasesArenaCount()
        {
            arena.Enroll(new Warrior("Warrior", 50, 50));
            int expectedResult = 1;

            Assert.That(arena.Count, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Enroll_AddsWarriorToWarriors()
        {
            string name = "Warrior";
            arena.Enroll(new Warrior(name, 50, 50));

            Assert.That(arena.Warriors.Any(w => w.Name == name), Is.True);
        }

        [Test]
        public void Enroll_ThrowsException_WhenWarriorAlreadyExists()
        {
            string name = "Warrior";

            arena.Enroll(new Warrior(name, 50, 50));

            Assert.Throws<InvalidOperationException>(() => arena.Enroll(new Warrior(name, 40, 40)));
        }

        [Test]
        public void Fight_ThrowsException_WhenAttackerIsNonExistent()
        {
            string defender = "Defender";

            arena.Enroll(new Warrior(defender, 100, 100));

            Assert.Throws<InvalidOperationException>(() => arena.Fight("Attacker", defender));
        }

        [Test]
        public void Fight_ThrowsException_WhenDefenderIsNonExistent()
        {
            string attacker = "Attacker";
            arena.Enroll(new Warrior(attacker, 100, 100));

            Assert.Throws<InvalidOperationException>(() => arena.Fight(attacker, "Defender"));
        }

        [Test]
        public void Fight_ThrowsException_WhenBothDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() => arena.Fight("Attacker", "Defender"));
        }

        [Test]
        public void Fight_BothWarriorsLooseHpInFight()
        {
            Warrior attacker = new Warrior("Attacker", 20, 100);
            Warrior defender = new Warrior("Warrior", 10, 100);

            arena.Enroll(attacker);
            arena.Enroll(defender);

            int expectedDefenderHp= defender.HP - attacker.Damage;
            int expectedAttackerHP = attacker.HP - defender.Damage;
            arena.Fight(attacker.Name, defender.Name);
         
            Assert.That(defender.HP, Is.EqualTo(expectedDefenderHp));
            Assert.That(attacker.HP, Is.EqualTo(expectedAttackerHP));
        }
    }
}
