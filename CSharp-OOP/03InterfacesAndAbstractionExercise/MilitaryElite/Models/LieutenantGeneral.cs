﻿using MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private List<IPrivate> privates;
        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary)
            :base(id, firstName, lastName, salary)
        {
            this.privates = new List<IPrivate>();
        }
        public IReadOnlyCollection<IPrivate> Privates => this.privates.AsReadOnly();

        public void AddPrivate(IPrivate @private)
        {
            privates.Add(@private);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine("Privates:");

            foreach (var @private in privates)
            {
                sb.AppendLine($"  {@private}");
            }
            return sb.ToString().TrimEnd();
        }
    }
    
}
