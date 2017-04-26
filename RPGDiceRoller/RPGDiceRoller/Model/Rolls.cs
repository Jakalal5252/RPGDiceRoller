using System;
using System.Collections.Generic;
using System.Text;

namespace RPGDiceRoller.Model
{
    public class Rolls
    {
        /// <summary>
        /// Number of sides of the dice being rolled.
        /// </summary>
        public int SidesCount { get; set; }

        /// <summary>
        /// The total value of all the dice rolled.
        /// </summary>
        public int Roll { get; set; }

        /// <summary>
        /// The number of this type of dice that were rolled.
        /// </summary>
        public int NumberOfDice { get; set; }

        /// <summary>
        /// A string the represents the dice in the standard d20 format.
        /// </summary>
        public string FullDiceName { get; set; }

        public Rolls(int sidesCount, int roll, int numberOfDice)
        {
            SidesCount = sidesCount;
            Roll = roll;
            NumberOfDice = numberOfDice;
            FullDiceName = string.Format("{0}d{1}", NumberOfDice, SidesCount);
        }
    }
}
