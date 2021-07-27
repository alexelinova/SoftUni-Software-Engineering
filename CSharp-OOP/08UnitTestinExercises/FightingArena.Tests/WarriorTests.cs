using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class WarriorTests
    {
        [Test]
        [TestCase("", 50, 100)]
        [TestCase("  ", 50, 100)]
        [TestCase(null, 50, 100)]
        [TestCase("Warrior", 0, 100)]
        [TestCase("Warrior", -10, 100)]
        [TestCase("Warrior", 50, -10)]
        public void Ctor_ThrowsException_WhenInvalidDataIsPassed(string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, damage, hp));
        }


        [Test]
        [TestCase(30, 55)]
        [TestCase(15, 55)]
        [TestCase(55, 30)]
        [TestCase(55, 15)]
        public void Attack_ThrowsException_WhenHPIsLessThanMinimum(int attackerHp, int warriorHP)
        {
            Warrior attacker = new Warrior("Attacker", 50, attackerHp);
            Warrior warrior = new Warrior("Warrior", 10, warriorHP);
            Assert.Throws<InvalidOperationException>(() => attacker.Attack(warrior));
        }

        [Test]
        public void Attack_ThrowsExcepton_WhenWarriorKillsAttacker()
        {
            Warrior attacker = new Warrior("Attacker", 50, 100);
            Warrior warrior = new Warrior("Warrior", attacker.HP + 1, 100);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(warrior));
        }

        [Test]
        public void Attack_DecreasesBothdWarriorsHP()
        {
            int initialAttackerHealthPoints = 100;
            int warriorInitialHp = 100;

            Warrior attacker = new Warrior("Attacker", 50, initialAttackerHealthPoints);
            Warrior warrior = new Warrior("Warrior", 30, warriorInitialHp);

            attacker.Attack(warrior);

            Assert.That(attacker.HP, Is.EqualTo(initialAttackerHealthPoints - warrior.Damage));
            Assert.That(warrior.HP, Is.EqualTo(warriorInitialHp - attacker.Damage));
        }

        [Test]
        public void Attack_SetEnemyHealthPointsToZero_WhenAttackerDamageIsGreaterThanEnemyHp()
        {
            Warrior attacker = new Warrior("Attacker", 50, 100);
            Warrior warrior = new Warrior("Warrior", 30, 40);

            attacker.Attack(warrior);

            Assert.That(warrior.HP, Is.EqualTo(0));
        }
    }
}