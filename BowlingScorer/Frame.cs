using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScorer
{
    public class Frame
    {
        private Dictionary<FrameResult, string> resultMarkMap = new Dictionary<FrameResult, string>
        {
            {FrameResult.Strike, "X"}, 
            {FrameResult.Spare, "{0}/"},
            {FrameResult.Miss, "{0}[{1}]"}
        };

        public FrameResult Result
        {
            get
            {
                if (Roll1 == 10)
                {
                    return FrameResult.Strike;
                }
                else if (RollSum == 10)
                {
                    return FrameResult.Spare;
                }
                return FrameResult.Miss;
            }
        }
        public string Mark
        {
            get
            {
                return string.Format(resultMarkMap[Result], Roll1, Roll2);
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
