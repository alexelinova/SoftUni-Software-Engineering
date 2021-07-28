using NUnit.Framework;
using System;

[TestFixture]
public class AxeTests
{
    private Axe axe;
    private Dummy dummy;

    [SetUp]
    public void SetUp()
    {
       axe = new Axe(10, 2);
       dummy = new Dummy(20, 20);
    }

    [Test]
    public void AxeLoosesDurabilityAfterAttack()
    {
  
        int expectedResult = 1;

        axe.Attack(dummy);

        Assert.That(axe.DurabilityPoints, Is.EqualTo(expectedResult),"Durability points reduce with 1 after each attack");
    }

    [Test]
    public void AxeAttacksWithZeroDurabilityReturnException()
    {
        axe.Attack(dummy);
        axe.Attack(dummy);
     

        Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
    }
}