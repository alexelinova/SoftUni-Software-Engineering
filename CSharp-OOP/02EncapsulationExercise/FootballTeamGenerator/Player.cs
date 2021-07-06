using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class Player
    {
        private const int MinStat = 0;
        private const int MaxStat = 100;

        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                Validator.ThrowIfStringIsNullOrEmpty(value, "A name should not be empty.");
                this.name = value;
            }
        }
        public int Endurance
        {
            get => this.endurance;
            private set
            {
                Validator.ThrowIfOutSideRange(value, MinStat, MaxStat, $"{nameof(Endurance)} should be between {MinStat} and {MaxStat}.");

                this.endurance = value;
            }
        }
        public int Sprint
        {
            get => this.sprint;
            private set
            {
                Validator.ThrowIfOutSideRange(value, MinStat, MaxStat, $"{nameof(Sprint)} should be between {MinStat} and {MaxStat}.");

                this.sprint = value;
            }
        }
        public int Dribble
        {
            get => this.dribble;
            private set
            {
                Validator.ThrowIfOutSideRange(value, MinStat, MaxStat, $"{nameof(Dribble)} should be between {MinStat} and {MaxStat}.");

                this.dribble = value;
            }
        }
        public int Passing
        {
            get => this.passing;
            private set
            {
                Validator.ThrowIfOutSideRange(value, MinStat, MaxStat, $"{nameof(Passing)} should be between {MinStat} and {MaxStat}.");

                this.passing = value;
            }
        }
        public int Shooting
        {
            get => this.shooting;
            private set
            {
                Validator.ThrowIfOutSideRange(value, MinStat, MaxStat, $"{nameof(Shooting)} should be between {MinStat} and {MaxStat}.");

                this.shooting = value;
            }
        }

        public double AverageSkillPoints
        {
            get => Math.Round((this.Endurance + this.Sprint + this.Shooting + this.Dribble + this.passing) / 5.0);
        }
    }
}
