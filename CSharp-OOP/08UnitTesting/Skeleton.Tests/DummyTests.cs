using NUnit.Framework;
using System;

[TestFixture]
public class DummyTests
{
    private Dummy dummy;

    [SetUp]
    public void SetUp()
    {
        dummy = new Dummy(10, 10);
    }
    [Test]
    public void TakeAttackThrowsExceptionWhenHealthIsZero()
    {
        int attackpoints = 10;

        dummy.TakeAttack(attackpoints);

        Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(attackpoints));
    }

    [Test]
    public void TakeAttackReducesHealth()
    {
        int attackPoints = 5;
        int expectedResult = 5;

        dummy.TakeAttack(attackPoints);

        Assert.That(dummy.Health, Is.EqualTo(expectedResult));
    }

    [Test]
    public void GiveExperienceReturnsExperienceWhenDead()
    {
        dummy.TakeAttack(10);

        int experience = dummy.GiveExperience();

         Assert.That(dummy.IsDead);
         Assert.That(10, Is.EqualTo(experience));
    }

    [Test]
    public void GivesExperienceThrowsExceptionWhenAlive()
    {
        dummy.TakeAttack(5);

        Assert.That(dummy.IsDead, Is.False);
        Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
    }
}
