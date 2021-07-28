using Moq;
using NUnit.Framework;
using Skeleton;
using Skeleton.Tests.Fakes;

[TestFixture]
public class HeroTests
{
    [Test]
    public void Attack_GivesHeroExperience_WhenTargetDies_Fakes()
    {
        IWeapon weapon = new FakeWeapon();
        Hero hero = new Hero("TestHero", weapon);

        hero.Attack(new FakeTarget());

        Assert.That(hero.Experience, Is.EqualTo(FakeTarget.DefaultExperience));
    }

    [Test]
    public void Attack_GivesExperience_WhenTargetDies_Mock()
    {
        const int experience = 100;

        IWeapon weapon = Mock.Of<IWeapon>();

        Mock<ITarget> target = new Mock<ITarget>();

        target
            .Setup(t => t.IsDead())
            .Returns(true);

        target
            .Setup(t => t.GiveExperience())
            .Returns(experience);

        Hero hero = new Hero("TestHero", weapon);

        hero.Attack(target.Object);

        Assert.That(hero.Experience, Is.EqualTo(experience));
    }
}