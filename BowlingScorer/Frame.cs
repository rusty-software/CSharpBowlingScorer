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
                if (roll1 == 10)
                {
                    return "X";
                }
                else if ((roll1 + roll2) == 10)
                {
                    return string.Format("{0}/", roll1);
                }
                return string.Format("{0}-", roll1);
            }
        }

        private int roll1;
        private int roll2;

        public Frame(int roll1) : this(roll1, 0) { }

        public Frame(int roll1, int roll2)
        {
            this.roll1 = roll1;
            this.roll2 = roll2;
        }
    }
}
