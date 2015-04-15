using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScorer
{
    public class Frame
    {
        public string Result
        {
            get
            {
                if (Roll1 == 10)
                {
                    return "X";
                }
                else if (RollSum == 10)
                {
                    return string.Format("{0}/", Roll1);
                }
                return string.Format("{0}-", Roll1);
            }
        }

        public int RollSum
        {
            get
            {
                return Roll1 + Roll2;
            }
        }

        public int Roll1 { get; private set; }
        public int Roll2 { get; private set; }

        public Frame(int roll1) : this(roll1, 0) { }

        public Frame(int roll1, int roll2)
        {
            Roll1 = roll1;
            Roll2 = roll2;
        }
    }
}
