using System;
using System.Collections.Generic;
using System.Text;

namespace RPGDiceRoller.Model
{
    public class Rolls
    {
        public int SidesCount { get; set; }
        public int Roll { get; set; }
        public int NumberOfDice { get; set; }
        public string FullDiceName { get; set; }

        public Rolls(int sidesCount, int roll, int numberOfDice)
        {
            SidesCount = sidesCount;
            Roll = roll;
            NumberOfDice = numberOfDice;
            FullDiceName = String.Format("{0}d{1}", NumberOfDice, SidesCount);

        }
    }
}
