using System;
using System.Collections.Generic;
using System.Text;

namespace Skeleton.Tests.Fakes
{
    class FakeTarget : ITarget
    {
        public const int DefaultExperience = 100;
        public int GiveExperience() => DefaultExperience;
        public bool IsDead()
        {
            return true;
        }

        public void TakeAttack(int attackPoints)
        { 
        }
    }
}
