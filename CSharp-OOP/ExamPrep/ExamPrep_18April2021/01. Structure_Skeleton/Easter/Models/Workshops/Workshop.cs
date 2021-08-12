using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops.Contracts;

using System.Linq;

namespace Easter.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public void Color(IEgg egg, IBunny bunny)
        {
            while (!egg.IsDone() && bunny.Energy > 0 && bunny.Dyes.Count > 0)
            {
                IDye currDye = bunny.Dyes.First();

                while (bunny.Energy > 0 && !currDye.IsFinished() && !egg.IsDone())
                {
                    bunny.Work();
                    currDye.Use();
                    egg.GetColored();
                }

                if (currDye.IsFinished())
                {
                    bunny.Dyes.Remove(currDye);
                }

            }
        }
    }
}
