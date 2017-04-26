using System;
using System.Collections.Generic;
using System.Text;

namespace RPGDiceRoller.Model
{
    public class Rolls
    {
        public int SidesCount { get; set; }
        public int Roll { get; set; }

        public Rolls(int sidesCount, int roll)
        {
            SidesCount = sidesCount;
            Roll = roll;
        }
    }
}
