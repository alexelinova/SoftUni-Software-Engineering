using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops;
using Easter.Models.Workshops.Contracts;
using Easter.Repositories;
using Easter.Repositories.Contracts;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Core
{
    class Controller : IController
    {
        private IRepository<IBunny> bunnies;
        private IRepository<IEgg> eggs;
        private IWorkshop workshop;

        public Controller()
        {
            bunnies = new BunnyRepository();
            eggs = new EggRepository();
            workshop = new Workshop();
        }
        public string AddBunny(string bunnyType, string bunnyName)
        {
            IBunny bunny = null;

            if (bunnyType == nameof(SleepyBunny))
            {
                bunny = new SleepyBunny(bunnyName);
            }
            else if (bunnyType == nameof(HappyBunny))
            {
                bunny = new HappyBunny(bunnyName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidBunnyType);
            }

            bunnies.Add(bunny);

            return string.Format(OutputMessages.BunnyAdded, bunnyType, bunnyName);
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            IBunny bunny = bunnies.FindByName(bunnyName);
            IDye dye = new Dye(power);

            if (bunny == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentBunny);
            }

            bunny.AddDye(dye);

            return string.Format(OutputMessages.DyeAdded, power, bunnyName);
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            IEgg egg = new Egg(eggName, energyRequired);

            eggs.Add(egg);

            return string.Format(OutputMessages.EggAdded, eggName);
        }

        public string ColorEgg(string eggName)
        
        {
            List<IBunny> readyBunnies = bunnies.Models.Where(b => b.Energy >= 50).OrderByDescending(b => b.Energy).ToList();

            if (readyBunnies.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.BunniesNotReady);
            }

            IEgg egg = eggs.FindByName(eggName);

            while (!egg.IsDone() && readyBunnies.Count > 0)
            {
                IBunny bunny = readyBunnies.FirstOrDefault(r => r.Dyes.Count > 0);

                if (bunny == null)
                {
                    break;
                }

                workshop.Color(egg, bunny);

                if (bunny.Energy == 0)
                {
                    bunnies.Remove(bunny);
                    readyBunnies.Remove(bunny);
                }

                if (bunny.Dyes.Count == 0)
                {
                    continue;
                }
 
            }

            if (egg.IsDone())
            {
                return string.Format(OutputMessages.EggIsDone,eggName);
            }
            else
            {
                return string.Format(OutputMessages.EggIsNotDone, eggName);
            }
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{ CoutColourEggs(eggs)} eggs are done!");
            sb.AppendLine($"Bunnies info:");

            foreach (var bunny in bunnies.Models)
            {
                sb.AppendLine(bunny.ToString());
            }

            return sb.ToString().TrimEnd();

        }

        private int CoutColourEggs(IRepository<IEgg> eggs)
        {
            List<IEgg> colouredEggs = eggs.Models.Where(e => e.IsDone()).ToList();

            return colouredEggs.Count();
        }
    }
}
