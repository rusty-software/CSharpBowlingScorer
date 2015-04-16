using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScorer
{
    public class FinalFrame
    {
        public List<int> Rolls = new List<int>();

        public int RollSum
        {
            get
            {
                var score = Rolls[0] + Rolls[1];
                if (score >= 10 && Rolls.Count > 2)
                {
                    score += Rolls[2];
                }
                return score;
            }
        }

        public FinalFrame(List<int> rolls)
        {
            if (rolls.Count < 2)
            {
                throw new ArgumentOutOfRangeException("rolls", "Final frame must have at least two rolls!");
            }
            Rolls = rolls;
        }
    }
}
